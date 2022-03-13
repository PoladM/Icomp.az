using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Core.Entities
{
    public class HDDCapacity
    {
        public int Id { get; set; }
        public string Capacity { get; set; }
        public string CycleRate { get; set; }
        public bool IsSSD { get; set; }
        public bool IsHDD { get; set; }
        public List<HardDisc> HardDiscs { get; set; }
    }
}
