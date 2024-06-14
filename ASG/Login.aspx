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
                                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox><br/>
                                    <asp:Label ID="lblpwd" runat="server" Text="Ingrese Contraseña"></asp:Label><br />
                                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br/>
                                    <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnIngresar_Click" />
                       </div>      
                       </div>
                    </div>
                </div>
            </div>
        </section>

    </main>

</asp:Content>