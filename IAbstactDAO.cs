using System;
using System.Data;

namespace Assessment1_ADO.NET
{
    public interface IAbstactDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}
