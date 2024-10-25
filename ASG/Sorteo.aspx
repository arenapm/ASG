<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sorteo.aspx.cs" Inherits="ASG.Sorteo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-12 text-center">
                <h1>Bienvenido al registro de sorteo Marketing ASG</h1>
                <hr class="border border-danger mb-3" />
            </div>
            <hr class="border-black" />
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-12">
                    <p class="card-text">Tabla Sorteos.</p>
                    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Premio" HeaderText="Premio" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="CantPart" HeaderText="Cantidad de Participantes" />
                            <asp:BoundField DataField="Valor" HeaderText="Valor" />
                            <asp:ButtonField ButtonType="Button" Text="Inscribirse" CommandName="Inscribirse" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

