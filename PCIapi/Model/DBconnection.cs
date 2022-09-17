using System.Data;
using System.Data.SqlClient;

namespace PCIapi.Model
{
    public class DBconnection
    {
        private string connectionString;
        public DBconnection()
        {
            //connectionString = @"Persist Security Info=False;User ID=sa;password=sa;Initial Catalog=PYT; Data Source=RAJIBBASU-PC\SQLEXPRESS;Connection Timeout=100000;";
            connectionString = @"Persist Security Info=False;User ID=pcidb;password=pc1@DB@#!!;Initial Catalog=pciDB; Data Source=pciproject.database.windows.net;Connection Timeout=100000;";

        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
