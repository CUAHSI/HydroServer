<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HydroServer.Framework.Models.DataServiceTable>" %>

    <table width=100%>
        
    <% foreach (var data in Model.Entries) { %>  
        <tr>
            <td>
                <strong>Title:</strong>  <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>"><strong><%=data.Title %></strong></a><br />
                <strong>Server Name:</strong>  <%=data.ServerName %><br />
                <strong>Topic:</strong>  <%=data.Topic %><br />
                <strong>Abstract:</strong> <%=data.Abstract %><br />
                <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>">View Details</a>
            </td>
        </tr>
    <%} %>
    
    </table>