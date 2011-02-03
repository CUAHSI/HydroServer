<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HydroServer.Framework.Models.DataQueryModel>" %>

<table>
<thead>
    <tr>
        <th>
            Site
        </th>
        <th>
            Source
        </th>
        <th>
            Variable
        </th>
        <th>
            Total Values
        </th>
        <th>
            Download?
        </th>
    </tr>
</thead>
<% var zebra = true; int? values = 0; %>    

<% foreach (var item in Model.SeriesCatalog) { %>

<% zebra = (zebra == false);  %>

    <tr style="background: <% if (zebra == false) {%>#fff<%} else {%>#abd<%} %>;">
        <td>
            <%=Model.Sites.SingleOrDefault(s => (s.Site.SiteID == item.TimeSeries.SiteID) & (s.OdmDb == item.OdmDb)).Site.SiteName%>
        </td>
        <td>
            <%=Model.Sources.SingleOrDefault(s => (s.Source.SourceID == item.TimeSeries.SourceID) & (s.OdmDb == item.OdmDb)).Source.Organization%>
        </td>            
        <td>
            <% var thisVar = Model.Variables.SingleOrDefault(s => (s.Variable.VariableID == item.TimeSeries.VariableID) & (s.OdmDb == item.OdmDb)).Variable; %>
            <%=thisVar.VariableName%> (<%= thisVar.DataType %>)
        </td>
        <td>
            <%=item.TimeSeries.ValueCount %>                       
            <%values = values + item.TimeSeries.ValueCount; %>
        </td>
        <td>
            <input type="checkbox" name="<%=item.TimeSeries.SeriesID + "@" + item.OdmDb %>"></option>
        </td>
    </tr>
<%} %>
    <tr>
        <td colspan="4" style="text-align: right;">
            Total values: <%=values %><br />
            <strong>Check All:</strong>
        </td>
        <td>
            <input type="checkbox" id="checkAll" />
        </td>
    </tr>
    <script type="text/javascript">
        $(document).ready(function() {
            $('#checkAll').click(
                function() {
                    $("INPUT[type='checkbox']").attr('checked', $('#checkAll').is(':checked'));
                }
            )
        });
    </script>
</table>