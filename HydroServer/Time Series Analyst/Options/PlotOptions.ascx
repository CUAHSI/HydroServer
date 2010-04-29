<%@ Control Language="vb" AutoEventWireup="false" CodeFile="PlotOptions.ascx.vb" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" Inherits="OptionsPlotOptions" %>
<table id="optionsTable">
    <tr>
        <td id="optionsCell">
            <div class="groupLabel" style="width: 35px">
                Options</div>
            <table id="outerTable">
                    <tr>
                        <td class="groupCell" valign="top">
                        <asp:Panel id="pnlOptionsScroll" runat="server" ScrollBars="vertical" Height="330px">
                            <div class="groupLabel" style="width: 59px">
                                Time&nbsp;Series
                            </div>
                            <table class="groupTable" style="width: 100%">
                                <tr>
                                    <td class="groupCell">
                                        Plot Type<br/>
                                        <asp:RadioButtonList id="rblTimeSeries" RepeatDirection="Horizontal" AutoPostBack="True" runat="server">
                                            <asp:ListItem Value="line" >Line&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="point" >Point&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="both" Selected="true" >Both&nbsp;&nbsp;</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <table width="100%">
                                            <tr>
                                                <td style="width:100%">
                                                    Control Line
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton id="lnkApply" runat="server">
														<img src="images/apply.gif" width="35" height="15" style="border:0" alt="Apply Control Line" title="Apply Control Line" onmouseover="changeImages('apply', 'images/apply-over.gif'); return true;" onmouseout="changeImages('apply', 'images/apply.gif'); return true;"/>
													</asp:LinkButton>
                                                </td>
                                                <td align="right" style="padding-left: 5px">
                                                    <asp:LinkButton id="lnkCancel" runat="server">
														<img src="images/clear.gif" width="35" height="15" style="border:0" alt="Clear Control Line" title="Apply Control Line" onmouseover="changeImages('clear', 'images/clear-over.gif'); return true;" onmouseout="changeImages('clear', 'images/clear.gif'); return true;"/>
													</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="margin-top: 4px">
                                            <tr>
                                                <td class="inputLabel" style="padding-left: 10px">
                                                    Label
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtLabel" CssClass="formElement" Width="110" TextMode="SingleLine" MaxLength="50" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inputLabel" style="padding-left: 10px">
                                                    Value
                                                </td>
                                                <td>
                                                    <asp:TextBox id="txtValue" CssClass="formElement" Width="40" TextMode="SingleLine" MaxLength="10" runat="server" />
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td class="inputLabel" style="padding-left: 10px">
                                                    Color
                                                </td>
                                                <td style="padding-top: 1px">
                                                    <asp:DropDownList id="cboColor" CssClass="formElement" runat="server" Width="110">
                                                        <asp:ListItem Value="Black">Black</asp:ListItem>
                                                        <asp:ListItem Value="Blue">Blue</asp:ListItem>
                                                        <asp:ListItem Value="Brown">Brown</asp:ListItem>
                                                        <asp:ListItem Value="Cyan">Cyan</asp:ListItem>
                                                        <asp:ListItem Value="Gray">Gray</asp:ListItem>
                                                        <asp:ListItem Value="Green">Green</asp:ListItem>
                                                        <asp:ListItem Value="ForestGreen">Forest Green</asp:ListItem>
                                                        <asp:ListItem Value="Magenta">Magenta</asp:ListItem>
                                                        <asp:ListItem Value="Maroon">Maroon</asp:ListItem>
                                                        <asp:ListItem Value="Navy">Navy Blue</asp:ListItem>
                                                        <asp:ListItem Value="Orange">Orange</asp:ListItem>
                                                        <asp:ListItem Value="Pink">Pink</asp:ListItem>
                                                        <asp:ListItem Value="Purple">Purple</asp:ListItem>
                                                        <asp:ListItem Value="Red">Red</asp:ListItem>
                                                        <asp:ListItem Value="Yellow">Yellow</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="groupLabel" style="width: 59px">
                                Box&nbsp;Whisker
                            </div>
                            <table class="groupTable" style="width: 100%">
                                <tr>
                                    <td class="groupCell">
                                        Plot Type:<br />
                                        <asp:RadioButtonList id="rblBoxWhiskerType" Width="100%" RepeatColumns="2" RepeatDirection="Horizontal" AutoPostBack="True" runat="server">
                                            <asp:ListItem Value="monthly" Selected="True">Monthly</asp:ListItem>
                                            <asp:ListItem Value="seasonal">Seasonal</asp:ListItem>
                                            <asp:ListItem Value="yearly">Yearly</asp:ListItem>
                                            <asp:ListItem Value="overall">Overall</asp:ListItem>
                                        </asp:RadioButtonList>
                                        Connect:<br/>
                                        <asp:RadioButtonList id="rblBoxWhiskerLine" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True" runat="server">
                                            <asp:ListItem Value="mean">Means</asp:ListItem>
                                            <asp:ListItem Value="median" Selected="True">Medians</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
