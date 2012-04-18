<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Hydroserver.Models.DataServiceTable>" %>

    <table>
    <thead>
        <tr>
            <th>
                Data service name
            </th>
            <th>
                Server
            </th>
            <th>
                Topic
            </th>
            <th>
                Abstract
            </th>
        </tr>
    </thead>
    <% var zebra = true; %>
    
    <% foreach (var data in Model.Entries) { %>
    
        <% zebra = (zebra == false);  %>
        
        <tr style="background: <% if (zebra == false) {%>#fff<%} else {%>#abd<%} %>;">
            <td>
                <a href="<%=ResolveUrl("~/" + Model.ItemUrl + data.DatabaseID ) %>">
                    <strong><%=data.Title %></strong>
                </a>
            </td>
            <td>
                <i><%=data.ServerName %></i>
            </td>            
            <td>
                <%=data.Topic %>
            </td>
            <td>
                <%=data.Abstract %>
            </td>
        </tr>
    <%} %>
    
    </table>