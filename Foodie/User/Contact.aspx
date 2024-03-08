<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Foodie.User.Contact" %>

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

    <!-- book section -->
    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </div>
                <h2>Send Your Query
                </h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">

                        <div>

                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"
                                placeholder="Your Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                ErrorMessage="Name is required" ControlToValidate="txtName" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div>

                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                                placeholder="Your Email" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ErrorMessage="Email is required" ControlToValidate="txtEmail" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"
                                placeholder="Subject"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvsubject" runat="server"
                                ErrorMessage="Subject is required" ControlToValidate="txtSubject" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"
                                placeholder="Enter your Query/Feedback"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server"
                                ErrorMessage="Message  is required" ControlToValidate="txtMessage" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="btn_box">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                               CssClass="btn btn-warning rounded-pill pl-4 pr-4 text-white" 
                                onClick="btnSubmit_Click"/>
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="map_container ">
                        <%--<div id="googleMap">--%>
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3912.084966992702!2d77.69180457479865!3d11.328500148768567!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ba96ee150ab537d%3A0x30e9026a084de8f5!2sIceCube%20Restro%20Cafe!5e0!3m2!1sen!2sin!4v1709307194441!5m2!1sen!2sin" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                       <%-- </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- end book section -->
</asp:Content>
