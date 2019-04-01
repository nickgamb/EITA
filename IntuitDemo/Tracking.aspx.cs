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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StreamReader r = new StreamReader(Server.MapPath("~/tracking.txt"));
                string json = r.ReadToEnd();
                r.Dispose();

                List<Issue> trackedIssues = JsonConvert.DeserializeObject<List<Issue>>(json);

                TrackedIssues.DataSource = trackedIssues;
                TrackedIssues.DataBind();

            }
        }

        protected void CommandBtn_Click(Object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {

                case "Reply":
                    SendReply(e.CommandArgument.ToString());
                    break;

                case "Jira":
                    SaveRecordByID(e.CommandArgument.ToString());
                    break;

                case "Category":
                    EditCategoryByID(e.CommandArgument.ToString());
                    break;
                default:
                    break;
            }
        }

        protected void TrackedIssues_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }
        protected void TrackedIssues_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DeleteRecordByID(TrackedIssues.DataKeys[e.RowIndex].Value.ToString());
        }

        private void DeleteRecordByID(string guid)
        {
            StreamReader r = new StreamReader(Server.MapPath("~/tracking.txt"));
            string json = r.ReadToEnd();
            List<Issue> trackedIssues = JsonConvert.DeserializeObject<List<Issue>>(json);

            trackedIssues.RemoveAll(l => l.GUID == guid);

            r.Dispose();

            //open file stream
            StreamWriter file = File.CreateText(Server.MapPath("~/tracking.txt"));

            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, trackedIssues);
            file.Dispose();

            TrackedIssues.DataSource = trackedIssues;
            TrackedIssues.DataBind();

        }

        private void SaveRecordByID(string guid)
        {
            StreamReader r = new StreamReader(Server.MapPath("~/tracking.txt"));
            string json = r.ReadToEnd();
            List<Issue> trackedIssues = JsonConvert.DeserializeObject<List<Issue>>(json);

            //trackedIssues.RemoveAll(l => l.GUID == guid);
            int index = trackedIssues.FindIndex(m => m.GUID == guid);
            if (index >= 0)
            {
                trackedIssues[index].JIRA = hdnUserInput.Value;
            }

            r.Dispose();

            //open file stream
            StreamWriter file = File.CreateText(Server.MapPath("~/tracking.txt"));

            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, trackedIssues);
            file.Dispose();

            TrackedIssues.DataSource = trackedIssues;
            TrackedIssues.DataBind();
        }

        private void EditCategoryByID(string guid)
        {
            StreamReader r = new StreamReader(Server.MapPath("~/tracking.txt"));
            string json = r.ReadToEnd();
            List<Issue> trackedIssues = JsonConvert.DeserializeObject<List<Issue>>(json);

            //trackedIssues.RemoveAll(l => l.GUID == guid);
            int index = trackedIssues.FindIndex(m => m.GUID == guid);
            if (index >= 0)
            {
                trackedIssues[index].Category = hdnCategoryInput.Value;
            }

            r.Dispose();

            //open file stream
            StreamWriter file = File.CreateText(Server.MapPath("~/tracking.txt"));

            JsonSerializer serializer = new JsonSerializer();
            //serialize object directly into file stream
            serializer.Serialize(file, trackedIssues);
            file.Dispose();

            TrackedIssues.DataSource = trackedIssues;
            TrackedIssues.DataBind();
        }

        private void SendReply(string guid)
        {
            //TODO: Add ability to send reply to OP
            //Post message to source
            //Store message in DB

        }
    }
}
