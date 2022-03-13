﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class VideoCard : BaseEntity
    {
        public int VideoCardSerieId { get; set; }
        public string Model { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public string MemoryCapacity { get; set; }
        public string CoreSpeed { get; set; }
        public int Count { get; set; }
        public VideoCardSerie VideoCardSerie { get; set; }
    }
}
