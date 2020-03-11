<%@ Page Title="Solicitudes | Tramites Online" Language="C#" MasterPageFile="~/MPSolicitantes.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="max-height">
        <h3 class="text-blue margin-left-sm margin-top-sm">Nueva Solicitud</h3>
        
        <h5 class="text-blue margin-left-sm margin-top-xs">Complete los siguientes datos para realizar el registro de la solicitud.</h5>

        <table id="tblSolicitud" class="margin-left-sm margin-top-xs"> 
            <tbody>
                <tr>
                    <td class="margin-top-xs">
                        <label>Tipo de tramite</label>
                    </td>
                    <td class="margin-top-xs">
                        <asp:DropDownList ID="ddlTipoTramite" runat="server" CssClass="ddlTipoTramite" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoTramite_SelectedIndexChanged"></asp:DropDownList>                        
                    </td>
                </tr>                
                <tr>
                    <td class="margin-top-xs">
                        <label>Fecha tramite</label>
                    </td>
                    <td class="margin-top-xs">
                        <cc1:CustomCalendar ID="calendarFechaTramite" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td class="margin-top-xs">
                        <label>Hora tramite</label>
                    </td>
                    <td class="margin-top-xs">
                        <cc1:CustomHoraMinutos ID="solHoraMinutos" runat="server" />                        
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="lblDocRequeridos" runat="server" Text="" CssClass="lblDocRequeridos"></asp:Label></td>
                </tr>
                <tr>
                    <td class="margin-top-xs">                        
                    </td>
                    <td class="margin-top-xs">                        
                        <asp:Button ID="btnGuardar" CssClass="btn" runat="server" Text="Solicitar" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>                        
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>                
            </tbody>
        </table>
    </div>
    
</asp:Content>

