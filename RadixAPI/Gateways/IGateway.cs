using RadixAPI.Contract;
using System;

namespace RadixAPI.Gateways
{
    public interface IGateway
    {
        bool MakeTransaction(TransactionRequest transaction);

    }
}