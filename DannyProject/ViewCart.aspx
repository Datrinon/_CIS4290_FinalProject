<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout.Master" CodeBehind="ViewCart.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <!--=================================
      Main Content -->
      <section class="iq-cartbox particles position-relative">
         <div class="circle"></div>
         <div class="plus">+</div>
         <div class="triangle two"></div>
         <div class="shape-1"><img src="images/shape/01.png" alt=""></div>
         <div class="shape-2 two"><img src="images/shape/02.png" alt=""></div>
         <div class="container">
            <div class="row">
               <div class="col-sm-12">
                  <div class="table-responsive">
                     <table class="table table-bordered iq-shopping-cart-table text-center">
                        <thead>
                           <tr>
                              <th></th>
                              <th><span>PHOTO</span></th>
                              <th><span>PRODUCT</span></th>
                              <th><span>UNIT PRICE</span></th>
                              <th><span>QUANTITY</span></th>
                              <th><span>SUBTOTAL</span></th>
                              <th></th>
                           </tr>
                        </thead>
                        <tbody>
                           <tr>
                              <td class="text-center align-middle">1</td>
                              <td class="align-middle"><a href="#"><img src="images/gallery/01.jpg" alt="img"></a></td>
                              <td class="align-middle"><a href="#">Men</a></td>
                              <td class="align-middle">
                                 <div class="iq-price">$98.55</div>
                              </td>
                              <td class="align-middle">
                                 <div class="input-group">
                                    <span class="input-group-btn">
                                       <button type="button" class="quantity-left-minus btn btn-number"  data-type="minus" data-field="">
                                       <i class="ion-ios-minus-empty"></i>
                                       </button>
                                    </span>
                                    <input type="text" name="quantity" class="form-control input-number quantity" value="0">
                                    <span class="input-group-btn">
                                       <button type="button" class="quantity-right-plus btn btn-number" data-type="plus" data-field="">
                                       <i class="ion-ios-plus-empty"></i>
                                       </button>
                                    </span>
                                 </div>
                              </td>
                              <td class="align-middle">
                                 <div class="final-price">$98.55</div>
                              </td>
                              <td class="align-middle"><a href="#" class="icon-close align-middle"><i class="fa fa-trash-o" aria-hidden="true"></i></a></td>
                           </tr>
                           <tr>
                              <td class="text-center align-middle">2</td>
                              <td class="align-middle"><a href="#"><img src="images/gallery/02.jpg" alt="img"></a></td>
                              <td class="align-middle"><a href="#" class="align-middle">Women</a></td>
                              <td class="align-middle">
                                 <div class="iq-price">$98.55</div>
                              </td>
                              <td class="align-middle">
                                 <div class="input-group">
                                    <span class="input-group-btn">
                                       <button type="button" class="quantity-left-minus btn btn-number"  data-type="minus" data-field="">
                                       <i class="ion-ios-minus-empty"></i>
                                       </button>
                                    </span>
                                    <input type="text" name="quantity" class="form-control input-number quantity" value="0">
                                    <span class="input-group-btn">
                                       <button type="button" class="quantity-right-plus btn btn-number" data-type="plus" data-field="">
                                       <i class="ion-ios-plus-empty"></i>
                                       </button>
                                    </span>
                                 </div>
                              </td>
                              <td class="align-middle">
                                 <div class="final-price">$98.55</div>
                              </td>
                              <td class="align-middle"><a href="#" class="icon-close align-middle"><i class="fa fa-trash-o" aria-hidden="true"></i></a></td>
                           </tr>
                        </tbody>
                     </table>
                  </div>
                  <div class="iq-update_cart">
                     <a class="button float-right" href="#">Update Cart</a>
                  </div>
               </div>
            </div>

            <%--Product Detail Display--%>
            <div class="row justify-content-end">
               <div class="col-lg-6 col-md-12">
                  <div class="iq-totale">
                     <h6>Cart Totals</h6>
                     <div class="iq-carttotal">
                        <table class="table">
                           <thead>
                              <tr>
                                 <th scope="col">PRICE DETAILS</th>
                                 <th scope="col"></th>
                              </tr>
                           </thead>
                           <tbody>
                              <tr>
                                 <td>Shipping</td>
                                 <td class="highlight text-right iq-font-green">FREE</td>
                              </tr>
                              <tr>
                                 <td>Tax</td>
                                 <td class="highlight text-right iq-font-green">FREE</td>
                              </tr>
                              <tr class="tbl-footer">
                                 <td><b>Total Cost</b></td>
                                 <td class="text-right iq-font-black"><b> $1950</b></td>
                              </tr>
                           </tbody>
                        </table>
                        <a class="btn-black" href="#">PLACE ORDER</a>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </section>
      <!--=================================
      Main Content -->

    <asp:SqlDataSource ID="SqlDSCart" runat="server" 
        DataSourceMode="DataSet"
        ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" 
        SelectCommand=""
        DeleteCommand="DELETE FROM [Cart] WHERE ([CartNo] = @CartNo AND [ProductNumber] = @ProductNumber)"
        UpdateCommand="UPDATE [Cart] SET [Quantity] = @Quantity WHERE ([CartNo] = @CartNo AND [ProductNumber] = @ProductNumber)">
    </asp:SqlDataSource>
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDSCart" AllowPaging="True" PageSize="3" DataKeyNames="CartNo,ProductNumber"
        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
        EmptyDataText="There are no product in the cart.">
        <Columns>
            <asp:BoundField DataField="ProductNumber" HeaderText="Product Number" InsertVisible="False" ReadOnly="true"
                SortExpression="ProductNumber" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" InsertVisible="False" ReadOnly="true"
                SortExpression="ProductName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />

            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" InsertVisible="False" ReadOnly="true" />
        </Columns>
    </asp:GridView>
	
</asp:Content>
