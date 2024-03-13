using BLL.DTOModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface Basket
    {
        void addToBasket(BasketPositionRequestDTO basket);
        void changeNumberOfProducs(int id, int numberOfProducts);
        void removeProductFormBasket(int id);
        OrderResponseDTO GenerateOrder(int userId);
        void pay(double value);

    }
}
