using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IProducts
    {
        IEnumerable<ProductResponseDTO> getProducts(GetProductsDTO parameters);
        void addProduct(ProductRequestDTO product);
        void removeProduct(int id);
        void disableProduct(int id);
        void enableProduct(int id);

    }
}
