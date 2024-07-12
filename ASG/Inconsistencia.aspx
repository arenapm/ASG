<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inconsistencia.aspx.cs" Inherits="ASG.Inconsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container text-center">
            <div class="row">
                <section class="col-sm-12" aria-labelledby="aspnetTitle">
                    <h1 id="aspnetTitle">Inconsistencias</h1>
                    <p class="lead">Visualizacion de Inconsistencias</p>
                </section>
            </div>
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-6">
                    <h2>Inconsistencias Sorteos</h2>
                    <asp:GridView ID="GridView1" runat="server" CssClass="table"></asp:GridView>
                </div>
                <div class="col-sm-6">
                    <h2>Inconsistencias Ganadores</h2>
                    <asp:GridView ID="GridView2" runat="server" CssClass="table"></asp:GridView>
                </div>
            </div>
        </div>
        <div class="container text-center ">
            <div class="row">
                <div class="col-sm-6">
                    <asp:Button ID="btnSolucionar" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Solucionar Inconsistencias" OnClick="btnSolucionar_Click" />
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="btnEliminar" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Eliminar inconsistencias" OnClick="btnEliminar_Click" />
                </div>
            </div>
        </div>
    </main>

</asp:Content>
