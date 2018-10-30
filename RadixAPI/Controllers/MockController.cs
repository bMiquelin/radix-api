using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Controllers
{
    [ApiController]
    public class ClearSaleController : ControllerBase
    {
        [HttpPost]
        [Route("[controller]/auth/[action]")]
        public RadixAPI.AntiFraud.ClearSale.ResponseAuth Login(RadixAPI.AntiFraud.ClearSale.RequestAuthModel request) => new RadixAPI.AntiFraud.ClearSale.ResponseAuth
        {
            Token = new AntiFraud.ClearSale.TokenModel
            {
                ExpirationDate = DateTime.UtcNow.AddMinutes(5).ToString(),
                Value = Guid.NewGuid().ToString()
            }
        };

        private readonly string[] status = { "APA", "SUS", "RPA" };
        [HttpPost]
        [Route("[controller]/order/[action]")]
        public RadixAPI.AntiFraud.ClearSale.ResponseSend Send(RadixAPI.AntiFraud.ClearSale.RequestSendModel request) => new RadixAPI.AntiFraud.ClearSale.ResponseSend
        {
            TransactionId = Guid.NewGuid().ToString(),
            Orders = new List<AntiFraud.ClearSale.OrderStatusModel>
            {
                new AntiFraud.ClearSale.OrderStatusModel
                {
                    ID = Guid.NewGuid().ToString(),
                    Score = (decimal)(new Random().Next(0, 10000) / 100.0),
                    Status = status[new Random().Next(status.Length)]
                }
            }
        };
    }

    [ApiController]
    public class CieloController : ControllerBase
    {
        [HttpPost]
        [Route("[controller]/[action]")]
        public RadixAPI.Providers.Cielo.SalesResponseModel Sales(RadixAPI.Providers.Cielo.SalesRequestModel request) => new Providers.Cielo.SalesResponseModel
        {
            ProofOfSale = "123",
            AuthorizationCode = "456",
            Status = 1,
            Tid = "000001234",
            ReturnCode = "4",
            PaymentId = Guid.NewGuid(),
            ReturnMessage = "Operation Succeful",
            ECI = "8"
        };
    }

    [ApiController]
    public class StoneController : ControllerBase
    {
        [HttpPost]
        [Route("[controller]/[action]")]
        public RadixAPI.Providers.Stone.SaleResponseModel Sale(RadixAPI.Providers.Stone.SaleRequestModel request) => new RadixAPI.Providers.Stone.SaleResponseModel {
            ErrorReport = null,
            InternalTime = 137,
            MerchantKey = "F2A1F485-CFD4-49F5-8862-0EBC438AE923",
            RequestKey = "857a5a07-ff3c-46e3-946e-452e25f149eb",
            BoletoTransactionResultCollection = new System.Collections.ObjectModel.Collection<object>(),
            BuyerKey = "00000000-0000-0000-0000-000000000000",
            CreditCardTransactionResultCollection = new System.Collections.ObjectModel.Collection<Providers.Stone.CreditCardTransactionResultModel> {
                new Providers.Stone.CreditCardTransactionResultModel{
                    AcquirerMessage = "Simulator|Transação de simulação autorizada com sucesso",
                    AcquirerName = "Simulator",
                    AcquirerReturnCode = "0",
                    AffiliationCode = "000000000",
                    AmountInCents = 10000,
                    AuthorizationCode = "168147",
                    AuthorizedAmountInCents = 10000,
                    CapturedAmountInCents = 10000,
                    CapturedDate = DateTime.Parse("2015-12-04T19:51:11"),
                    CreditCard = new Providers.Stone.CreditCardResultModel {
                        CreditCardBrand = "Visa",
                        InstantBuyKey = "3b3b5b62-6660-428d-905e-96f49d46ae28",
                        IsExpiredCreditCard = false,
                        MaskedCreditCardNumber = "411111****1111"
                    },
                    CreditCardOperation = "AuthAndCapture",
                    CreditCardTransactionStatus = "Captured",
                    DueDate = null,
                    ExternalTime = 0,
                    PaymentMethodName = "Simulator",
                    RefundedAmountInCents = null,
                    Success = true,
                    TransactionIdentifier = "246844",
                    TransactionKey = "20ba0520-7d09-44f8-8fbc-e4329e2b18d5",
                    TransactionKeyToAcquirer = "20ba05207d0944f8",
                    TransactionReference = "1c65eaf7-df3c-4c7f-af63-f90fb6200996",
                    UniqueSequentialNumber = "636606",
                    VoidedAmountInCents = null
                }
            },
            OrderResult = new Providers.Stone.OrderResultModel {
                CreateDate = DateTime.Parse("2015-12-04T19:51:11"),
                OrderKey = "219d7581-78e2-4aa9-b708-b7c585780bfc",
                OrderReference = "NúmeroDoPedido"
            }
        };
    }
}
