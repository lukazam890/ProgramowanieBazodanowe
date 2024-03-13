using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserRequestDTO
    {
        public string Login { get; init; }
        public string Password { get; init; }
        public UserType UserType { get; init; }
        public bool isActive { get; init; }
        public int? GroupID { get; init; }
        public List<OrderRequestDTO> Orders { get; init; }
        public List<BasketPositionRequestDTO> BasketPositions { get; init; }
    }
}
