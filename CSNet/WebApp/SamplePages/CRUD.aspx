<%@ Page Title="CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CRUD.aspx.cs" Inherits="WebApp.SamplePages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class ="row">
        <div class="jumbotron">
            <h1>Filter Search using ODS for GridView</h1>
            <blockquote class="col-12 alert alert-info">
                This web page uses only code behind techniques. This page uses
                a drill down filter search involing a TextBox and GridView. The
                GridView demonstrates: customization, paging and selection. This 
                page will use ObjectDataSource techniques for obtaining the data
                for the gridview.
            </blockquote>
        </div>
    </div>

<%--    <asp:RequiredFieldValidator ID="RequiredProductArg" runat="server" 
        ErrorMessage="A value for the search product name is required."
         Display="None" SetFocusOnError="true" ControlToValidate="ProductArg">
    </asp:RequiredFieldValidator>--%>
        <asp:RequiredFieldValidator ID="RequiredProductName" runat="server" 
        ErrorMessage="A value for the product name is required."
         Display="None" SetFocusOnError="true" ControlToValidate="ProductName">
    </asp:RequiredFieldValidator>

    <asp:CompareValidator ID="CompareUnitPrice" runat="server" 
        ErrorMessage="Unit price must be dollar amount 0.00 or greater"
         Display="None" SetFocusOnError="true" ControlToValidate="UnitPrice"
         Type="Double" Operator="GreaterThanEqual"  ValueToCompare="0.00">
    </asp:CompareValidator>
    <asp:CompareValidator ID="ComparUnitsInStock" runat="server" 
        ErrorMessage="Quantity on Hand must be amount 0 or greater"
         Display="None" SetFocusOnError="true" ControlToValidate="UnitsInStock"
         Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0">
    </asp:CompareValidator>
    <asp:CompareValidator ID="CompareUnitsOnOrder" runat="server" 
        ErrorMessage="Quantity on Order must be amount 0 or greater"
         Display="None" SetFocusOnError="true" ControlToValidate="UnitsOnOrder"
         Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0">
    </asp:CompareValidator>
    <asp:CompareValidator ID="CompareReorderLevel" runat="server" 
        ErrorMessage="Reorder level must be amount 0 or greater"
         Display="None" SetFocusOnError="true" ControlToValidate="ReorderLevel"
         Type="Integer" Operator="GreaterThanEqual" ValueToCompare="0">
    </asp:CompareValidator>

    <div class="row">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server" Text="Enter a product name:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="ProductArg" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:LinkButton ID="SearchProduct" runat="server" OnClick="SearchProduct_Click"
                 CausesValidation="false">
                <i class="fa fa-search"></i> Search Product?</asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="Clear" runat="server" OnClick="Clear_Click"
                 CausesValidation="false">
                <i class="fa fa-trash"></i>Clear</asp:LinkButton>
            <br />
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
            <br />
            <asp:GridView ID="ProductList" runat="server"
                CssClass="table table-striped" GridLines="Horizontal"
                BorderStyle="None" AutoGenerateColumns="False"
                OnSelectedIndexChanged="ProductList_SelectedIndexChanged" 
                DataSourceID="ProductListODS" AllowPaging="True"
                 PageSize="4">

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
                      <asp:TemplateField HeaderText="Cat">
                        <ItemTemplate>
                            <asp:DropDownList ID="CategoryGVList" runat="server" 
                                DataSourceID="CategoryListODS" 
                                DataTextField="CategoryName" 
                                DataValueField="CategoryID"
                                selectedvalue='<%# Eval("CategoryID") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
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
               <EmptyDataTemplate>
                   No data to display
               </EmptyDataTemplate>
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
                        <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="CategoryList" runat="server" 
                            DataSourceID="CategoryListODS" 
                            DataTextField="CategoryName" 
                            DataValueField="CategoryID"
                             AppendDataBoundItems="true">
                            <asp:ListItem Value="0">None</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" Text="Supplier"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="SupplierList" runat="server" 
                            DataSourceID="SupplierListODS" 
                            DataTextField="CompanyName" 
                            DataValueField="SupplierID"
                             AppendDataBoundItems="true">
                            <asp:ListItem Value="0">None</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Qty/Unit"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="QuantityPerUnit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Price ($)"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="QoH"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitsInStock" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label10" runat="server" Text="QoO"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="UnitsOnOrder" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="ROL"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="ReorderLevel" runat="server"></asp:TextBox>
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
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="Add" runat="server" Text="Add" height="33px" OnClick="Add_Click" width="74px" />&nbsp;&nbsp;
                        <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />&nbsp;&nbsp;
                        <asp:Button ID="Disc" runat="server" Text="Disc." 
                             CausesValidation="false" height="33px" OnClick="Disc_Click" width="74px"/>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%-- objectdatasource controls --%>
    <asp:ObjectDataSource ID="ProductListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Product_GetByPartialProductName" 
        TypeName="NorthwindSystem.BLL.ProductController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ProductArg" 
                PropertyName="Text" DefaultValue="xcvdfg" 
                Name="productname" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CategoryListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Category_ListAll" 
        TypeName="NorthwindSystem.BLL.CategoryController">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SupplierListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Supplier_ListAll" 
        TypeName="NorthwindSystem.BLL.SupplierController">
    </asp:ObjectDataSource>
</asp:Content>
