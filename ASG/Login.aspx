<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASG.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <br />
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-auto text-center">
                        <div class="card card mb-4">
                            <div class="card-header">
                                <h2>Iniciar Sesión</h2>
                            </div>
                            <div class="card-body">
                                <asp:Literal ID="warningMessage" runat="server" Visible="false"></asp:Literal>
                                <asp:Label ID="lblUsuario" runat="server" Text="Ingrese Usuario"></asp:Label><br />
                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox><br />
                                <asp:Label ID="lblpwd" runat="server" Text="Ingrese Contraseña"></asp:Label><br />
                                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br />
                                <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnIngresar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container text-center">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                            <div class="card mb-4 bg-danger text-white">
                                <div class="card-body text-center">
                                    <h2 class="card-title">USUARIO BLOQUEADO</h2>
                                    <p class="card-text">Su usuario fue bloqueado por intentar ingresar a herramientas administrativas sin un permiso.</p>
                                    <p class="card-text">Contactese con el soporte para llevar adelante su caso.</p>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </section>

    </main>

</asp:Content>
