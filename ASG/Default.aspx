<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <div class="container text-center">
                <div class="row">
                    <div class="col-sm-12">
                        <h1 id="aspnetTitle">ASG Sorteos</h1>
                        <p class="lead">Plataforma de gestión y administración de sorteos.</p>
                        <hr class="border-black border-3" />
                    </div>
                </div>
            </div>
            <br />
            <div class="container text-center">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                            <div class="card mb-4 bg-danger text-white">
                                <div class="card-body text-center">
                                    <h2 class="card-title">PROBELMAS DE INCONSISTENCIA</h2>
                                    <p class="card-text">Se encontraron inconsistencias en la base de datos, se requiere accion inmediata.</p>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="container text-center">
                <div class="row">
                    <div class="col-sm-6">
                        <h4>Ultimos Sorteos Añadidos</h4>
                        <hr class="border-black border-3" />
                        <div>
                            <asp:GridView ID="GridView1"  CssClass="table" runat="server" OnRowDataBound="GridView1_RowDataBound1"></asp:GridView>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <h4>Ultimos Ganadores</h4>
                        <hr class="border-black border-3" />
                        <div>
                            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </main>

</asp:Content>
