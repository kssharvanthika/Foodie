<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Foodie.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID%>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </div>
                <h2>Login</h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">
                        <img id="userlogin" src="../Images/Login.jpg" alt="" class="img-thumbnail" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form_container">

                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="username is required!"
                            ControlToValidate="txtUsername" ForeColor="Red" Font-Size="Small" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="enter username" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form_container">

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is required!"
                            ControlToValidate="txtPassword" ForeColor="Red" Font-Size="Small" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="enter Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>

                    <%--<div class="form_container">

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="email  is required!"
                            ControlToValidate="txtemails" ForeColor="Red" Font-Size="Small" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtemails" runat="server" placeholder="enter mobile number"  CssClass="form-control"></asp:TextBox>
                    </div>

                    <asp:Label ID="lblmessage" runat="server" ></asp:Label>
                    <asp:Button ID="btnSend" runat="server" onClick="btnSend_Click" Text="send OTP" /><br/>
                   

                     <div class="form_container">
                         <asp:TextBox ID="txtOtp" runat="server" Visible="false" placeholder="enter OTP"></asp:TextBox>
                         <div class="clearfix"></div>
                        </div>--%>
                    <%--<asp:Button ID="btnverify" runat="server" onclick="btnverify_Click" Visible="false" Text="verify" />--%>


                    
                    <div class="btn_box">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white"
                            OnClick="btnLogin_Click" />
                        <span class="pl-3 text-info">New User? <a href="Registration.aspx" class="badge badge-info">Register here</a></span>

                    </div>
                    <div class="btn_box">
                     <a href="ResetPassword.aspx" class="badge badge-succuess">Forget Password</a>
                     </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
