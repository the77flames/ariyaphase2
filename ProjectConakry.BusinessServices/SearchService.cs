using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace ProjectConakry.BusinessServices
{
    public class SearchService<T> : ISearchService<T> where T : class
    {
        private HashSet<string> _noiseWords;
        private static Dictionary<string, string> _searchReplacements;
        private static IEnumerable<T> dataStore;

        public SearchService()
        {
            
        }
        public SearchService(Func<IEnumerable<T>> dataFetcher)
        {
            dataStore = (dataStore == null || !dataStore.Any()) ? dataFetcher() : dataStore;
            _noiseWords = new HashSet<string> { "and", "or", "with", "by", "where", "why", "is", "was" };
            _searchReplacements = new Dictionary<string, string> { };

        }
        
        public IEnumerable<T> Search<T2>(string query, int startIndex, int? setSize, Dictionary<string, IEnumerable<T2>> propertyKeyValues)
        {
           
            var searchTerms = String.IsNullOrEmpty(query) ? null : RemoveNoiseWords(query);

            if (propertyKeyValues != null && propertyKeyValues.Any())
            {               
               
                foreach(var propertyName in propertyKeyValues.Keys)
                {
                    var propertyValues = propertyKeyValues[propertyName];
                    if (propertyValues == null || !propertyValues.Any(a => !string.IsNullOrEmpty(a.ToString())))
                        continue;
                    HashSet<T2> propertyValuesHolder = new HashSet<T2>(propertyValues);
                    if (typeof(T).GetProperties().Any(n => n.Name.ToLower() == propertyName.ToLower()))
                        dataStore = FilterDataByProperty<T, T2>(dataStore, propertyValuesHolder, propertyName.ToLower());
                          

                }               
            }
                                        

            if (searchTerms == null || !searchTerms.Any())
                return dataStore.Skip(startIndex).Take(setSize??dataStore.Count());

            var result = new List<T>();
            var searchTermsEnumerator = searchTerms.GetEnumerator();
            // 'for loop' is faster than 'foreach'and iterating an array is 2x cheaper than iterating a list. 
            //  i.e. using 'for' on an array is 5x than using 'foreach' on a list
            var dataSetAfterSkip = dataStore.Skip(startIndex).ToArray();
            while (searchTermsEnumerator.MoveNext())
            {

                for (int i = 0; i < dataSetAfterSkip.Length; i++ )
                {
                    if (IsMatch<T>(dataSetAfterSkip[i], searchTermsEnumerator.Current))
                    {
                        if (!result.Contains(dataSetAfterSkip[i]))
                            result.Add(dataSetAfterSkip[i]);
                    }
                }
            }

            return result.Take(setSize ?? dataStore.Count());

        }

        protected internal IEnumerable<T> FilterDataByProperty<T, T2>(IEnumerable<T> data, HashSet<T2> propertyValues, string propertyName)
        {
            var filteredResult = new List<T>();
            if (!propertyValues.Any())
               return data;
            var dataEnumerator = data.GetEnumerator();
            var specificProperty = typeof(T).GetProperties().FirstOrDefault(n => n.Name.ToLower() == propertyName);
            while (dataEnumerator.MoveNext())
            {
                var holder = specificProperty.GetValue(dataEnumerator.Current);
                if (holder != null && (typeof(T2) == typeof(String) ? propertyValues.Any(n => n.ToString().ToLower() == holder.ToString().ToLower()) : propertyValues.Contains((T2)holder)))
                    filteredResult.Add(dataEnumerator.Current);
            }
            return filteredResult;
        }

      
        public IEnumerable<T> MatchStringInProperty<T>(IEnumerable<T> data, HashSet<string> propertyValues, string propertyName)
        {
            var filteredResult = new List<T>();
            if (!propertyValues.Any())
                return data;
            var dataEnumerator = data.GetEnumerator();
            var specificProperty = typeof(T).GetProperties().FirstOrDefault(n => n.Name.ToLower() == propertyName.ToLower());
            while (dataEnumerator.MoveNext())
            {
                var holder = specificProperty.GetValue(dataEnumerator.Current);
                if (holder != null && propertyValues.Any(n => holder.ToString().ToLower().Contains( n.ToString().ToLower())))
                    filteredResult.Add(dataEnumerator.Current);
            }
            return filteredResult;
        }

        protected internal bool IsMatch<T>(T referenceObject, string searchTerm)
        {
            bool isMatch = false;
            var allProperties = typeof(T).GetProperties();
            foreach (var property in allProperties)
            {
                if (property.GetValue(referenceObject) != null && property.GetValue(referenceObject).ToString().ToLower().Contains(searchTerm.ToLower()))
                    isMatch = true;
            }
            return isMatch;
        }

        protected internal IEnumerable<string> RemoveNoiseWords(string query)
        {
            foreach (var searchTerm in query.Trim().Split(new char[] { ' ', ',' }))
            {
                if (!_noiseWords.Contains(searchTerm))
                    yield return searchTerm;
            }
        }


    }

   
}
