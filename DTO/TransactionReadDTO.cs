using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LauToken.Models;

namespace LauToken.DTO
{
    public class TransactionReadDTO
    {
        public string Id { get; set; } = null!;
        public string Sender { get; set; } = null!;
        public string? Receiver { get; set; }
        public string Type { get; set; } = null!;
        public long Amount { get; set; }
        public string? Details { get; set; }
        public DateTime? Date { get; set; }
        public string? Store { get; set; }
        public string? Location { get; set; }

        public TransactionReadDTO( 
            Transaction transaction,
            Store store
        )
        {
            Id = transaction.Id;
            Sender = transaction.Sender;
            Receiver = transaction.Receiver;
            Type = transaction.Type;
            Amount = transaction.Amount;
            Details = transaction.Details;
            Date = transaction.Date;
            Store = store?.Name;
            Location = store?.Location;
        }
    }
}