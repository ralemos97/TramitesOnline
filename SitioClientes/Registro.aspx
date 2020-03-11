<%@ Page Title="" Language="C#" MasterPageFile="~/MPSolicitantes.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="container-login">

        <div id="titulo-login">
            <h2 id="titulo-tramites" class="color-titulo text-center position-absolute">Tramites <strong>ONLINE</strong></h2>
        </div>

        <div class="description-login">
            <strong>COMPLETA LOS DATOS DE REGISTRO</strong>
        </div>

        <table id="tableControls-login">
            <tr>
                <td>
                    <div class="maring-top-md">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/user-login.png" />
                        </div>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="input-user-login" placeholder="Nombre completo" MaxLength="50"></asp:TextBox>                        
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="maring-top-sm">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/carnet-de-identidad.png" />
                        </div>
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="input-user-login" placeholder="Documento" MaxLength="8"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="maring-top-sm">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/telefono.png" />
                        </div>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="input-user-login" placeholder="Teléfono" MaxLength="10"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="maring-top-sm">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/user-password.png" />
                        </div>
                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="input-user-login" placeholder="Contraseña" MaxLength="6" TextMode="Password"></asp:TextBox>
                    </div>

                </td>
            </tr>
            <tr>
                <td>
                    <div class="maring-top-sm">
                        <div class="div-image-user">
                            <img class="img-size img-login" src="img/user-password.png" />
                        </div>
                        <asp:TextBox ID="txtContrasenaValid" runat="server" CssClass="input-user-login" placeholder="Repetir Contraseña" MaxLength="6" TextMode="Password"></asp:TextBox>
                    </div>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegistro" CssClass="btnRegistro" runat="server" Text="Registrarme" OnClick="btnRegistro_Click" />
                </td>
            </tr>
            <tr>
                <td class="text-center margin-bottom-sm">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

