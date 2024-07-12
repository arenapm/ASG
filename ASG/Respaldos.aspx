<%@ Page Title="Respaldos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldos.aspx.cs" Inherits="ASG.Respaldos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <div class="container text-center">
                <br />
                <asp:Button ID="Respaldar" runat="server" Text="Realizar copia de seguridad" OnClick="Respaldar_Click" /><br /><br /><br />
                <asp:FileUpload ID="fileUpload" runat="server" />
                <asp:Button ID="Restaurar" runat="server" Text="Restaurar copia de seguridad" OnClick="Restaurar_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>

        </section>

    </main>

</asp:Content>
