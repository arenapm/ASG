<%@ Page Title="Respaldos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respaldos.aspx.cs" Inherits="ASG.Respaldos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <br />
            <table style="margin: auto">
                <tr>
                    <td>
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-lg-auto text-center">
                                    <div class="card card mb-4">
                                        <div class="card-header">
                                            <h2>Respaldar base de datos</h2>
                                        </div>
                                        <div class="card-body">
                                            <asp:Button ID="Respaldar" runat="server" CssClass="btn btn-primary" Text="Descargar backup" OnClick="Respaldar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-lg-auto text-center">
                                    <div class="card card mb-4">
                                        <div class="card-header">
                                            <h2>Restaurar base de datos</h2>
                                        </div>
                                        <div class="card-body">
                                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="btn btn-primary" />
                                            <asp:Button ID="Restaurar" runat="server" CssClass="btn btn-primary" Text="Restaurar backup" OnClick="Restaurar_Click" />
                                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>

            <div class="container text-center">
                <br />

            </div>

        </section>

    </main>

</asp:Content>
