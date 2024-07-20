<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sorteo.aspx.cs" Inherits="ASG.Sorteo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1 class="text-center mb-4">Registro de Sorteo</h1>
        <div class="row justify-content-center">
            <div class="col-lg-auto text-center">
                <div class="card card mb-4">
                    <div class="card-body">
                        <asp:Label ID="lblFecha" CssClass="alert-warning" runat="server" Visible="false" Text="Debe ingresar una fecha correcta"></asp:Label>
                        <form method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <div class="form-group">
                                <label for="txtNombre">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtFecha">Fecha del Sorteo</label>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="ddlCantidadParticipantes">Cantidad de Participantes Máxima</label>
                                <asp:DropDownList ID="ddlCantidadParticipantes" runat="server" CssClass="form-control" required>
                                    <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                                    <asp:ListItem Value="35">35</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="txtDescripcion">Descripción del Sorteo</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtValorEntrada">Valor de Entrada al Sorteo</label>
                                <asp:TextBox ID="txtValorEntrada" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtDescripcion">Descripcion del premio</label>
                                <asp:TextBox ID="txtPremio" runat="server" CssClass="form-control" TextMode="MultiLine" required></asp:TextBox>
                            </div>
                            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

