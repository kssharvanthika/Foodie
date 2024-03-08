<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email.aspx.cs" Inherits="Foodie.email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" width="70%" align="center" cellpadding="5" cellspacing="0" style="background-color: #DDFC42;">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 22px; font-weight: bold; color: #FF0000;">Application - Send Email Message</td>
                </tr>
                <tr>
                    <td>From :</td>
                    <td>
                        <asp:TextBox ID="tFrom" runat="server" Text="sharvanthikaks.22mca@kongu.edu" Height="25px" Width="250px"></asp:TextBox>
                    </td>
                    <td>From Password :</td>
                    <td>
                        <asp:TextBox ID="tPassword" runat="server" TextMode="Password" Height="25px" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>SMTP  :</td>
                    <td>
                        <asp:TextBox ID="tSmptp" runat="server" Text="smtp@gmail.com" Height="25px" Width="250px"></asp:TextBox>
                    </td>
                    <td>Port :</td>
                    <td>
                        <asp:TextBox ID="tPort" runat="server" Text="587" Height="25px" Width="250px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>To  :</td>
                    <td>
                        <asp:TextBox ID="tTo" runat="server" Text="kssharvanthika123@gmail.com" Height="25px" Width="250px"></asp:TextBox>
                    </td>
                    <td>CC :</td>
                    <td>
                        <asp:TextBox ID="tCC" runat="server" Text="" Height="25px" Width="250px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Subject  :</td>
                    <td>
                        <asp:TextBox ID="tSubject" runat="server" Text="Hello foodeies" Height="25px" Width="250px"></asp:TextBox>
                    </td>
                    <td>Message :</td>
                    <td>
                        <asp:TextBox ID="tMessage" runat="server" Text="this is test message from we application !" TextMode="MultiLine" Height="25px" Width="250px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 18px; font-weight: bold; color: #FF0000;">
                        <asp:Label ID="lMsg" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center; ">
                        <asp:Button ID="btnSend" runat="server" Text="Send" Width="40%" Height="30px" OnClick="btnSend_Click" />
                       </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
