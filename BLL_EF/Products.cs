using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class Products : IProducts
    {
        private readonly WebshopContext _context;
        public void addProduct(ProductRequestDTO product)
        {
            if (product.Price < 0)
                return;
            int? lastId = _context.Products.Max(p => (int?)p.ID);
            if (lastId == null) lastId = 0;
            Product productTemp = new Product {
                ID = (int)lastId+1, 
                Name = product.Name, 
                Price = product.Price, 
                Image = product.Image, 
                IsActive = product.IsActive,
                GroupID = product.GroupID
            };
            _context.Products.Add(productTemp);
            _context.SaveChanges();
        }

        public void disableProduct(int id)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                product.IsActive = false;
                _context.SaveChanges();
            }
        }

        public void enableProduct(int id)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                product.IsActive = true;
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductResponseDTO> getProducts(GetProductsDTO parameters)
        {
            List<Product> products;
            if(parameters.nameFilter != null)
                products = _context.Products.Include(p=>p.Group).ThenInclude(g=>g.Parent).Where(p=>p.Name.Contains(parameters.nameFilter)).ToList();
            else if(parameters.groupNameFilter != null)
                products = _context.Products.Include(p=>p.Group).ThenInclude(g => g.Parent).Where(p => p.Group.Name.Contains(parameters.groupNameFilter)).ToList();
            else if(parameters.idGroupFilter != null)
                products = _context.Products.Include(p=>p.Group).ThenInclude(g => g.Parent).Where(p=>p.Group.ID==parameters.idGroupFilter).ToList();
            else
                products = _context.Products.Include(p=>p.Group).ThenInclude(g => g.Parent).ToList();
            if(parameters.onlyActive)
                products.Where(p=>p.IsActive).ToList();
            switch (parameters.Sort)
            {
                case SortBy.NameAsc:
                    products = products.OrderBy(p=> p.Name).ToList();
                    break;
                case SortBy.NameDesc:
                    products = products.OrderByDescending(p=> p.Name).ToList();
                    break;
                case SortBy.PriceAsc:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case SortBy.PriceDesc:
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case SortBy.GroupNameAsc:
                    products = products.OrderBy(p => p.Group.Name).ToList();
                    break;
                case SortBy.GroupNameDesc:
                    products = products.OrderByDescending(p => p.Group.Name).ToList();
                    break;
            }
            List<ProductResponseDTO> dtoList = new List<ProductResponseDTO>();
            products.ForEach(p => dtoList.Add(new ProductResponseDTO
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
                IsActive = p.IsActive,
                GroupID = p.GroupID
            }));
            return dtoList;
        }

        public void removeProduct(int id)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
