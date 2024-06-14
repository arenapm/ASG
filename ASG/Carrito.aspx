<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ASG.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="aspnetTitle">ASG Sorteos</h1>
        <asp:Label ID="lbllogout" runat="server"/>
            <div class="container mt-5">
                 <h1 class="text-center mb-4">Carrito de Sorteos</h1>

                        <div class="card mb-4 bg-danger text-white">
            <div class="card-body text-center">
                <h2 class="card-title">Contenido No Disponible</h2>
                <p class="card-text">Actualmente estamos trabajando en el proceso de compras de sorteos, intentelo nuevamente mas tarde.</p>
                <p class="card-text">Disculpe las molestias ocasionadas.</p>
            </div>
        </div>
          </div>
    </section>
</main>
</asp:Content>
