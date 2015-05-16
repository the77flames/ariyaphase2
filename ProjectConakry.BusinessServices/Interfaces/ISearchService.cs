using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ProjectConakry.BusinessServices
{
    public interface ISearchService<T>
    {
        IEnumerable<T> Search<T2>(string query, int startIndex, int? setSize, Dictionary<string, IEnumerable<T2>> propertyKeyValues);
    }
}
