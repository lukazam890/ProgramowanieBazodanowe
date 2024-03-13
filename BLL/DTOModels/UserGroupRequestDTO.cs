using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class UserGroupRequestDTO
    {
        public string Name { get; init; }
        public List<UserRequestDTO> Users { get; init; }
        public List<BasketPositionRequestDTO> BasketPositions { get; init; }
    }
}
