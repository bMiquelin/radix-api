using RadixAPI.Contract;
using System;

namespace RadixAPI.Providers
{
    public interface IProvider
    {
        bool MakeTransaction(Guid transactionId, TransactionRequest transaction);

    }
}