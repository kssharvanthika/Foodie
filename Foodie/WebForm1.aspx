<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Foodie.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Showalert() {
            alert('Call JavaScript function from codebehind');
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
                    
            <asp:TextBox runat="server"></asp:TextBox>
            
                            <asp:Repeater  runat="server" DataSourceID="SqlDataSource1">
                             </asp:Repeater>
                                        
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FoodieDBConnectionString %>" SelectCommand="SELECT * FROM [Carts]"></asp:SqlDataSource>
                                        
            <asp:Button ID="Button1" runat="server" Text="Showalert" OnClick="Button1_Click" />
                                        
        </div>
    </form>
</body>
</html>
