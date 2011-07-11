<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HydroAdmin.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>Information Systems </title>

    <link rel="stylesheet" href="stylesheets/style.css" type="text/css" media="screen" />
    <script type ="text/javascript">
    function CheckOne(obj)
    {
        var grid = obj.parentNode.parentNode.parentNode;
        var inputs = grid.getElementsByTagName("input"); 
        for(var i=0;i<inputs.length;i++)
        {
            if (inputs[i].type =="checkbox")
            {
                if(obj.checked && inputs[i] != obj && inputs[i].checked)
                {
                    inputs[i].checked = false;
                }
            }
        }
    }
    
   </script>
</head>
<body>
    <form id="form1" runat="server">
  
    <div style=" height:400px; width:400px; border-style:groove; overflow:auto">
    
    
    <asp:GridView ID="GridView1" runat="server" 
        onrowdatabound="GridView1_RowDataBound" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField  CommandName="Select" Text="Button" Visible="False" />
        </Columns>
    </asp:GridView>
        
    </div>
    <div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    
    
    
    </form>
</body>
</html>
