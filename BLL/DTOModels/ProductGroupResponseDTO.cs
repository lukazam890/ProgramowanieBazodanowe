using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductGroupResponseDTO
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public int? ParentID { get; init; }
        public List<ProductResponseDTO> Childrens { get; init; }
        public List<ProductRequestDTO> Products { get; init; }
    }
}
