<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="EnvioEmails.aspx.cs" Inherits="ToolAdmin.EnvioEmails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FileUpload ID="fuCargaCSV" runat="server" />
    <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" />

    <asp:GridView ID="grvEmails" runat="server"></asp:GridView>

    <asp:Button ID="btnEnviaEmails" runat="server" Text="Enviar Emails" OnClick="btnEnviaEmails_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
