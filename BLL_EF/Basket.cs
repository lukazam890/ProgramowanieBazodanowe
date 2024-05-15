using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class Basket : IBasket
    {
        private readonly WebshopContext _context;

        public Basket(WebshopContext context)
        {
            _context = context;
        }

        public void addToBasket(BasketPositionRequestDTO basket)
        {
            Product? product = _context.Products.FirstOrDefault(p=>p.ID==basket.ProductID);
            if (product == null || !product.IsActive)
                return;
            BasketPosition basketTemp = new BasketPosition
            {
                ProductID = basket.ProductID,
                UserID = basket.UserID,
                Amount = basket.Amount,
                Price = basket.Price,
            };
            _context.BasketPositions.Add(basketTemp);
            _context.SaveChanges();
        }

        public void changeNumberOfProducts(int id, int numberOfProducts)
        {
            if (numberOfProducts <= 0)
                return;
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(p => p.UserID == id);
            if (basket == null) return;
            basket.Amount = numberOfProducts;
            _context.SaveChanges();
        }

        public OrderResponseDTO GenerateOrder(int userId)
        {
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(b => b.UserID == userId);
            if (basket == null)
                return null;
            Order order = new Order
            {
                UserID = basket.UserID,
                Date = DateTime.Now,
                isPayed = false,
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            int? lastId = _context.Orders.Max(p => (int?)p.ID);
            if (lastId == null) lastId = 0;
            OrderPosition orderPosition = new OrderPosition
            {
                ProductID = basket.ProductID,
                Amount = basket.Amount,
                Price = basket.Price,
                OrderID = (int)lastId
            };
            order.Positions = new List<OrderPosition>();
            order.Positions.Add(orderPosition);
            _context.OrderPositions.Add(orderPosition);
            _context.SaveChanges();
            OrderResponseDTO responseDTO = new OrderResponseDTO
            {
                ID = order.ID,
                Date = order.Date,
                isPayed = false,
                UserID = basket.UserID,
                Positions = new List<OrderPositionResponseDTO>()
            };
            responseDTO.Positions.Add(new OrderPositionResponseDTO
            {   
                ID = orderPosition.ID,
                OrderID = orderPosition.OrderID,
                ProductID = orderPosition.ProductID,
                Amount = orderPosition.Amount,
                Price = orderPosition.Price,
            });
            return responseDTO;

        }

        public void pay(int userId, double value)
        {
            Order? order = _context.Orders.FirstOrDefault(o => o.UserID == userId);
            if(order == null) 
                return;
            double? sum = _context.OrderPositions.Where(o=>o.OrderID == order.ID).Sum(o=>o.Price);
            if (sum == null)
                return;
            if(Math.Abs(value - (double)sum)<0.001)
            {
                order.isPayed = true;
            }
            _context.SaveChanges();
        }

        public void removeProductFormBasket(int id)
        {
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(b=>b.UserID == id);
            if (basket == null) 
                return;
            _context.BasketPositions.Remove(basket);
            _context.SaveChanges();
        }
    }
}
