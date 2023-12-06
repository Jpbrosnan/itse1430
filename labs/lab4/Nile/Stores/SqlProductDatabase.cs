
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Nile.Stores
{
    public class SqlProductDatabase : ProductDatabase
    {

        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected override Product GetCore ( int id )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("GetProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Product() {
                    //Id = reader.GetInt32(0), //Approach 1
                    Id = reader.GetInt32("Id"), //Approach - preferred
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal("Price"),
                    Description = reader.IsDBNull("Description") ? "" : reader.GetFieldValue<string>("Description"),
                    IsDiscontinued = reader.GetBoolean("IsDiscontinued"),
                };
            };

            return null;

        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            //Open connection, do work, close connection
            using var conn = OpenConnection();

            //Buffered IO using DataSet and SqlDataAdapter
            //DataSet
            // In-memory database that supports CRUD operations on data
            // Discoverable schema
            // Supports multiple tables
            // Can make changes and push them back to database
            // Provides a "business layer" for applications that don't need one
            var ds = new DataSet();
            var da = new SqlDataAdapter() {
                SelectCommand = new SqlCommand("GetAllProducts", conn) { CommandType = CommandType.StoredProcedure },
            };
            da.Fill(ds);

            //Enumerate dataset
            var products = new List<Product>();

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    products.Add(new Product() {
                        /*
                        //Id = Convert.ToInt32(row[0]),  //Approach 1
                        Id = Convert.ToInt32(row["Id"]),    //Approach 2
                        Name = row.Field<string>(1),       //Approach 3
                        Price = row.Field<decimal>("Price"),
                        Description = row.IsNull("Description") ? "" : row.Field<string>("Description"), //Approach 4 - preferred
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                        */
                        Id = row.Field<int>("Id"),
                        Name = row.Field<string>(1),
                        Price = row.Field<decimal>("Price"),
                        Description = row.IsNull("Description") ? "" : row.Field<string>("Description"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    });
                  
                };
            };

            //conn.Close();
            return products;
        }

        protected override void RemoveCore ( int id )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("RemoveProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {

            using var conn = OpenConnection();

            //Approach 1 - preferred
            var cmd = new SqlCommand("UpdateProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id",existing.Id);
            cmd.Parameters.AddWithValue("@name", newItem.Name);   //Approach 2, only works with SQL
            cmd.Parameters.AddWithValue("@price", newItem.Price);
            cmd.Parameters.AddWithValue("@description", newItem.Description);
            cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

            cmd.ExecuteNonQuery();
            return newItem;


        }

        protected override Product AddCore ( Product product )
        {
            using var conn = OpenConnection();

            //Approach 1 - preferred
            var cmd = new SqlCommand("AddProduct", conn) { CommandType = CommandType.StoredProcedure };
            //cmd = conn.CreateCommand();  Approach 2
            //cmd.CommandText = "AddMovie";

            //Avoid SQL injection attacks, use parameters
            //var parmName = cmd.Parameters.Add("@name", SqlDbType.VarChar);  //Approach 1
            //parmName.Value = movie.Title;

            cmd.Parameters.AddWithValue("@name", product.Name);   //Approach 2, only works with SQL
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

            //cmd.Parameters.Add(new SqlParameter("@name", movie.Title));//Approach 3 - if you're desperate

            //Execute and get single product ID back
            product.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return product;
        }

        protected override Product FindProduct ( int id ) => GetCore(id);

        protected override Product FindByName ( string name )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("FindProductsByName", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@name", name);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Product() {
                    //Id = reader.GetInt32(0), //Approach 1
                    Id = reader.GetInt32("Id"), //Approach - preferred
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal("Price"),
                    Description = reader.IsDBNull("Description") ? "" : reader.GetFieldValue<string>("Description"),
                    IsDiscontinued = reader.GetBoolean("IsDiscontinued"),
                };
            };

            return null;
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}