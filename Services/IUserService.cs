using System;
using System.Collections.Generic;
using LauToken.DTO;
using LauToken.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LauToken.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionReadDTO> GetTransactionsByAddress(string address);
        Transaction CreateTransaction(Transaction transaction);
    }
}