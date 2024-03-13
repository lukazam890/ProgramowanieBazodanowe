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
        public void addToBasket(BasketPositionRequestDTO basket)
        {
            Product? product = _context.Products.FirstOrDefault(p=>p.ID==basket.ProductID);
            if (product == null || !product.IsActive)
                return;
            int? lastId = _context.BasketPositions.Max(p => (int?)p.ID);
            if (lastId == null) lastId = 0;
            BasketPosition basketTemp = new BasketPosition
            {
                ID = (int)lastId,
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
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(p => p.ID == id);
            if (basket == null) return;
            basket.Amount = numberOfProducts;
            _context.SaveChanges();
        }

        public OrderResponseDTO GenerateOrder(int userId)
        {
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(b => b.ID == userId);
            if (basket == null)
                return null;
            int? lastId = _context.Orders.Max(p => (int?)p.ID);
            if (lastId == null) lastId = 0;
            Order order = new Order
            {
                ID = (int)lastId,
                UserID = basket.UserID,
                Date = DateTime.Now,
                isPayed = false,
            };
            lastId = _context.OrderPositions.Max(p => (int?)p.ID);
            if (lastId == null) lastId = 0;
            OrderPosition orderPosition = new OrderPosition
            {
                ID = (int)lastId,
                ProductID = basket.ProductID,
                Amount = basket.Amount,
                Price = basket.Price,
                OrderID = order.ID,
            };
            order.Positions.Add(orderPosition);
            _context.SaveChanges();
            return new OrderResponseDTO
            {
                ID = order.ID,
                Date = order.Date,
                isPayed = false,
                UserID = basket.UserID,
            };
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
        }

        public void removeProductFormBasket(int id)
        {
            BasketPosition? basket = _context.BasketPositions.FirstOrDefault(b=>b.ID == id);
            if (basket == null) 
                return;
            _context.BasketPositions.Remove(basket);
            _context.SaveChanges();
        }
    }
}
