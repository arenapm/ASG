<%@ Page Title="Respaldos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldos.aspx.cs" Inherits="ASG.Respaldos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <div class="container text-center">
                <asp:Button ID="Respaldar" runat="server" Text="Respaldar" OnClick="Respaldar_Click" /><br />
                <asp:Button ID="Restaurar" runat="server" Text="Restaurar" OnClick="Restaurar_Click" />
            </div>

        </section>

    </main>

</asp:Content>
