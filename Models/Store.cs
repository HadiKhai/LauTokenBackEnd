using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LauToken.Models
{
    [Table("store")]
    public partial class Store
    {
        [Key]
        [Column("address", TypeName = "character varying")]
        public string Address { get; set; } = null!;
        [Column("name", TypeName = "character varying")]
        public string Name { get; set; } = null!;
        [Column("location", TypeName = "character varying")]
        public string Location { get; set; } = null!;
    }
}