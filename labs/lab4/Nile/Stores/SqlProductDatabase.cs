/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;



namespace Nile.Stores
{
    /// <summary>Provides an implementation of <see cref="IProductDatabase"/> using Microsoft SQL Server.</summary>
    public class SqlProductDatabase : ProductDatabase
    {
        /// <summary>Initializes an instance of the <see cref="SqlProductDatabase"/> class. Uses provided connection string to allow access the database.</summary>
        /// <param name="connectionString">Connection string provided by the program.cs GetConnectionString function</param>
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        #region Overridden Functions
        /// <inheritdoc />
        protected override Product GetCore ( int id )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("GetProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Product() {
                    Id = reader.GetInt32("Id"), 
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal("Price"),
                    Description = reader.IsDBNull("Description") ? "" : reader.GetFieldValue<string>("Description"),
                    IsDiscontinued = reader.GetBoolean("IsDiscontinued"),
                };
            };

            return null;

        }

        /// <inheritdoc />
        protected override IEnumerable<Product> GetAllCore ()
        {
            using var conn = OpenConnection();

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
                        
                        Id = row.Field<int>("Id"),
                        Name = row.Field<string>(1),
                        Price = row.Field<decimal>("Price"),
                        Description = row.IsNull("Description") ? "" : row.Field<string>("Description"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                    });
                  
                };
            }
            return products;
        }

        /// <inheritdoc />
        protected override void RemoveCore ( int id )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("RemoveProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        /// <inheritdoc />
        protected override Product UpdateCore ( Product existing, Product newItem )
        {

            using var conn = OpenConnection();

            var cmd = new SqlCommand("UpdateProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@id",existing.Id);
            cmd.Parameters.AddWithValue("@name", newItem.Name);   
            cmd.Parameters.AddWithValue("@price", newItem.Price);
            cmd.Parameters.AddWithValue("@description", newItem.Description);
            cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);

            cmd.ExecuteNonQuery();
            newItem.Id = existing.Id;
            return newItem;


        }

        /// <inheritdoc />
        protected override Product AddCore ( Product product )
        {
            using var conn = OpenConnection();
           
            var cmd = new SqlCommand("AddProduct", conn) { CommandType = CommandType.StoredProcedure };
           
            cmd.Parameters.AddWithValue("@name", product.Name);   
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@description", product.Description);
            cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

            //Execute and get single product ID back
            product.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return product;
        }

        /// <inheritdoc />
        protected override Product FindProduct ( int id ) => GetCore(id);

        /// <inheritdoc />
        protected override Product FindByName ( string name )
        {
            using var conn = OpenConnection();

            var cmd = new SqlCommand("FindProductsByName", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@name", name);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Product() {
                    Id = reader.GetInt32("Id"), 
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal("Price"),
                    Description = reader.IsDBNull("Description") ? "" : reader.GetFieldValue<string>("Description"),
                    IsDiscontinued = reader.GetBoolean("IsDiscontinued"),
                };
            };

            return null;
        }
        #endregion

        #region Private Members

        /// <summary>
        /// Uses the connection string provided to open a connection to the SQL Server
        /// </summary>
        /// <returns>Opened SqlConnection</returns>
        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
        #endregion
    }
}