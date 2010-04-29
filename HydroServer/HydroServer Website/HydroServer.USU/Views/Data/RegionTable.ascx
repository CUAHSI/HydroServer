<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HydroServer.Framework.Models.DataServiceTable>" %>

    <table width=100%>
       
    <% foreach (var data in Model.Entries) { %>
          
        <tr>
            <td>
                <strong>Title:</strong>  <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>"><strong><%=data.Title %></strong></a><br />
                <strong>Name:</strong>  <%=data.Topic %><br />
                <strong>Description:</strong>  <%=data.Abstract %><br />
                <br />
                <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>">View Details</a>
                |
                <a target="_blank" href="<%=ResolveUrl(System.Configuration.ConfigurationManager.AppSettings["MapLocation"] ) + "?Region=" + data.Topic %>">Launch Map</a>
            </td>
        </tr>
    <%} %>
    
    </table>