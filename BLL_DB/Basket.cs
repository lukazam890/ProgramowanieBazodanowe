using BLL.DTOModels;
using BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class Basket : IBasket
    {
        public void addToBasket(BasketPositionRequestDTO basket)
        {
            throw new NotImplementedException();
        }

        public void changeNumberOfProducts(int id, int numberOfProducts)
        {
            throw new NotImplementedException();
        }

        public OrderResponseDTO GenerateOrder(int userId)
        {
            throw new NotImplementedException();
        }

        public void pay(int userId, double value)
        {
            throw new NotImplementedException();
        }

        public void removeProductFormBasket(int id)
        {
            throw new NotImplementedException();
        }
    }
}
