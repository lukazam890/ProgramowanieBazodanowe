using BLL.DTOModels;
using BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class Basket : IBasket
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public void addToBasket(BasketPositionRequestDTO basket)
        {
            throw new NotImplementedException();
        }

        public void changeNumberOfProducts(int id, int numberOfProducts)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec ChangeNumber " + id + ", " + numberOfProducts;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
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
