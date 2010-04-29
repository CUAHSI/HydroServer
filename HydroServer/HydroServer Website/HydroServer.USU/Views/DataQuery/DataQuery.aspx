<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HydroServer.Framework.Models.DataQueryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Data Query/Download
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/timepicker/timepicker.js") %>"></script>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Data Query Tool</h2>
    <p>On this page you can select and download observational data from any of the regions that are hosted on this server.  Simply
    select one or more regions below and then select one or more variables that you are interested in.  Alternatively, you can input
    a search term for variables in the "other variable" text box.</p>
    <form method="post">
        <p>
            <label for="RegionIDs">Regions:</label><br />
            <select size="5" id="RegionIDs" name="RegionIDs" multiple="multiple" class="disallowDownload" >
            <% foreach (var item in Model.Regions) { %>
                <option value="<%=item.Region.RegionID + "@" + item.OdmDb %>"<%if (Model.DataQueryForm.RegionIDs.Any(s => (s.ID == item.Region.RegionID))) { %> selected<%} %>>
                    <%=item.Region.RegionName %>
                </option>
            <%} %>
            </select>
        </p>        
        <p>
            <label for="VariableIDs">Variables:</label><br />
            <select size="5" id="VariableIDs" name="VariableIDs" multiple="multiple" class="disallowDownload" >
                <option value="None"<%if (Model.DataQueryForm.VariableIDs.Count() == 0) { %> selected<%} %>>(Other)</option>
            <% foreach (var item in Model.Variables) { %>
                <option value="<%=item.Variable.VariableID + "@" + item.OdmDb %>"<%if (Model.DataQueryForm.VariableIDs.Any(s => (s.ID == item.Variable.VariableID) & (s.OdmDb == item.OdmDb))) { %> selected<%} %>>
                    <%=item.Variable.VariableName %>, <%=item.Variable.Unit.UnitsName %> (<%=item.Variable.DataType %>) [<%=item.Variable.VariableCode %>]
                </option>
            <%} %>            
            </select>
        </p>  
        <p>
            <label for="CustomVariable">Other Variable:</label>
            <input name="CustomVariable" id="CustomVariable" value="<%=Model.DataQueryForm.CustomVariable ?? "" %>" class="disallowDownload" />
        </p>
        <p>
            <input type="submit" name="submit" value="Query" checked="checked" />
        </p>

        <% if (Model.SeriesCatalog.Count > 0) { %>               
            <% Html.RenderPartial("~/[Embedded Resource]/HydroServer.Framework.Views.DataQuery.DataQueryTable.ascx", Model); %>
            
            <div id="allowDownload">
                <p>
                    <strong>Date/time range:</strong>
                    <label for="StartTime">Start:</label>
                    <input id="StartTime" name="StartTime" value="<%= Model.DataQueryForm.StartTime.ToString() %>" class="datepicker" />
                    <label for="EndTime">End:</label>
                    <input id="EndTime" name="EndTime" value="<%= Model.DataQueryForm.EndTime.ToString() %>" class="datepicker" />
                </p>
                <p>
                    <strong>Fields to include:</strong>
                    <input type="checkbox" checked="checked" name="selectUnit">Unit</option>
                    <input type="checkbox" checked="checked" name="selectVariable">Variable Name</option>
                    <input type="checkbox" checked="checked" name="selectSite">Site Name</option>
                    <input type="checkbox" checked="checked" name="selectSource">Source Name</option>                
                    <input type="checkbox" checked="checked" name="selectMethod">Method</option>
                    <input type="checkbox" checked="checked" name="selectSample">Sample</option>
                    <input type="checkbox" checked="checked" name="selectQualityControlLevel">Quality Control Level</option>
                </p>
            
                <p><input type="submit" name="submit" value="Download" /></p>
            </div>        
            
        <%} else {%>       
            <strong style="color: #f00;"><%=ViewData["norecords"] %></strong>
        <%} %>
        
    </form>
    <script type="text/javascript">
        $(document).ready(function() {
            $(".datepicker").datepicker({
                duration: '',
                showTime: true,
                constrainInput: false,
                stepMinutes: 1,
                stepHours: 1,
                altTimeField: '',
                time24h: false
            });

            $(".disallowDownload").click(function() {
                $("#allowDownload").empty();
                $("#allowDownload").append("<p><strong style='color:#f00;'>You've changed the selected parameters; please re-query to download data.</strong></p>");
            });

            $(".disallowDownload").change(function() {
                $("#allowDownload").empty();
                $("#allowDownload").append("<p><strong style='color:#f00;'>You've changed the selected parameters; please re-query to download data.</strong></p>");
            });
        });
    </script>
</asp:Content>
