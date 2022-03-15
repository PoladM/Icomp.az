using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class HardDisc : BaseEntity
    {
        public int HDDCapacityId { get; set; }
        public string ModelName { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
        public HDDCapacity HDDCapacity { get; set; }
    }
}
