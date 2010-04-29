<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HISServer.Framework.Models.DataServiceTable>" %>

    <table width=100%>
        
    <% foreach (var data in Model.Entries) { %>  
        <tr>
            <td>
                <strong>Title:</strong>  <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>"><strong><%=data.Title %></strong></a><br />
                <strong>Map Server Name:</strong>  <%=data.ServerName %><br />
                <strong>Topic:</strong>  <%=data.Topic %><br />
                <br />
                <strong>Abstract:</strong> <%=data.Abstract %><br />
                <br />
                <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>">View Details</a>
            </td>
        </tr>
    <%} %>
    
    </table>