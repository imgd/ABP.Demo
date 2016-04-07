using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiNiuNetwork.CMS_NJL.Dapper.net
{
    public interface IDbConnectionFactory
    {
        string connstr { get; set; }

        IDbConnection _dbConnection { get; set; }

        IDbConnection GetDbConnection();

    }
}
