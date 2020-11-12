<%@ Page Title="Simple Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQuery.aspx.cs" Inherits="WebApp.SamplePages.SimpleQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Query</h1>
    <blockquote class="alert alert-info">
        this page will input a region number and display the region record
        matching that input value.
    </blockquote>
    <div class="row">
        <div class="col-6">
            <asp:Label ID="Label1" runat="server" Text="Enter Region ID: "></asp:Label>
            <asp:TextBox ID="RegionArg" runat="server"></asp:TextBox>
            <asp:Button ID="RegionSearch" runat="server" Text="Region ?" OnClick="RegionSearch_Click" />
        </div>
        <div class="col-6">
            <asp:Label ID="Label2" runat="server" Text="Region ID: "></asp:Label>
            <asp:Label ID="RegionID" runat="server" ></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Description: "></asp:Label>
            <asp:Label ID="RegionDescription" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12 text-center">
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
