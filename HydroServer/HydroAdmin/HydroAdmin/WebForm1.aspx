<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HydroAdmin.WebForm1" %>

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
    <div>
    
    
    </div>
    
    
    
    
    
  
    
    
    
    <asp:Table ID="Table1" runat="server">
    </asp:Table>
    
    
    
    
    
  
    
    
    
    
    
    
    
    
    
  
    
    
    
    </form>
</body>
</html>
