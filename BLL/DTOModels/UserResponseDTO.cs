using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserResponseDTO
    {
        public int ID { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public UserType UserType { get; init; }
        public bool isActive { get; init; }
        public int? GroupID { get; init; }
        public List<OrderResponseDTO> Orders { get; init; }
        public List<BasketPositionResponseDTO> BasketPositions { get; init; }
    }
}
