<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoTiposMensjaes.aspx.cs" Inherits="MantenimientoTiposMensjaes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 906px">
    <form id="form1" runat="server">
    <div align="center" 
        
        style="height: 1521px; background-image: url('Imagenes/abstracto.jpg'); font-family: 'Segoe Print';">
    
        <div style="font-size: xx-large; text-decoration: underline; color: #00FFFF">
    
        &nbsp;Mantenimiento de Tipos de Mensaje</div>
        <br />
        <br />
        <br />
        <table align="left" style="width: 100%; height: 229px;">
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style5" style="color: #FFFFFF">
&nbsp;Código:</td>
                <td align="left" class="style4">
                    <asp:TextBox ID="txtCodigo" runat="server" BackColor="#D0F0FF"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
                        onclick="BtnBuscar_Click" BorderColor="White" BorderStyle="None" 
                        Font-Names="Segoe Print" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style5" style="color: #FFFFFF">
                    Nombre del Código:</td>
                <td align="left" class="style4">
                    <asp:TextBox ID="txtNombreCodigo" runat="server" BackColor="#D0F0FF"></asp:TextBox>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1" colspan="3">
                    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" 
                        onclick="BtnAgregar_Click" BorderColor="White" BorderStyle="None" 
                        Font-Names="Segoe Print" ForeColor="Red" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BtnModificar" runat="server" Text="Modificar" 
                        onclick="BtnModificar_Click" BorderColor="White" BorderStyle="None" 
                        Font-Names="Segoe Print" ForeColor="Red" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
                        onclick="BtnEliminar_Click" BorderColor="White" BorderStyle="None" 
                        Font-Names="Segoe Print" ForeColor="Red" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="BtnLimpiar" runat="server" 
                        onclick="BtnLimpiar_Click" Text="Limpiar" BorderColor="White" 
                        BorderStyle="None" Font-Names="Segoe Print" ForeColor="Red" />
                </td>
            </tr>
        </table>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
            ForeColor="Aqua">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
