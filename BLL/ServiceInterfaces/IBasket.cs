using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IBasket
    {
        void addToBasket(BasketPositionRequestDTO basket);
        void changeNumberOfProducts(int id, int numberOfProducts);
        void removeProductFormBasket(int id);
        OrderResponseDTO GenerateOrder(int userId);
        void pay(int userId, double value);

    }
}
