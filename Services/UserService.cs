using System;
using System.Collections.Generic;
using AutoMapper;
using LauToken.DTO;
using LauToken.Models;
using LauToken.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LauToken.Services
{

    public class TransactionService : ITransactionService
    {


        private readonly ITransactionRepo _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepo transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        public IEnumerable<TransactionReadDTO> GetTransactionsByAddress(string address)
        {
            return _transactionRepository.GetTransactionsByAddress(address);
        }
        
        public Transaction CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException(nameof(transaction));
            }

            return _transactionRepository.CreateTransaction(transaction);
        }

    }
}