<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CVeditor._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>Upload your CV in XML format</h3>
    </div>

    <div>
        <asp:FileUpload ID="FileUpload" runat="server" />
    </div>
    <hr />
    <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" />
    <asp:Button ID="btnExport" runat="server" Text="Export Data" OnClick="btnExport_Click" />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
    <br />

    <hr />
    <asp:TextBox ID="DetailsTextBox" CssClass="input-field" runat="server" OnTextChanged="DetailsTextBox_TextChanged" Height="60px" Width="600px"></asp:TextBox>
    <asp:TextBox ID="EducationTextBox" CssClass="input-field" runat="server" OnTextChanged="EducationTextBox_TextChanged" Height="60px" Width="600px"></asp:TextBox>
    <asp:TextBox ID="EmploymentTextBox" CssClass="input-field" runat="server" OnTextChanged="EmploymentTextBox_TextChanged" Height="60px" Width="600px"></asp:TextBox>


</asp:Content>
