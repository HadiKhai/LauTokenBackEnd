using System;
using System.Collections.Generic;
using AutoMapper;
using LauToken.DTO;
using LauToken.Models;
using LauToken.Repository;
using LauToken.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace LauToken.Controller
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController: ControllerBase
    {
        private readonly ITransactionService _service;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet("{address}",Name = "GetTransactionsByAddress")]
        public ActionResult <IEnumerable<TransactionReadDTO>> GetTransactionsByAddress(string address)
        {
            var transactions = _service.GetTransactionsByAddress(address);

            return Ok(transactions);
        }
        
        [HttpPost("create")]
        public ActionResult <Transaction> CreateTransaction(TransactionCreateDTO transaction)
        {
            try
            {
                var tx = _service.CreateTransaction(_mapper.Map<Transaction>(transaction));
                return CreatedAtRoute("GetTransactionsByAddress", new { Address = tx.Sender }, tx);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return Problem(e.GetBaseException().ToString());
            }
        }
        
    }
}