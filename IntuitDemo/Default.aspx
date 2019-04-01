<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IntuitDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Example Issue Tracker Application</h1>
        <p class="lead">Demonstration of the Example Issue Tracker Application for Intuit</p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>The Feed</h2>
            <p> • The Example Issue Tracker Application aggregates recent posts from supported social media sources and displays them in the Feed. </p>
            <p> • From the Feed, raw posts can be selected and "tracked," which writes them to the locally stored tracking.json. </p>          
            <p>
                <a class="btn btn-default" href="~/Feed">Feed &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Tracking</h2>
            <p> • The Tracking menu reads from the locally stored tracking.json file and displays the tracked issues. </p>
            <p> • Issues in the Tracking menu have a reply option which can be used to draft a reply, via the source platform, to respond to the original post. (Under Construction)</p>
            <p> • Issues in the Tracking menu have a column for associated JIRA bugs/stories which can be used by PM to track issue resolution. </p>
            <p> • Using the JIRA action, the JIRA column can be updated.</p>
            <p> • Issues can be removed from the Tracking menu via the Delete button. </p>           
            <p>
                <a class="btn btn-default" href="~/Tracking">Tracking &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sources and Libraries</h2>
            <p> • Currently, Twitter and Stack Overflow are the supported sources. </p>
            <p> • Sources can be easily added via the IntuitDemoLib Library. </p>
            <p> • <a href="https://github.com/andyhutch77/oAuthTwitterWrapper">oAuthTwitterWrapper</a> library was used as a client for the Twitter API's. </p>
            <p> • <a href="https://github.com/emmettnicholas/StacMan">StacMan</a> library was used as a client for the Stack API's. </p>
            <p> • <a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft.Json</a> library was used to easily handle JSON. </p>            
        </div>
    </div>
</asp:Content>

