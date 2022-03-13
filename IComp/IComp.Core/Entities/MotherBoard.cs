﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Core.Entities
{
    public class MotherBoard : BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Model { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
    }
}
