<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ASG.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <h1>Bienvenido al Carrito de Compras</h1>
                    <hr class="border border-danger mb-3" />
                </div>
                <hr class="border-black" />
            </div>
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <div class="card mb-4 bg-success text-white">
                            <div class="card-body text-center">
                                <h2 class="card-title">AVISO</h2>
                                <p class="card-text">Actualmente no posee ninguna inscripcion en el carrito</p>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Premio" HeaderText="Premio" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel3" runat="server" Visible="false">
                        <p>Subtotal</p>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
