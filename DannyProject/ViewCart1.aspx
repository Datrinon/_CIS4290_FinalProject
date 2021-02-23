<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout.Master" CodeBehind="ViewCart1.aspx.vb" Inherits="CIS4250Fall2020QwiloFashionStore.ViewCart1" %>
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
    <title>Shopping Cart</title>
    <section class="iq-cartbox particles position-relative">
    <div class="circle"></div>
    <div class="plus">+</div>
    <div class="triangle two"></div>
    <div class="shape-1"><img src="images/shape/01.png" alt=""></div>
    <div class="shape-2 two"><img src="images/shape/02.png" alt=""></div>
    <div class="container">
    <div class="row">
    <div class="col-sm-12">
        <div style="float: right; margin: 0 30px 5px 0;">
            <asp:Button ID="btnEmptyCart" runat="server" Text="Empty the Cart" />
        </div>   
        <asp:SqlDataSource ID="sqlDSCart1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore2 %>"> 
        </asp:SqlDataSource>

        <asp:ListView ID="lvCart" runat="server" DataSourceID="sqlDSCart1"
                OnItemCommand="lvCart_OnItemCommand" CellPadding="3" DataKeyField="CartNo"
                CellSpacing="0" RepeatColumns="1" DataKeyNames="ID">
            <LayoutTemplate>              
                <div style="float: right; margin: 0 30px 5px 0;">
                    <asp:Label ID="lblPage" runat="server" Text="" Font-Size="14px"></asp:Label>
                </div><br />
                <div class="table-responsive">
                <table class="table table-bordered iq-shopping-cart-table text-center">
                    <thead>
                        <tr>
					        <th class="image"><span>Item</span></th>
					        <th class="description"><span>Description</span></th>
					        <th class="price"><span>Price</span></th>
					        <th class="quantity"><span>Quantity</span></th>
					        <th class="total"><span>Subtotal</span></th>
					        <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" id="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                </table> 
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
				    <td class="cart_product">
					    <a><img src="productImages/<%# Trim(Eval("ProductNumber")) %>.jpg" alt=""></a>
				    </td>
				    <td class="cart_description">
					    <h4><a><%# Trim(Eval("ProductName")) %></a></h4>
					    <p>Web ID: <%# Eval("ProductNumber") %></p>
				    </td>
				    <td class="cart_price">
					    <p>$<%# Eval("Price") %></p>
				    </td>
				    <td class="cart_quantity">
                        <asp:TextBox ID="tbQuantity" Text='<%# Eval("Quantity")%>' Width="50px" CssClass="" runat="server"></asp:TextBox><br />
                        <asp:LinkButton runat="server" ID="lbUpdate" Text='Update'
                            CommandName="cmdUpdate" CommandArgument='<%# Eval("ProductNumber")%>' />
                        <asp:LinkButton runat="server" ID="lbDelete" Text='Delete'
                            CommandName="cmdDelete" CommandArgument='<%# Eval("ProductNumber")%>' />
				    </td>
				    <td class="cart_total">
					    <p class="cart_total_price"><%# (Eval("Price")) * (Eval("Quantity"))%></p>
                        <%--<asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>--%>
				    </td>
				    <td class="cart_delete">
				    </td>
                </tr> 
            </ItemTemplate>
        </asp:ListView>

        <div style="padding: 8px;width: 100%;text-align: center;">
            <div style="display: inline-block; margin-top: 5px">
                <asp:Button runat="server" Text="&laquo;" id="show_prev" CssClass="show_prevx"></asp:Button>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvCart" PageSize="3">
                    <Fields>        
                    <asp:NumericPagerField NextPageText='&raquo;' PreviousPageText='&laquo;' ButtonCount="5" 
                        ButtonType="Button" NextPreviousButtonCssClass="next_prevx" NumericButtonCssClass="numericx" 
                        CurrentPageLabelCssClass="currentx" RenderNonBreakingSpacesBetweenControls="False" />
                    </Fields>
                </asp:DataPager>
                <asp:Button runat="server" Text="&raquo;" id="show_next" CssClass="show_nextx"></asp:Button>
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
                                  <td class="text-right iq-font-black"> $<asp:Label ID="lblTotalCart" runat="server" Text=""></asp:Label></td>
                              </tr>
                           </tbody>
                        </table>
                        <a class="btn-black" href="#">PLACE ORDER</a>
                     </div>
                  </div>
               </div>
            </div>
    </div>
    </div>
    </div>
    </section>
</asp:Content>
