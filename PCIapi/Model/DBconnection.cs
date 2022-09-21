using System;
using System.Data;
using System.Data.SqlClient;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace PCIapi.Model
{
    public class DBconnection
    {
        private string connectionString;
        public DBconnection()
        {
            //connectionString = @"Persist Security Info=False;User ID=pcidb;password=pc1@DB@#!!;Initial Catalog=pciDB; Data Source=pciproject.database.windows.net;Connection Timeout=100000;";



            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            connectionString = configuration.GetConnectionString("PCIDBconnection");

        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }

    public class Settings
    {
        public string AppName { get; set; }
        public double Version { get; set; }
        public long RefreshRate { get; set; }
        public long FontSize { get; set; }
        public string Language { get; set; }
        public string Messages { get; set; }
        public string BackgroundColor { get; set; }
    }

}
