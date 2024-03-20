using BLL.DTOModels;
using BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class Products : IProducts
    {
        public void addProduct(ProductRequestDTO product)
        {
            throw new NotImplementedException();
        }

        public void disableProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void enableProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> getProducts(GetProductsDTO parameters)
        {
            throw new NotImplementedException();
        }

        public void removeProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
