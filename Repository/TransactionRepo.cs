using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LauToken.DTO;
using LauToken.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace LauToken.Repository
{

    public class TransactionRepo : ITransactionRepo
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;

        public TransactionRepo(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TransactionReadDTO> GetTransactionsByAddress(string address)
        {
            var transactions =  (from t in _context.Transactions
                join s in _context.Stores on t.Receiver equals s.Address
                into g 
                from x in g.DefaultIfEmpty()
                select new JoinedTransactionSource
                {
                   Transaction = t,
                   Store = x
                }
                ).Where(n => n.Transaction.Sender.ToLower().Equals(address.ToLower()) ||  n.Transaction.Receiver.ToLower().Equals(address.ToLower()) ).ToList();
            
            
            
            return  _mapper.Map<IEnumerable<TransactionReadDTO>>(transactions);
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            var transactionResponse = _context.Add(transaction).Entity;
            _context.SaveChanges();
            return transactionResponse;
            
        }
    }
}