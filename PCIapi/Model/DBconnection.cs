using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace PCIapi.Model
{
    public class DBconnection
    {
        private string connectionString;
        private IConfiguration _configuration;

        public DBconnection(IConfiguration configuration)
        {
            _configuration = configuration;          
            string kvURL = _configuration["AzureDBconnection:kvURL"];
            string tenantId = _configuration["AzureDBconnection:tenantId"]; ;
            string clientId = _configuration["AzureDBconnection:clientId"]; ;
            string ClientSecret = _configuration["AzureDBconnection:ClientSecret"]; ;
            var credential = new ClientSecretCredential(tenantId, clientId, ClientSecret);
            var client = new SecretClient(new Uri(kvURL), credential);
            string strsecretkey = client.GetSecret("ConnectionStrings--PCIDBconnection").Value.Value;
            connectionString = @strsecretkey;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IEnumerable<Ceremony> getScoresByCeremonyDetails(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select mc.CeremDesc,mga.ActivityDesc,mcp.CompValue,s.ScoreValue
                 from MstScore s  
                 Join MstGovKeyActivity mga
                 on s.ActivityID=mga.ActivityID
                 Join MstCeremony mc
                 on s.CeremID=mc.CeremID
                 Join MstCompliance mcp on
                 s.CompID=mcp.CompID";
                dbConnection.Open();
                return dbConnection.Query<Ceremony>(sQuery, new { _strCeremID = ID });
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
