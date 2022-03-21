using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.MotherBoardDTOs
{
    public class MotherBoardGetDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
