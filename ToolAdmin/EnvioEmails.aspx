<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="EnvioEmails.aspx.cs" Inherits="ToolAdmin.EnvioEmails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FileUpload ID="fuArchivo" runat="server" />
    <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" />

    <asp:GridView ID="grvEmails" runat="server"></asp:GridView>

    <br />
    <p>Email to</p>
    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
    <p>Subject</p>
    <asp:TextBox ID="txtSubject" runat="server" Width="100%" ></asp:TextBox>
    <p>Body</p>
    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="300px" Width="100%"></asp:TextBox>
    <asp:Button ID="btnEnviaEmails" runat="server" Text="Enviar Emails" OnClick="btnEnviaEmails_Click" />
    <asp:Label ID="lblResultado" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
