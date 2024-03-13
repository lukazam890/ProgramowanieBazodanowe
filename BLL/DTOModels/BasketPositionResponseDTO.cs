using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class BasketPositionResponseDTO
    {
        public int UserID { get; init; }
        public int Amount { get; init; }
        public double Price { get; init; }
    }
}
