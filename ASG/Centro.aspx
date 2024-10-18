<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Centro.aspx.cs" Inherits="ASG.Centro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <h1>Bienvenido al centro de Gestion ASG</h1>
                    </div>
                    <hr class="border-black" />
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:Button ID="btnBitacora" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Bitacora"  OnClick="btnBitacora_Click" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnRespaldos" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Respaldos"  OnClick="btnRespaldo_Click"  />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnDesbloqueos" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Inconsistencias"  OnClick="btnInconsistencia_Click"  />
                    </div>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <h2>Usuarios Bloqueados</h2>
                        <asp:GridView ID="GridView1" runat="server"  OnRowDataBound="GridView1_RowDataBound1" CssClass="table"/>
                    </div>
                </div>
            </div>
        </section>

    </main>

</asp:Content>
