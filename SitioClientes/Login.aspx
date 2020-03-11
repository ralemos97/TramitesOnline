<%@ Page Title="" Language="C#" MasterPageFile="~/MPSolicitantes.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="container-login">

        <div id="titulo-login">
            <h2 id="titulo-tramites" class="color-titulo text-center position-absolute">Tramites <strong>ONLINE</strong></h2>
        </div>

        <div class="description-login">
            <strong>INICIAR SESIÓN</strong>
        </div>

        <table id="tableControls-login">
            <tr>
                <td>
                    <div class="maring-top-md">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/user-login.png" />
                        </div>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-user-login" placeholder="Usuario" MaxLength="8"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="ctr-user-password">
                        <div class="div-image-user">
                            <img class="img-size" src="img/user-password.png" />
                        </div>
                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="input-user-login" placeholder="Contraseña" MaxLength="6" TextMode="Password"></asp:TextBox>
                    </div>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnIngresar" CssClass="btnIngreso" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" />
                </td>
            </tr>
            <tr>
                <td class="text-center" id="ctr-register">
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

