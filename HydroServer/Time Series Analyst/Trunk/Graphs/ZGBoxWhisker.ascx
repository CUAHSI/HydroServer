<%@ Control Language="VB" AutoEventWireup="true" CodeFile="ZGBoxWhisker.ascx.vb" Inherits="Graphs_ZGBoxWhisker" %>
<%@ Register Assembly="ZedGraph.Web" Namespace="ZedGraph.Web" TagPrefix="cc1" %>
<asp:Panel ID="pnlMain" runat="server">
<cc1:ZedGraphWeb id="BoxWhiskerPlot" runat="server"  Height="400" Width="520" BarType="Cluster" LineType="Normal" RenderedImagePath="~/images" Title="No Data To Plot">
    <XAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" IsPreventLabelOverlap="True"
        IsShowTitle="True" IsTicsBetweenLabels="False" IsUseTenPower="False" IsVisible="True"
        IsZeroLine="False" MinSpace="0" Title="&quot;Date and Time&quot;" Type="Date">
        <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" IsItalic="False"
            IsUnderline="False" Size="14" StringAlignment="Center">
            <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
            <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
        </FontSpec>
        <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
        <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <Scale Align="Center" Format="g" FormatAuto="False" IsReverse="False" Mag="0" MagAuto="False"
            MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" MaxAuto="True" MaxGrace="0.1"
            Min="0" MinAuto="True" MinGrace="0.1" MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
            <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" IsItalic="False"
                IsUnderline="False" Size="14" StringAlignment="Center">
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                    IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
            </FontSpec>
        </Scale>
        <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
    </XAxis>
    <Y2Axis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" IsPreventLabelOverlap="True"
        IsShowTitle="True" IsTicsBetweenLabels="True" IsUseTenPower="False" IsVisible="False"
        IsZeroLine="True" MinSpace="0" Title="" Type="Linear">
        <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" IsItalic="False"
            IsUnderline="False" Size="14" StringAlignment="Center">
            <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
            <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
        </FontSpec>
        <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
        <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <Scale Align="Center" Format="g" FormatAuto="False" IsReverse="False" Mag="0" MagAuto="False"
            MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" MaxAuto="True" MaxGrace="0.1"
            Min="0" MinAuto="True" MinGrace="0.1" MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
            <FontSpec Angle="-90" Family="Arial" FontColor="Black" IsBold="False" IsItalic="False"
                IsUnderline="False" Size="14" StringAlignment="Center">
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                    IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
            </FontSpec>
        </Scale>
        <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
    </Y2Axis>
    <MasterPaneBorder Color="Black" InflateFactor="0" IsVisible="True" PenWidth="1" />
    <MasterPaneFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100"
        IsScaled="True" IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
    <PaneBorder Color="Black" InflateFactor="0" IsVisible="True" PenWidth="1" />
    <YAxis AxisColor="Black" Cross="0" CrossAuto="True" IsOmitMag="False" IsPreventLabelOverlap="True"
        IsShowTitle="True" IsTicsBetweenLabels="True" IsUseTenPower="False" IsVisible="True"
        IsZeroLine="True" MinSpace="0" Title="" Type="Linear">
        <FontSpec Angle="-180" Family="Arial" FontColor="Black" IsBold="True" IsItalic="False"
            IsUnderline="False" Size="14" StringAlignment="Center">
            <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
            <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
        </FontSpec>
        <MinorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
        <MinorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <MajorTic Color="Black" IsInside="True" IsOpposite="True" IsOutside="True" PenWidth="1"
            Size="5" />
        <Scale Align="Center" Format="g" FormatAuto="False" IsReverse="False" Mag="0" MagAuto="False"
            MajorStep="1" MajorStepAuto="True" MajorUnit="Day" Max="0" MaxAuto="True" MaxGrace="0.1"
            Min="0" MinAuto="True" MinGrace="0.1" MinorStep="1" MinorStepAuto="True" MinorUnit="Day">
            <FontSpec Angle="90" Family="Arial" FontColor="Black" IsBold="False" IsItalic="False"
                IsUnderline="False" Size="14" StringAlignment="Center">
                <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                    IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
                <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
            </FontSpec>
        </Scale>
        <MajorGrid Color="Black" DashOff="5" DashOn="1" IsVisible="False" PenWidth="1" />
    </YAxis>
    <PaneFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
        IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
    <ChartFill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
        IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
    <ChartBorder Color="Black" InflateFactor="0" IsVisible="True" PenWidth="1" />
    <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="True" IsItalic="False"
        IsUnderline="False" Size="16" StringAlignment="Center">
        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
            IsVisible="True" RangeMax="0" RangeMin="0" Type="None" />
        <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
    </FontSpec>
    <Margins Bottom="10" Left="10" Right="10" Top="10" />
    <Legend IsHStack="True" IsVisible="False" Position="Top">
        <Location AlignH="Left" AlignV="Center" CoordinateFrame="ChartFraction" Height="0"
            Width="0" X="0" Y="0">
            <TopLeft X="0" Y="0" />
            <BottomRight X="0" Y="0" />
        </Location>
        <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
            IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
        <Border Color="Black" InflateFactor="0" IsVisible="True" PenWidth="1" />
        <FontSpec Angle="0" Family="Arial" FontColor="Black" IsBold="False" IsItalic="False"
            IsUnderline="False" Size="12" StringAlignment="Center">
            <Fill AlignH="Center" AlignV="Center" Color="White" ColorOpacity="100" IsScaled="True"
                IsVisible="True" RangeMax="0" RangeMin="0" Type="Solid" />
            <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
        </FontSpec>
    </Legend>
    <CurveList>
        <cc1:ZedGraphWebBarItem Color="" DataMember="" IsLegendLabelVisible="True" IsVisible="True"
            IsY2Axis="False" Label="">
            <Fill AlignH="Center" AlignV="Center" Color="Blue" ColorOpacity="100" IsScaled="True"
                IsVisible="True" RangeMax="0" RangeMin="0" Type="Brush" />
            <Border Color="Black" InflateFactor="0" IsVisible="False" PenWidth="1" />
        </cc1:ZedGraphWebBarItem>
    </CurveList>
</cc1:ZedGraphWeb>
</asp:Panel>
