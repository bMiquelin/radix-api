using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadixAPI.Authorization;
using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Providers;
using RadixAPI.Managers;
using RadixAPI.Model.Entity;
using RadixAPI.Exceptions;

namespace RadixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(StoreAuthorization))]
    public class TransactionController : ControllerBase
    {
        private readonly RadixAPIContext ctx;
        private readonly TransactionManager transactionManager;
        public TransactionController(RadixAPIContext ctx, TransactionManager transactionManager)
        {
            this.ctx = ctx;
            this.transactionManager = transactionManager;
        }
        public Guid StoreId { get { return Guid.Parse(Request.Headers["STORE_ID"]); } }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get() => ctx.Transactions
            .Where(tran => tran.Store.Id == StoreId)
            .ToArray();

        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(Guid id) => ctx.Transactions
            .Where(tran => tran.Store.Id == StoreId)
            .FirstOrDefault(tran => tran.Id == id);

        [HttpPost]
        public object Post([FromBody] TransactionRequest transactionRequest)
        {
            try
            {
                var store = ctx.Stores.Include(i => i.StoreProviderRules).First(s => s.Id == StoreId);
                var transaction = transactionManager.CreateTransaction(store, transactionRequest);
                transaction.Store = null;
                return transaction;
            }
            catch(APIException ex)
            {
                return ex.ToErrorResult();
            }
            catch (Exception)
            {
                return new ErrorResult("An error occurred");
            }
        }
    }
}