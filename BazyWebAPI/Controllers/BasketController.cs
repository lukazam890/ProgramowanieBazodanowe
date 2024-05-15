using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasket _basket;
        public BasketController(IBasket basket)
        {
            _basket = basket;
        }

        [HttpPost]
        public void addToBasket(BasketPositionRequestDTO basket)
        {
            _basket.addToBasket(basket);
        }

        [HttpGet("number")]
        public void changeNumberOfProducts(int userId, int numberOfProducts)
        {
            _basket.changeNumberOfProducts(userId, numberOfProducts);
        }


        [HttpGet("Order")]
        public OrderResponseDTO GenerateOrder(int userId)
        {
            return _basket.GenerateOrder(userId);
        }

        [HttpPut("pay")]
        public void pay(int userId, double value)
        {
            _basket.pay(userId, value);
        }

        [HttpDelete]
        public void removeProductFormBasket(int userId)
        {
            _basket.removeProductFormBasket(userId);
        }
    }
}
