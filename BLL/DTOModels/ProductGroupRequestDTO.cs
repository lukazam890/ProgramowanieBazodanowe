﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductGroupRequestDTO
    {
        public string Name { get; init; }
        public int? ParentID { get; init; }
        public List<ProductGroupRequestDTO> Childrens { get; init; }
        public List<ProductRequestDTO> Products { get; init; }
    }
}
