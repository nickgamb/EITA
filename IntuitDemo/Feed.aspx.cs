using System;
using System.Web.UI;
using System.Data;
using IntuitDemoLib;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace IntuitDemo
{
    public partial class Feed : Page
    {
        //Initialize Issues Table
        static DataTable issueTable = new DataTable("Issues");
        static DataSet set = new DataSet("Posts");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Class inititation creates a list called PostResults filled with Posts 
                DataSources ds = new DataSources();

                //Loop post results from all data sources
                foreach (var post in ds.PostResults)
                {
                    Int32 Rcount = Convert.ToInt32(issueTable.Rows.Count);

                    //Make sure we create columns if needed
                    if (Rcount == 0)
                    {
                        issueTable.Columns.Add("Track");
                        issueTable.Columns.Add("Name");
                        issueTable.Columns.Add("Text");
                        issueTable.Columns.Add("Category");
                        issueTable.Columns.Add("Source");
                        issueTable.Columns.Add("GUID");
                        issueTable.Rows.Add("Track", post.Name, post.PostText, post.Category, post.Source, post.GUID);
                        set.Tables.Add(issueTable);
                    }
                    else
                    {
                        if (post.Name != "")
                        {
                            DataRow dr = issueTable.NewRow();
                            dr["Track"] = "Track";
                            dr["Name"] = post.Name;
                            dr["Text"] = post.PostText;
                            dr["Category"] = post.Category;
                            dr["Source"] = post.Source;
                            dr["GUID"] = post.GUID;
                            issueTable.Rows.Add(dr);
                        }
                    }
                }

                //Bind data to table
                Issues.DataSource = set;
                Issues.DataBind();
            }
        }

        protected void TrackButtonClick(object sender, System.EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            var UsernameObj = gvr.Cells[1].Controls[1];
            var DescObj = gvr.Cells[2].Controls[1];
            var SourceObj = gvr.Cells[4].Controls[1];
            var GuidObj = gvr.Cells[5].Controls[1];

            string userName = ((Label)UsernameObj).Text;
            string description = ((Label)DescObj).Text;
            string source = ((Label)SourceObj).Text;
            string guid = ((Label)GuidObj).Text;

            StreamReader r = new StreamReader(Server.MapPath("~/tracking.txt"));           
            string json = r.ReadToEnd();
            List<Issue> trackedIssues = JsonConvert.DeserializeObject<List<Issue>>(json);

            bool containsItem = trackedIssues.Any(item => item.GUID == guid);

            if (!containsItem)
            {
                trackedIssues.Add(new Issue()
                {
                    Username = userName,
                    Description = description,
                    Source = source,
                    GUID = guid,
                    JIRA = "",
                    Category = hdnUserInput.Value
                });
            }

            r.Dispose();

            //open file stream
            StreamWriter file = File.CreateText(Server.MapPath("~/tracking.txt"));
            
            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, trackedIssues);
            file.Dispose();
            
        }
    }

    public class Issue
    {
        public string Username { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string GUID { get; set; }
        public string JIRA { get; set; }
        public string Category { get; set; }

    }
}