<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Foodie.User.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- about section -->

  <section class="about_section layout_padding">
    <div class="container  ">

      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="../TemplateFiles/images/about-img.png" alt="">
          </div>
        </div>
        <div class="col-md-6">
          <div class="detail-box">
            <div class="heading_container">
              <h2>
                We Are Feane
              </h2>
            </div>
            <p>
              Indulge your taste buds in a symphony of flavors at QuickBite – where every bite is a celebration of deliciousness! Our motto, 'QuickBite, Delight in Every Bite,' encapsulates our commitment to delivering speedy service without compromising on taste. From mouthwatering burgers to crispy fries and delectable desserts, we're your go-to destination for a fast and flavorful feast. At QuickBite, we believe in making every meal a 
                delightful experience, ensuring that your cravings are satisfied with each and every visit.
            </p>
            <a href="videos.aspx">
              Read More
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end about section -->
</asp:Content>
