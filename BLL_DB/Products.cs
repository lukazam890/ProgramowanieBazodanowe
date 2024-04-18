using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class Products : IProducts
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopSel;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public void addProduct(ProductRequestDTO product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec AddProduct '" + product.Name + "', '"+ product.Image +"', "+ product.Price +", "+ product.GroupID;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }

        public void disableProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec DeactivateProduct " + id;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }
        public void enableProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec ActivateProduct " + id;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }

        public IEnumerable<ProductResponseDTO> getProducts(GetProductsDTO parameters)
        {
            List<ProductResponseDTO> list = new List<ProductResponseDTO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec ListOfProducts " + Convert.ToInt16(parameters.Sort).ToString() + ", " +
                    Convert.ToInt16(parameters.onlyActive);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    ProductResponseDTO prodDTO = new ProductResponseDTO
                    {
                        ID = (int)reader["ID"],
                        Name = reader["Name"].ToString(),
                        Price = (double)reader["Price"],
                        Image = reader["Image"].ToString(),
                        IsActive = (bool)reader["IsActive"],
                        GroupID = (int)reader["GroupID"]
                    };
                    list.Add(prodDTO);
                }
                reader.Close();
                sqlCommand.Connection.Close();
            }
            return list;
        }

        public void removeProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "exec RemoveProduct " + id;
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Connection.Close();
            }
        }
    }
}
