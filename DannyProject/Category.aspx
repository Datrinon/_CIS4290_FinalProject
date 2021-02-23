<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout.Master" CodeBehind="Category.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta id="metaDescription" runat="server" name="Description" />
    <meta id="metaKeywords" runat="server" name="keywords" />
    <title id="dynamicTitle" runat="server" />

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!--======= Breadcrumb Left With BG Image =======-->
      <div class="iq-breadcrumb">
         <div class="container">
            <div class="row">
               <div class="col-sm-12">
                  <div class="box-space">
                     <div class="iq-breadcrumb-box">
                        <div class="row align-items-center">
                           <div class="col-lg-8">
                               <!--Dynamic SubCategory Title + Dynamic ProductList Title-->
                              <div class="breadcrumb-title">
                                 <h2><asp:Label ID="lblProductList" runat="server" Text="Featured Collection"></asp:Label>
                                 </h2>
                                 <p></p>
                              </div>
                           </div>
                           <div class="col-lg-4">
                              <nav aria-label="breadcrumb" class="text-right">
                                 <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Default.aspx"><i class="ion-android-home"></i>Home</a></li>
                                    <li class="breadcrumb-item active"><a href="Category.aspx?SubCategoryId=<%# Eval("ID")%>&SubCategoryName=<%# Trim(Eval("CategoryName"))%>&MainCategoryID=<% = Request.QueryString("MainCategoryID")%>&&MainCategoryName=<% = Request.QueryString("MainCategoryName")%>"><asp:Label ID="lblBreadCrumbMainCategory" runat="server" Text=""></asp:Label></a></li>
                                    <li class="breadcrumb-item active"><a href="Category.aspx?SubCategoryId=<% = Request.QueryString("SubCategoryID")%>&SubCategoryName=<% = Request.QueryString("CategoryName")%>&MainCategoryID=<% = Request.QueryString("MainCategoryID")%>&&MainCategoryName=<% = Request.QueryString("MainCategoryName")%>"><asp:Label ID="lblBreadCrumbSubCategory" runat="server" Text=""></asp:Label></a></li>
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
      <section class="iq-gridproduct particles position-relative">
         <div class="circle"></div>
         <div class="circle two"></div>
         <div class="plus">+</div>
         <div class="triangle"></div>
         <div class="triangle two"></div>
         <div class="square"></div>
         <div class="shape-1"><img src="images/shape/01.png" alt=""></div>
         <div class="shape-1 two"><img src="images/shape/01.png" alt=""></div>
         <div class="shape-2"><img src="images/shape/02.png" alt=""></div>
         <div class="shape-2 two"><img src="images/shape/02.png" alt=""></div>
         <div class="container">
            <div class="row">
               <div class="col-lg-3 col-md-12 col-sm-12">
                  <div class="shop-widget">
                     <div class="iq-post-sidebar">
                        <div class="shop-filter">
						   <!-- /Categories Start -->
									<div class="product-box discount-box">
                                    <!--SideBar SubCategory Display-->
									<h5><asp:Label ID="lblMainCategoryName" runat="server" Text="Categories"></asp:Label></h5>
										<div class="iq-widget-menu">
										<div class="silly_scrollbar">
											<div id="collapseTwo" class="collapse show" aria-labelledby="headingTwo" data-parent="#accordion">
												<div class="iq-widget-menu">
													<ul class="iq-pl-0">
                                                        <asp:SqlDataSource ID="SqlDSSubCategory" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore2 %>" SelectCommand="" runat="server"></asp:SqlDataSource>
                                                        <asp:Repeater ID="rpSubCategory" runat="server" DataSourceID="SqlDSSubCategory">
                                                        <ItemTemplate>
                                                            <!--SideBar List of SubCategory-->
                                                            <li><a href="Category.aspx?SubCategoryId=<%# Eval("ID")%>&SubCategoryName=<%# Trim(Eval("CategoryName"))%>&MainCategoryID=<% = Request.QueryString("MainCategoryID")%>&&MainCategoryName=<% = Request.QueryString("MainCategoryName")%>"><%# Trim(Eval("CategoryName")) %></a></li>
                                                        </ItemTemplate>
                                                        </asp:Repeater>
													</ul>
												</div>
											</div>
										</div>
									</div>
									</div>
							<!-- /Categories End -->
                        </div>
                     </div>
                  </div>
               </div>
               <div class="col-lg-9 col-md-12 col-sm-12 re-mtb-30">
                  <!-- shorting start -->
                  <!-- Products start -->
                   <asp:SqlDataSource ID="SqlDSProductListWS" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore2 %>" SelectCommand="" runat="server"></asp:SqlDataSource>
                   <asp:Repeater ID="rpSubProductListWS" runat="server" DataSourceID="SqlDSProductListWS">
                   <ItemTemplate>
                  <div class="row">
                     <div class="col-lg-12">
                        <div class="iq-productbox iq-gridlist">
                           <div class="media">
                              <div class="shopping-body">
                                 <div class="product-image">
                                     <!--Product Image Display-->
                                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# "/productImages/" + Trim(Eval("ProductNumber")) + ".jpg" %>' />
                                 </div>
                                 <%--<div class="btn-box">
                                     <!--Add Cart Display-->
                                    <a class="button" href="#"><img src="images/icon/001.png" alt="">Add to cart</a>
                                 </div>--%>
                              </div>
                              <div class="media-body">
                                 <div class="shopping-footer">
                                    <div class="product-detail text-left">
                                        <!--Product Name Display-->
                                       <h5><a href="ProductDetail.aspx?ProductID=<%# Eval("ProductId")%>&ProductName=<%# Trim(Eval("ProductName"))%>"><%# Trim(Eval("ProductName")) %></a></h5>
                                       <%--<p><%# Trim(Eval("ProductNumber")) %></p>--%>
                                        <p>
                                            <asp:Label ID="lblProductNumber" runat="server" Text='<%# Trim(Eval("ProductNumber")) %>'></asp:Label>
                                        </p>
                                        <div class="shop-price">
                                           <!--Product Price Display-->
                                        <strong><p><%# Trim(Eval("UnitPrice")) %></p></strong>
                                        <p style="color:red"><asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label></p>
                                        </div>
                                        <!--Product Description Display-->
                                       <p><%# Trim(Eval("ProductDescription")) %></p>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                   </ItemTemplate>
                   </asp:Repeater>
                  <!-- products end -->
                  <!--Sorting Function-->
                  <!--<div class="row align-items-center">
                     <div class="col-lg-6 col-md-4 col-sm-12">
                        <div class="products-show">
                           <span>Showing 1–3 Of 21 Results</span>
                        </div>
                     </div>
                     <div class="col-lg-4 col-md-5 col-sm-12">
                        <div class="form-group short-price float-right">
                           <select class="form-control" id="exampleFormControlSelect1">
                              <option>Sort by</option>
                              <option>New</option>
                              <option>Popularity</option>
                              <option>Discount</option>
                              <option>Price: low to high</option>
                              <option>Price: high to low</option>
                           </select>
                        </div>
                     </div>
                     <div class="col-lg-2 col-md-3 col-sm-12">
                        <div class="short-iconbox float-right">
                           <div class="short-icon">
                              <a href="shopgrid-sidebar.html"> <i class="fa fa-th" aria-hidden="true"></i></a>
                              <a href="shoplisting-sidebar.html"><i class="fa fa-list" aria-hidden="true"></i></a>
                           </div>
                        </div>
                     </div>
                  </div>-->
                  <!--Sorting Function End-->
               </div>
            </div>
         </div>
      </section>
      <!--=================================
      Main Content -->
</asp:Content>
