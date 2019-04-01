using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuthTwitterWrapper;
using OAuthTwitterWrapper.JsonTypes;
using Newtonsoft.Json;
using StackExchange.StacMan;

namespace IntuitDemoLib
{
    public class DataSources
    {
        public List<Posts> PostResults = new List<Posts>();

        /// <summary>
		/// The default constructor gets all enabled data source implementations
		/// </summary>
        public DataSources()
        {
            //Call data source implementations here
            GetTwitterResults();
            GetStackResults();
        }

        //Add Data source implementations here

        /// <summary>
		/// Twitter data source implementation
		/// </summary>
        public void GetTwitterResults()
        {
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            string rawSearchResults = oAuthTwitterWrapper.GetSearch();

            var searchResults = JsonConvert.DeserializeObject<Search>(rawSearchResults);

            foreach (var result in searchResults.Results)
            {
                Posts res = new Posts();
                res.Name = result.User.Name;
                res.PostText = result.Text;

                string[] hashtags = new string[result.entities.Hashtags.Count];

                //Parse hashtags
                for (int i = 0; i < result.entities.Hashtags.Count; i++)
                {
                    hashtags[i] = result.entities.Hashtags[i].Text;
                }

                //if hashtags are null, place in General category
                if (hashtags.Length != 0)
                {
                    res.Category = string.Join(", ", hashtags);
                }
                else
                {
                    res.Category = "General";
                }

                res.Source = "Twitter";
                res.GUID = result.id_str;

                PostResults.Add(res);
            }
        }

        /// <summary>
		/// Stack data source implementation
		/// </summary>
        public void GetStackResults()
        {
            var client = new StacManClient(key: ConfigurationManager.AppSettings["stackAppKey"], version: "2.1");

            var response = client.Questions.GetAll("stackoverflow",
            page: 1,
            pagesize: 10,
            sort: StackExchange.StacMan.Questions.AllSort.Creation,
            order: Order.Desc,
            filter: "withbody",
            tagged: ConfigurationManager.AppSettings["stackTags"]).Result;

            foreach (var question in response.Data.Items)
            {
                Posts res = new Posts();
                res.Name = question.Owner.DisplayName;
                res.PostText = question.Body;
                res.Category = string.Join(", ", question.Tags);

                //If tags are null, place in General category
                if (res.Category == "" || res.Category == null)
                {
                    res.Category = "General";
                }

                res.Source = "Stack Overflow";
                res.GUID = question.QuestionId.ToString();

                PostResults.Add(res);
            }

        }

        //Add new data source implementations here

    }

    public class Posts
    {
        public string Name { get; set; }
        public string PostText { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
        public string GUID { get; set; }
    }
}
