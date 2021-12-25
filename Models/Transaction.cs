using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LauToken.Models
{
    [Table("transaction")]
    public partial class Transaction
    {
        [Key]
        [Column("id", TypeName = "character varying")]
        public string Id { get; set; } = null!;
        [Column("sender", TypeName = "character varying")]
        public string Sender { get; set; } = null!;

        [Column("receiver", TypeName = "character varying")]
        public string Receiver { get; set; } = null!;
        [Column("type", TypeName = "character varying")]
        public string Type { get; set; } = null!;
        [Column("amount")]
        public long Amount { get; set; }
        [Column("details", TypeName = "jsonb")]
        public string? Details { get; set; }
        [Column("date", TypeName = "timestamp without time zone")]
        public DateTime Date { get; set; }
    }
}