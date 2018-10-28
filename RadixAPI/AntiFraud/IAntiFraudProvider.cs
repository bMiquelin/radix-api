using RadixAPI.Contract;

namespace RadixAPI.AntiFraud
{
    public interface IAntiFraudProvider
    {
        bool Validate(TransactionRequest transactionRequest);
    }
}
