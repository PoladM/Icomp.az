using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.VideoCardDTOs
{
    public class VideoCardPostDto
    {
        public string ModelName { get; set; }
        public int VCSerieId { get; set; }
        public int Count { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public string MemoryCapaciry { get; set; }
        public string CoreSpeed { get; set; }
    }
}
