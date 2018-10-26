using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadixAPI.Authorization;
using RadixAPI.Contract;
using RadixAPI.Data;
using RadixAPI.Gateways;
using RadixAPI.Managers;
using RadixAPI.Model.Entity;

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
            var store = ctx.Stores.Include(i => i.StoreGatewayRules).First(s => s.Id == StoreId);

            var transaction = transactionManager.CreateTransaction(store, transactionRequest);
            return transaction;
        }
    }
}