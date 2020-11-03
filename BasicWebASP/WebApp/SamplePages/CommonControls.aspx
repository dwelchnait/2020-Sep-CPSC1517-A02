<%@ Page Title="Common Controls" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="CommonControls.aspx.cs" 
    Inherits="WebApp.SamplePages.CommonControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 text-center">
        <h1>Common Web Form Controls and using event driven logic</h1>

        </div>
    </div>
    <%-- TextBox --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label1" runat="server" 
                Text="Enter a selection choice 1 to 4: "></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="NumberChoice" runat="server"
                 Width="50px" Height="30px"
                 ToolTip="Enter a nuumber between 1 and 4"></asp:TextBox>
            <asp:Button ID="SubmitNumberChoice" runat="server" 
                Text="Submit Number Choice" CssClass="btn btn-success" OnClick="SubmitNumberChoice_Click" />
        </div>
    </div>
    <%-- RadioButtonList (group of radio buttons --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label2" runat="server" 
                Text="RadioButtons of choice:"></asp:Label>&nbsp;
        </div>
        <div class="col-md-6">
            <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="1">&nbsp;COMP1008&nbsp;</asp:ListItem>
                <asp:ListItem Value="2">&nbsp;CPSC1517&nbsp;</asp:ListItem>
                <asp:ListItem Value="3">&nbsp;DMIT1508&nbsp;</asp:ListItem>
                <asp:ListItem Value="4">&nbsp;DMIT2018&nbsp;</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <%-- CheckBox --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label3" runat="server" 
                Text="Checkbox of choice:"></asp:Label>&nbsp;
        </div>
        <div class="col-md-6">
            <asp:CheckBox ID="CheckBoxChoice" runat="server" 
                 Text="&nbsp;(checked if a programming language)"/>
        </div>
    </div>
    <%-- Literal/Label --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Literal ID="Literal1" runat="server"
                 Text="Read only display using a label: "></asp:Literal>&nbsp;
        </div>
        <div class="col-md-6">
            <asp:Label ID="DisplayReadOnly" runat="server" ></asp:Label>
        </div>
    </div>
    <%-- Dropdownlist --%>
     <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label4" runat="server" 
                Text="DDL Collection:"></asp:Label>&nbsp;
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="CollectionList" runat="server">

            </asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonChoice" runat="server" OnClick="LinkButtonChoice_Click">
                Submit Collection Choice</asp:LinkButton>
        </div>
    </div>
    <%-- output area for messages --%>
    <div class="row">
        <div class="col-md-12 text-center">
            <br /><br />
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>&nbsp;
        </div>
       
    </div>
</asp:Content>
