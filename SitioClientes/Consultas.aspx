<%@ Page Title="Consultas | Tramites Online" Language="C#" MasterPageFile="~/MPSolicitantes.master" AutoEventWireup="true" CodeFile="Consultas.aspx.cs" Inherits="Consultas" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="max-height">
        <h3 class="text-blue margin-left-sm margin-top-sm">Consulta tipo de tramites</h3>

        <h5 class="text-blue margin-left-sm margin-top-xs">En esta consulta puede visualizar la informacion necesaria y otros datos para cada tipo de tramite.</h5>

        <div id="filtros" style="margin-left: 5%; width: 33%;">
            <table>                
                <tr>
                    <td style="width: 29% !important;">
                        <asp:Label ID="Label2" runat="server" Text="Precio minimo"></asp:Label>
                        <asp:TextBox ID="txtPrecioDesde" runat="server" style="height: 19px;"></asp:TextBox>                        
                    </td>
                    <td style="width: 29% !important;">
                        <asp:Label ID="Label3" runat="server" Text="Precio maximo"></asp:Label>
                        <asp:TextBox ID="txtPrecioHasta" runat="server" style="height: 19px;"></asp:TextBox>        
                    </td>
                    <td style="width: 29% !important;">
                        <asp:Label ID="Label4" runat="server" Text="Año"></asp:Label>
                        <asp:DropDownList ID="ddlAnio" runat="server"></asp:DropDownList>                        
                    </td>
                    <td style="width: 13% !important; margin-top: 17px;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style="height: 25px;" />
                    </td>
                </tr>
            </table>
        </div>

        <div id="containterTipoTramites" style="margin-left: 3%; overflow: auto; height: 180px; width: 50%;">
            <table id="tblTipoTramites" class="margin-left-sm margin-top-xs">
                <tbody>
                    <tr>
                        <td class="margin-top-xs">
                            <asp:Repeater ID="rptTiposTramite" runat="server" OnItemCommand="rptTiposTramite_ItemCommand">
                                <HeaderTemplate>
                                    <table id="tblRptTipoTramites" cellspacing="0">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 60%;">
                                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("Nombre") %>' />
                                        </td>
                                        <td style="width: 40%;">
                                            <asp:LinkButton ID="lnkVerTipoTramite" CssClass="btn lnk" runat="server" CommandName="VerTipoTramite" CommandArgument='<%# Eval("Codigo") %>'>Ver información</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </td>
                    </tr>                    
                </tbody>
            </table>
        </div>

        <div id="infoTipoTramite" class="margin-left-sm margin-top-xs">
            <h3>Información del tipo de tramite seleccionado.</h3>
            <asp:Xml ID="xmlTipoDoc" runat="server" TransformSource="~/App_Data/TipoTramite.xslt"></asp:Xml>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>


    </div>
</asp:Content>

