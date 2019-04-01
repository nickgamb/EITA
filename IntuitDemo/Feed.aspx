<%@ Page Title="Feed" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="IntuitDemo.Feed" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        function GetCategory() {
            var person = prompt("Enter a category for this issue.", "");
            if (person != null && person != "") {
                document.getElementById("<%=hdnUserInput.ClientID%>").value = person;
                return true;
            }
            else
                return false;
        }
    </script>
    <h2><%: Title %>.</h2>
    <h3>Feed of Recent Relevant Posts</h3>

    <div class="row">
        <asp:GridView ID="Issues" runat="server" AutoGenerateColumns="false"
            CellPadding="10"
            GridLines="Both"
            HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="lbltrack" runat="server" OnClick="TrackButtonClick" OnClientClick="return GetCategory();" Text='<%#Eval("Track") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Username">
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lbltext" runat="server" Text='<%#Eval("Text") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Tags">
                    <ItemTemplate>
                        <asp:Label ID="lblcategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Source">
                    <ItemTemplate>
                        <asp:Label ID="lblsource" runat="server" Text='<%#Eval("Source") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="col2" HeaderText="Post ID">
                    <ItemTemplate>
                        <asp:Label ID="lblguid" runat="server" Text='<%#Eval("GUID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField runat="server" ID="hdnUserInput" />
    </div>
</asp:Content>
