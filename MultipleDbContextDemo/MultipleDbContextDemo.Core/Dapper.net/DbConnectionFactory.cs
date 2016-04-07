using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace HeiNiuNetwork.CMS_NJL.Dapper.net
{
    public class DbConnectionFactory : IDbConnectionFactory, ITransientDependency
    {
        public string connstr { get; set; }

        public DbConnectionFactory()
        {
            connstr = ConfigurationManager.ConnectionStrings["Default2"].ToString();            
        }

        public IDbConnection _dbConnection { get; set; }
        public IDbConnection GetDbConnection()
        {
            //if (_dbConnection==null)
            //{
            //    _dbConnection = new SqlConnection(connstr);
            //}
            //return _dbConnection;
            return new SqlConnection(connstr);
        }


    }
}
