using System;
using System.Collections.Generic;
using LauToken.DTO;
using LauToken.Models;

namespace LauToken.Repository
{
    public interface ITransactionRepo
    {
        IEnumerable<TransactionReadDTO> GetTransactionsByAddress(string address);
        Transaction CreateTransaction(Transaction transaction);
    }
}