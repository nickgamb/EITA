<%@ Page Title="Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="IntuitDemo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function GetUserValue() {
            var person = prompt("Enter new JIRA link", "");
            if (person != null && person != "") {
                document.getElementById("<%=hdnUserInput.ClientID%>").value = person;
                return true;
            }
            else
                return false;
        }

        function ReplyToPost() {
            var person = prompt("This feature is under construction", "");
            if (person != null && person != "") {
                document.getElementById("<%=hdnReplyMessage.ClientID%>").value = person;
                return true;
            }
            else
                return false;
        }

        function ChangeCategory() {
            var person = prompt("Enter new category for this issue.", "");
            if (person != null && person != "") {
                document.getElementById("<%=hdnCategoryInput.ClientID%>").value = person;
                return true;
            }
            else
                return false;
        }
    </script>
    <h3>Currently Tracked Issues</h3>
    <br />
    <asp:GridView ID="TrackedIssues" DataKeyNames="GUID" OnRowDeleted="TrackedIssues_RowDeleted" OnRowDeleting="TrackedIssues_RowDeleting" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="ReplyButton" CommandArgument='<%# Eval("GUID") %>' CommandName="Reply" OnCommand="CommandBtn_Click" OnClientClick="return ReplyToPost();" runat="server">Reply</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="JiraButton" CommandArgument='<%# Eval("GUID") %>' CommandName="Jira" OnCommand="CommandBtn_Click" OnClientClick="return GetUserValue();" runat="server">JIRA</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="CategoryButton" CommandArgument='<%# Eval("GUID") %>' CommandName="Category" OnCommand="CommandBtn_Click" OnClientClick="return ChangeCategory();" runat="server">Category</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="DeleteButton" CommandArgument='<%# Eval("GUID") %>' CommandName="Delete" runat="server">Delete</asp:LinkButton>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hdnUserInput" />
    <asp:HiddenField runat="server" ID="hdnReplyMessage" />
    <asp:HiddenField runat="server" ID="hdnCategoryInput" />

</asp:Content>
