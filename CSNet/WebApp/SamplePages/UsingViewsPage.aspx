<%@ Page Title="Using Views" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsingViewsPage.aspx.cs" Inherits="WebApp.SamplePages.UsingViewsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Label ID="Label1" runat="server" 
                Text="Select a category to view products:"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="CategoryList" runat="server" 
                DataSourceID="CategoryListODS" 
                DataTextField="CategoryName" 
                DataValueField="CategoryName"
                 AppendDataBoundItems="true">
                <asp:ListItem Value="">select ...</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:LinkButton ID="Search" runat="server">
                <i class="fa fa-search"></i>Search</asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="offset-4">
            <h4>Product of Category</h4>
            <br />
            <asp:GridView ID="CategoryProductList" runat="server" 
                AutoGenerateColumns="False" 
                DataSourceID="CategoryProductListODS" 
                AllowPaging="True">

                <Columns>
                    <asp:TemplateField HeaderText="CategoryName" SortExpression="CategoryName">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("CategoryName") %>' ID="Label1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                        SortExpression="ProductName"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
                        SortExpression="QuantityPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
                        SortExpression="UnitsInStock"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" 
                        SortExpression="Discontinued"></asp:CheckBoxField>
                </Columns>
                <EmptyDataTemplate>
                    No data to display for selection
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="CategoryListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Category_ListAll" 
        TypeName="NorthwindSystem.BLL.CategoryController">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CategoryProductListODS" 
        runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Views_ProductsOfCategory" 
        TypeName="NorthwindSystem.BLL.ViewController">
        <SelectParameters>
            <asp:ControlParameter ControlID="CategoryList" 
                PropertyName="SelectedValue" DefaultValue="zxcxv" 
                Name="category" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
