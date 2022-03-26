using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IComp.Core.Entities
{
    public class Order : BaseEntity
    {
        public string AppUserId { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Address { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Phone { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
