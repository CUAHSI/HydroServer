<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HydroServer.Framework.Models.DataServiceTable>" %>

    <table width=100%>
        
    <% foreach (var data in Model.Entries) { %>  
        <tr>
            <td>
                <strong>Title:</strong>  <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>"><strong><%=data.Title %></strong></a><br />
                <strong>Server Name:</strong>  <%=data.ServerName %><br />
                <strong>Topic:</strong>  <%=data.Topic %><br />
                <br />
                <strong>Abstract:</strong> <%=data.Abstract %><br />
                <br />
                <strong>Citation:</strong> <%=data.Citation %><br />
                <br />
                <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>">View Details</a> 
                |
                <a target="_blank" href="<%=ResolveUrl(System.Configuration.ConfigurationManager.AppSettings["TSALocation"] ) + "?Database=" + data.DatabaseName %>">Launch Time Series Analyst</a>
            </td>
        </tr>
    <%} %>
    
    </table>