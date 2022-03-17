using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.CategoryDTOs
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
