using BLL.DTOModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface Products
    {
        ProductResponseDTO getProducts(GetProductsDTO parameters);
        void addProduct(int idProduct, int count);
        void removeProduct(int id);
        void disableProduct(int id);
        void enableProduct(int id);

    }
}
