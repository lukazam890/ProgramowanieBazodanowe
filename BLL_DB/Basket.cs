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
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopSel;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public void addToBasket(BasketPositionRequestDTO basket)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec AddToBasket " + basket.UserID + ", " + basket.ProductID + ", " + basket.Amount + ", " + basket.Price;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec GenerateOrder " + userId;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(!reader.Read()) { throw new InvalidOperationException(); }
                OrderResponseDTO orderResponseDTO = new OrderResponseDTO
                {
                    ID = (int)reader["ID"],
                    Date = (DateTime)reader["Date"],
                    isPayed = (bool)reader["isPayed"],
                    UserID = (int)reader["UserID"],
                    Positions = new List<OrderPositionResponseDTO>()
                };
                OrderPositionResponseDTO orderPositionResponseDTO = new OrderPositionResponseDTO
                {
                    ID = (int)reader["ProductID"],
                    Amount = (int)reader["Amount"],
                    Price = (double)reader["Price"]
                };
                orderResponseDTO.Positions.Add(orderPositionResponseDTO);
                reader.Close();
                sqlCommand.Connection.Close();
                return orderResponseDTO;
            }
        }

        public void pay(int userId, double value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec Pay " + userId + ", " + value;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }

        public void removeProductFormBasket(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec RemoveFromBasket " + id; 
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }
    }
}
