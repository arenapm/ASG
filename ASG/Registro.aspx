<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ASG.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section aria-labelledby="aspnetTitle">
            <br />
<div class="container mt-5">
        <h1 class="text-center mb-4">Registro de Usuario</h1>
        <div class="row justify-content-center">
            <div class="col-lg-auto text-center">
                <div class="card card mb-4">
                    <div class="card-body">
                        <form method="post">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Visible="false" CssClass="alert" EnableViewState="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="usuario">Usuario</label>
                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox><br/>
                            </div>
                            <div class="form-group">
                                <label for="password">Contraseña</label>
                                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br/>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe contener entre 3 y 20 caracteres" ControlToValidate="txtpwd" ValidationExpression="\w{3,20}" Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator><br/>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Debe contener al menos un número y un caracter" ControlToValidate="txtpwd" ValidationExpression="[a-zA-Z]+\w*\d+w*" Font-Size="XX-Small" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="confirm_password">Repetir Contraseña</label>
                                <asp:TextBox ID="txtpwd1" runat="server" TextMode="Password" CssClass="form-control" OnTextChanged="txtpwd1_TextChanged"></asp:TextBox><br/>
                                <asp:Label ID="pass2" runat="server" Text="Las contraseñas no coinciden" Font-Size="XX-Small" ForeColor="Red" Visible="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="email">Correo Electrónico</label>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox><br/>
                            </div>
                            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </section>

    </main>

</asp:Content>