<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marketing.aspx.cs" Inherits="ASG.Marketing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="container ">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <h1>Bienvenido/a al centro de Marketing ASG</h1>
                    <hr class="border border-danger mb-3" />
                </div>
                <hr class="border-black" />
            </div>
            <div class="row justify-content-center shadow p-3 mb-3 bg-white rounded">
                <div class="col-sm-6 d-flex justify-content-center">
                    <asp:Button ID="btnGenerar" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Generar Reporte" OnClick="btnGenerar_Click" />
                </div>
                <div class="col-sm-6 d-flex justify-content-center">
                    <asp:Button ID="btnDescargar" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Visualizar Ultimo Reporte" OnClick="btnDescargar_Click" />
                </div>
                <hr class="border-black" />
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <div class="card mb-4 bg-danger text-white">
                            <div class="card-body text-center">
                                <h2 class="card-title">ATENCION</h2>
                                <p class="card-text">No se encontro ningun reporte existente, porfavor genere uuno.</p>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel3" runat="server" Visible="false">
                        <div class="card mb-4 bg-success text-white">
                            <div class="card-body text-center">
                                <h2 class="card-title">Creacion Exitosa</h2>
                                <p class="card-text">El reporte se creo con exito</p>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:GridView CssClass="table" ID="GridView1" runat="server">
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
