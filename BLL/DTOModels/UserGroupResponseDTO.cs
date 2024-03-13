using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserGroupResponseDTO
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public List<UserResponseDTO> Users { get; init; }
        public List<BasketPositionResponseDTO> BasketPositions { get; init; }
    }
}
