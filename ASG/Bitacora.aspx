<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="ASG.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">Bitacora</h1>
        <p class="lead">Visualización de eventos del sistema</p>
    </section>
    <asp:GridView ID="GridView1" runat="server" CssClass="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

    </asp:GridView>
     <section>

        </section>
</main>

</asp:Content>
