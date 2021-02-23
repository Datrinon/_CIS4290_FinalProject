<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout.Master" CodeBehind="ProductDetail.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta id="metaDescription" runat="server" name="Description" />
    <meta id="metaKeywords" runat="server" name="keywords" />
    <title id="dynamicTitle" runat="server" />

    <head>
      <title>Qwilo - Multi-purpose Responsive HTML5 Template</title>
      <!-- Required meta tags -->
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
      <!-- Favicon -->
      <link rel="shortcut icon" href="images/favicon.ico" />
      <!-- bootstrap -->
      <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
      <!-- main style -->
      <link href="css/style.css" rel="stylesheet" type="text/css" />
      <!-- responsive -->
      <link href="css/responsive.css" rel="stylesheet" type="text/css" />
      <!-- custom -->
      <link href="css/custom.css" rel="stylesheet" type="text/css" />
   </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!--=================================
         header -->
      <!--======= Breadcrumb Left With BG Image =======-->
      <div class="iq-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-sm-12">
                  <div class="box-space">
                     <div class="iq-breadcrumb-box">
                        <div class="row align-items-center">
                           <div class="col-lg-6 col-sm-12">
                              <div class="breadcrumb-title">
                                 <h2>Shop Detail</h2>
                              </div>
                           </div>
                           <div class="col-lg-6 col-sm-12">
                              <nav aria-label="breadcrumb" class="text-right">
                                 <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Default.aspx"><i class="ion-android-home"></i>Home</a></li>
                                    <li class="breadcrumb-item"><a href="ProductDetail.aspx?ProductID=<% = Request.QueryString("ProductID")%>">Product Detail</a></li>
                                 </ol>
                              </nav>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <!--======= Breadcrumb Left With BG Image =======-->
      <!--=================================
         Main Content -->
      <div class="main-content particles position-relative">
         <div class="circle"></div>
         <div class="circle two"></div>
         <div class="plus">+</div>
         <div class="triangle"></div>
         <div class="triangle two"></div>
         <div class="shape-1"><img src="shopDetail/images/shape/01.png" alt=""></div>
         <div class="shape-1 two"><img src="shopDetail/images/shape/01.png" alt=""></div>
         <div class="shape-2 two"><img src="shopDetail/images/shape/02.png" alt=""></div>
         <section class="iq-shopdetail-box" data-twttr-rendered="true" data-spy="scroll" data-target=".bs-docs-sidebar">
            <div class="container">
               <div class="row">
                  <div class="col-lg-5 col-md-5 col-sm-12">
                     <div class="iq-slick">
                        <div class="slider slider-for">
                            <!--Product Image-->
                            <div> <asp:Image ID="imgProduct" runat="server" class ="img-fluid"/></div>
                        </div>
                     </div>
                  </div>
                  <div class="col-lg-7 col-md-7 col-sm-12 position-relative">
                     <div class="iq-shopdetail">
                        <div class="detail-top">
                           <span class="top-lable">Fashion</span>
                            <!--Product Name-->
                           <h3>
                               <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h3>
                           <div class="shop-price w-100 d-inline-block">
                               <!--Product Price-->
                               <h4><asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></h4><br />
                               <h5 style="color:red"><asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label></h5><br />
                           </div>
                           <div class="rate-box">
                              <div class="iq-rating">
                                 <ul class="list-inline float-left">
                                     <asp:Label ID="lblRating" runat="server" class="list-inline-item" Text=""></asp:Label>
                                    <%--<li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
                                    <li class="list-inline-item"><a href="#"><i class="fa fa-star-o" aria-hidden="true"></i></a></li>--%>
                                 </ul>
                              </div>
                           </div>
                        </div>
                        <div class="detail-bottom">
                           <div class="product_meta">
                              <ul>
                                 <li><span>Product #</span><asp:Label ID="lblProductNumber" runat="server" Text="Label"></asp:Label></li>
                              </ul>
                           </div>
                           <!--Quantity -->
                            <!--Product Quantity-->
                                     <p>Quantity:
                                    <asp:TextBox ID="tbQuantity" runat="server" class="form-control input-number quantity" value="1"></asp:TextBox>
                                     </p>
                           <!-- button -->
                           <div class="all-button">
                               <asp:Button class="button w-100" ID="btnAddtoCart" runat="server" Text="Add To Cart" />
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
               <div class="row iq-detailleft">
                  <div class="col-sm-12">
                     <div class="tab-box">
                        <ul class="nav nav-tabs text-left" id="myTab" role="tablist">
                           <li class="nav-item">
                              <a class="nav-link" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-expanded="true" aria-selected="true">Description</a>
                           </li>
                           <li class="nav-item">
                              <a class="nav-link active" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact-tab" aria-selected="false">Review</a>
                           </li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                           <div class="tab-pane fade" id="home" role="tabpanel" aria-labelledby="home-tab">
                              <p><asp:Label ID="lblProductDescription" runat="server" Text="Label"></asp:Label></p>
                           </div>
                           <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                              <table class="table">
                                 <tbody>
                                    <tr>
                                       <th scope="row">Product Code</th>
                                       <td>US$32</td>
                                    </tr>
                                 </tbody>
                              </table>
                           </div>
                           <div class="tab-pane fade show active" id="contact" role="tabpanel" aria-labelledby="contact-tab">
                              <div class="row">
                                 <div class="col-lg-12">
                                    <div class="review-text">
                                       <div class="rating-body iq-rating">
                                          <ul class="list-inline">
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-o" aria-hidden="true"></i></a></li>
                                          </ul>
                                       </div>
                                       <div class="media  btn-brd">
                                          <img class="mr-3" alt="#" src="shopDetail/images/review/01.jpg">
                                          <div class="media-body">
                                             <h6>Nina Dobrev</h6>
                                             <div class="iq-comment-metadata"><a href="#"><i class="fa fa-calendar"></i>
                                                <span>May 14, 2017 at 5:00 pm</span>
                                                </a>
                                             </div>
                                             <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration.</p>
                                          </div>
                                       </div>
                                    </div>
                                    <div class="review-text">
                                       <div class="rating-body iq-rating">
                                          <ul class="list-inline">
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-o" aria-hidden="true"></i></a></li>
                                          </ul>
                                       </div>
                                       <div class="media  btn-brd">
                                          <img class="mr-3" alt="#" src="shopDetail/images/review/02.jpg">
                                          <div class="media-body">
                                             <h6>Nick Jonas</h6>
                                             <div class="iq-comment-metadata"><a href="#"><i class="fa fa-calendar"></i>
                                                <span>May 14, 2017 at 5:00 pm</span>
                                                </a>
                                             </div>
                                             <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some.</p>
                                          </div>
                                       </div>
                                    </div>
                                    <div class="review-text">
                                       <div class="rating-body iq-rating">
                                          <ul class="list-inline">
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
                                             <li class="list-inline-item"><a href="#"><i class="fa fa-star-o" aria-hidden="true"></i></a></li>
                                          </ul>
                                       </div>
                                       <div class="media  btn-brd">
                                          <img class="mr-3" alt="#" src="shopDetail/images/review/03.jpg">
                                          <div class="media-body">
                                             <h6>Ria somani</h6>
                                             <div class="iq-comment-metadata"><a href="#"><i class="fa fa-calendar"></i>
                                                <span>May 14, 2017 at 5:00 pm</span>
                                                </a>
                                             </div>
                                             <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form.</p>
                                          </div>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </section>
      </div>
      <!--=================================
         Main Content -->
</asp:Content>
