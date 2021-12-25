using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LauToken.DTO
{
   
    public class TransactionCreateDTO
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Type { get; set; }
        public long Amount { get; set; }
        public string? Details { get; set; }
        public DateTime Date { get; set; }
        
        public TransactionCreateDTO( 
            string id, string sender, string receiver, string type, long amount, string details, DateTime date
        )
        {
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Type = type;
            Amount = amount;
            Details = details;
            Date = date;
        }
    }
}