using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexmo.Api;
using NexmoDotnetCodeSnippets.Authentication;
namespace NexmoDotnetCodeSnippets.Senders
{
    public class NumberSender
    {
        public static Number.SearchResults ListOwnNumbers(string NUMBER_SEARCH_CRITERIA, string NUMBER_SEARCH_PATTERN)
        {
            var client = BasicAuth.GetClient();
            var response = client.Number.ListOwnNumbers(new Number.SearchRequest() 
            {
                pattern = NUMBER_SEARCH_CRITERIA,
                search_pattern = NUMBER_SEARCH_PATTERN
            });
            return response;
        }

        public static Number.SearchResults SearchNumbers(string COUNTRY_CODE, string NEXMO_NUMBER_TYPE, string NEXMO_NUMBER_FEATURES, string NUMBER_SEARCH_CRITERIA, string NUMBER_SEARCH_PATTERN)
        {
            var client = BasicAuth.GetClient();
            var response = client.Number.Search(new Number.SearchRequest()
            {
                country = COUNTRY_CODE,
                Type = NEXMO_NUMBER_TYPE,
                features = NEXMO_NUMBER_FEATURES,
                pattern = NUMBER_SEARCH_CRITERIA,
                search_pattern = NUMBER_SEARCH_PATTERN
            });
            return response;
        }
    }
}
