using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IQueryExecuter
    {
        IEnumerable<T> Query<T>(string sql, object param = null, string connectionStringName = null);
        T Scalar<T>(string sql, object param = null, string connectionStringName = null);
    }
}
