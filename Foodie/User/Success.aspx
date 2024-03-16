<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Foodie.User.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
    <style>
    .gradient-background {
    background: linear-gradient(to bottom, #eeaeca, #94bbe9); /* Adjust gradient colors as needed */
}

</style>

</asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <h1>Success</h1>

<%--<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Order Id</label>
    </div>
    <div class="col-md-3">
        <asp:Label runat="server" ID="lblOrderId" Font-Bold="true" />
    </div>
</div>
<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Payment Id</label>
    </div>
    <div class="col-md-3">
        <asp:Label runat="server" ID="lblPaymentId" Font-Bold="true" />
    </div>
</div>--%>

   <%--  <div class="row">
    <div class="col-md-offset-1 col-md-8">
        <asp:Label runat="server" Text="Your payment against the registration is successful. Please note the OrderId for future reference" />
    </div>
</div>
<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Order Id</label>
    </div>
    <div class="col-md-3">
        <div class="rounded-circle text-center bg-primary text-white p-3">
            <asp:Label runat="server" ID="lblOrderId" Font-Bold="true" />
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-offset-1 col-md-2">
        <label runat="server">Payment Id</label>
    </div>
    <div class="col-md-3">
        <div class="rounded-circle text-center bg-primary text-white p-3">
            <asp:Label runat="server" ID="lblPaymentId" Font-Bold="true" />
        </div>
    </div>
</div>

   
        <div class="row">
    <%--<div class="col-md-offset-1 col-md-2">--%>
 <%--<div class="row justify-content-center">
    <div class="col-md-8 text-center">
        <label runat="server" class="text-primary font-italic">The only way to do great work is to love what you do</label>
    </div>
</div>


    </div>
   <%-- <div class="col-md-3">
        <asp:Button ID="btnReorder" runat="server" Text="Reorder" OnClick="btnReorder_Click" CssClass="btn btn-primary" />

    </div>--%>

         <%-- <div class="col-md-3">
    <asp:Button ID="btnReorder" runat="server" Text="🍦 Reorder" OnClick="btnReorder_Click" CssClass="btn btn-dark rounded-pill border-0 p-3" />
</div>--%>


            
     <div class="gradient-background">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-1 col-md-8">
                <asp:Label runat="server" Text="Your payment against the registration is successful. Please note the OrderId for future reference" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-1 col-md-2">
                <label runat="server">Order Id</label>
            </div>
            <div class="col-md-3">
                <div class="rounded-circle text-center bg-primary text-white p-3">
                    <asp:Label runat="server" ID="lblOrderId" Font-Bold="true" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-1 col-md-2">
                <label runat="server">Payment Id</label>
            </div>
            <div class="col-md-3">
                <div class="rounded-circle text-center bg-primary text-white p-3">
                    <asp:Label runat="server" ID="lblPaymentId" Font-Bold="true" />
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
              <label runat="server" class="bg-transparent text-dark font-italic" style="font-size: 20px;">The only way to do great work is to love what you do</label>

            </div>
        </div>
         <div class="row justify-content-center">
        <div class="row">
            <div class="col-md-3">
                <asp:Button ID="btnReorder" runat="server" Text="🍦 Reorder" OnClick="btnReorder_Click" CssClass="btn btn-dark rounded-pill border-0 p-3" />
            </div>
        </div>

              <div class="row">
     <div class="col-md-3">
         <asp:Button ID="btnreview" runat="server" Text="🍦 Add Review" OnClick="btnreview_Click" CssClass="btn btn-dark rounded-pill border-0 p-3" />
     </div>
 </div>
             </div>
    </div>
</div>

   

   
    
</asp:Content>
