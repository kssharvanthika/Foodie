<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ReviewForm.aspx.cs" Inherits="Foodie.User.ReviewForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .rating-stars {
            color: #ffc107; /* Star color */
        }
    </style>
    
   <script>
       function ImagePreview(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
               reader.onload = function (e) {
                   $('#<%=imgPreview.ClientID%>').prop('src', e.target.result)
                       .width(200)
                       .height(200);
               };
               reader.readAsDataURL(input.files[0]);
           }
       }
   </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h2> Review</h2>
                <div class="form-group">
 <label for="ddlRating">Rating:</label>
                <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text='<span class="glyphicon glyphicon-star"></span>' Value="1"></asp:ListItem>
                    <asp:ListItem Text='<span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span>' Value="2"></asp:ListItem>
                    <asp:ListItem Text='<span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span>' Value="3"></asp:ListItem>
                    <asp:ListItem Text='<span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span>' Value="4"></asp:ListItem>
                    <asp:ListItem Text='<span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span>' Value="5"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtComment">Comment:</label>
                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="fileUpload">Upload Photo:</label>
                <input type="file" id="fileUpload" runat="server" class="form-control-file" onchange="ImagePreview(this);"/>

               
            </div>
                <asp:Image ID="imgPreview" runat="server" CssClass="img-thumbnail" />
                <%--<asp:Label ID="lblFileName" runat="server" />--%>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Review" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
      </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
