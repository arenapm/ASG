<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="ASG.Bitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <div class="col-sm-12">
                <h1 id="aspnetTitle">Bitacora</h1>
                <p class="lead">Visualización de eventos del sistema</p>
            </div>
        </section>
        <section class="row">
            <div class="col-sm-4 d-flex align-items-end">
                <label for="txtFechaInicial">Fecha Inicial:</label>
                <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-sm-4 d-flex align-items-end">
                <label for="txtFechaFinal">Fecha Final:</label>
                <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-sm-2 d-flex align-items-end">
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Filtrar" OnClick="btnFiltrar_Click" />
            </div>
            <div class="col-sm-2 d-flex align-items-end">
                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="Reset" OnClick="btnReset_Click" />
            </div>
        </section>
        <section class="row">
            <div class="col-sm-12">
                <asp:GridView ID="GridView1" AllowPaging="True" PageSize="15" runat="server" CssClass="table" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </section>
    </main>

</asp:Content>
