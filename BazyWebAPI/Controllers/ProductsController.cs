using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _products;
        public ProductsController(IProducts products)
        {
            this._products = products;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> getProducts()
        {
            return _products.getProducts(new GetProductsDTO());
        }

        [HttpGet("disable")]
        public void disableProduct(int id)
        {
            _products.disableProduct(id);
        }

        [HttpGet("enable")]
        public void enableProduct(int id)
        {
            _products.enableProduct(id);
        }

        [HttpDelete]
        public void removeProduct(int id)
        {
            _products.removeProduct(id);
        }

        [HttpPost]
        public void addProduct(ProductRequestDTO product)
        {
            _products.addProduct(product);
        }
    }
}
