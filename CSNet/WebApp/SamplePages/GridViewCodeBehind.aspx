<%@ Page Title="Using GridView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridViewCodeBehind.aspx.cs" Inherits="WebApp.SamplePages.GridViewCodeBehind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row">
        <div class="jumbotron">
            <h1>Filter Search using GridView</h1>
            <blockquote class="col-12 alert alert-info">
                This web page uses only code behind techniques. This page uses
                a drill down filter search involing a TextBox and GridView. The
                GridView demonstrates: customization, paging and selection.
            </blockquote>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server" Text="Enter a product name:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="ProductArg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:LinkButton ID="SearchProduct" runat="server" OnClick="SearchProduct_Click">
                <i class="fa fa-search"></i> Search Product?</asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="Clear" runat="server" OnClick="Clear_Click"
                 CausesValidation="false">
                <i class="fa fa-trash"></i>Clear</asp:LinkButton>
            <br />
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
            <br />
            <asp:GridView ID="ProductList" runat="server"
                CssClass="fa-table table-striped" GridLines="Horizontal"
                BorderStyle="None" AutoGenerateColumns="False" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">

                <Columns>
                    <asp:CommandField SelectText="View" ShowSelectButton="True" 
                        ButtonType="Button" CausesValidation="false"></asp:CommandField>
                    <asp:TemplateField HeaderText="Name">
                      <ItemTemplate>
                          <asp:HiddenField ID="ProductID" runat="server"
                               Value='<%# Eval("ProductID") %>'/>
                            <asp:Label runat="server" 
                                Text='<%# Eval("ProductName") %>'
                                ID="ProductName"></asp:Label>
                       </ItemTemplate>
                       <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label runat="server" 
                                Text='<%# string.Format("{0:0.00}", Eval("UnitPrice")) %>'
                                ID="UnitPrice"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QoH">
                        <ItemTemplate>
                            <asp:Label runat="server" 
                                Text='<%# Eval("UnitsInStock") %>'
                                ID="UnitsInStock"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right">
                        </ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Product ID:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="ProductID" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="ProductName" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Price ($)"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="UnitPrice" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Disc."></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="Discontinued" runat="server" 
                            Text="&nbsp;(discontinued if checked)"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
