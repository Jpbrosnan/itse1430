
using System.Data;
using System.Data.SqlClient;

namespace Nile.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {

        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        protected abstract Product GetCore ( int id );

        protected abstract IEnumerable<Product> GetAllCore ();

        protected abstract void RemoveCore ( int id );

        protected abstract Product UpdateCore ( Product existing, Product newItem );

        protected abstract Product AddCore ( Product product );

        protected abstract Product FindProduct ( int id );

        protected abstract Product FindByName ( string name );

        private SqlConnection OpenConnection ()
        {
            var conn = new GetConnectionString(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}