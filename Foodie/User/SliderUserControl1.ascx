<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SliderUserControl1.ascx.cs" Inherits="Foodie.User.SliderUserControl1" %>

 <section class="slider_section ">
       
   <div id="customCarousel1" class="carousel slide" data-ride="carousel">
      <asp:Button ID="btnRegister" runat="server" Text="Book the seat" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
     <%--<asp:Button ID="btnvacancy" runat="server" Text="Hiring" CssClass="btn btn-primary" OnClick="btnvacancy_Click" />--%>

     <div class="carousel-inner">
         
       <div class="carousel-item active">
         <div class="container ">
              
           <div class="row">
             <div class="col-md-7 col-lg-6 ">
               
               <div class="detail-box">
                    
                 <h1>
                   Ice Cube Cafe
                 </h1>
                 <p>
                   Awaken Your Senses – Unwind, Relax, and Revel in Rich Aromas!"
"Café Chic: Where Style Meets Steaming Cups and Sweet Moments!
                 </p>
                 <div class="btn-box">
                   <a href="Menu.aspx" class="btn1">
                     Order Now
                   </a>
                 </div>
               </div>
             </div>
           </div>
         </div>
       </div>
       <div class="carousel-item ">
         <div class="container ">
           <div class="row">
             <div class="col-md-7 col-lg-6 ">
               <div class="detail-box">
                 <h1>
                   Grilled Salmon
                 </h1>
                 <p>
                    Espresso Yourself: Where Flavor and Friends Meet!"
"A Sip of Happiness in Every Cup – Welcome to Mellow Mocha Café!
                 </p>
                 <div class="btn-box">
                   <a href="Menu.aspx" class="btn1">
                     Order Now
                   </a>
                 </div>
               </div>
             </div>
           </div>
         </div>
       </div>
       <div class="carousel-item">
         <div class="container ">
           <div class="row">
             <div class="col-md-7 col-lg-6 ">
               <div class="detail-box">
                 <h1>
                   DelishDynamo
                 </h1>
                 <p>
                    From the first sip of our signature blends to the last bite of our mouthwatering pastries, we aim to create an atmosphere where you can espresso yourself. Join us at Bean Bliss – where the magic happens in every cup,
                     and every encounter becomes a memorable chapter in your daily narrative."
                 </p>
                 <div class="btn-box">
                   <a href="Menu.aspx" class="btn1">
                     Order Now
                   </a>
                 </div>
               </div>
             </div>
           </div>
         </div>
       </div>
     </div>
     <div class="container">
       <ol class="carousel-indicators">
         <li data-target="#customCarousel1" data-slide-to="0" class="active"></li>
         <li data-target="#customCarousel1" data-slide-to="1"></li>
         <li data-target="#customCarousel1" data-slide-to="2"></li>
       </ol>
     </div>
   </div>


 </section>