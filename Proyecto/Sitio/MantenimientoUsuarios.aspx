<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoUsuarios.aspx.cs" Inherits="MantenimientoUsuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 638px">
    <form id="form1" runat="server">
    <div align="center" 
        style="height: 1835px; background-image: url('Imagenes/abstracto.jpg');">
    
        <div style="font-family: 'Segoe Print'; color: #00FFFF; text-decoration: underline; font-size: xx-large; height: 83px;">
    
        &nbsp;Mantenimiento de Usuarios<br />
        </div>
    
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style2" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td class="style1" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2" 
                    style="font-family: 'Segoe Print'; font-size: medium; color: #FFFFFF;">
                    Nombre de usuario:</td>
                <td align="left" class="style1" 
                    style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="375px" BackColor="#D0F0FF"></asp:TextBox>
                </td>
                <td align="left" style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
                        onclick="BtnBuscar_Click" BorderColor="White" BorderStyle="Outset" 
                        Font-Bold="True" Font-Names="Segoe Print" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style2" 
                    style="font-family: 'Segoe Print'; font-size: medium; color: #FFFFFF;">
                    Nombre Completo:</td>
                <td align="left" class="style1" 
                    style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:TextBox ID="txtNombre" runat="server" Width="374px" BackColor="#D0F0FF"></asp:TextBox>
                </td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2" 
                    style="font-family: 'Segoe Print'; font-size: medium; color: #FFFFFF;">
                    Cédula:</td>
                <td align="left" class="style1" 
                    style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:TextBox ID="txtCedula" runat="server" Width="376px" BackColor="#D0F0FF"></asp:TextBox>
                </td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td class="style1" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td class="style1" style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td class="style1" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
                <td class="style1" style="font-family: 'Segoe Print'; font-size: medium">
                    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" 
                        onclick="BtnAgregar_Click" BorderColor="White" BorderStyle="Outset" 
                        Font-Bold="True" Font-Names="Segoe Print" ForeColor="Red" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" 
                        onclick="BtnModificar_Click" BorderColor="White" BorderStyle="Outset" 
                        Font-Bold="True" Font-Names="Segoe Print" ForeColor="Red" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
                        onclick="BtnEliminar_Click" BorderColor="White" BorderStyle="Outset" 
                        Font-Bold="True" Font-Names="Segoe Print" ForeColor="Red" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" 
                        onclick="BtnLimpiar_Click" BorderColor="White" BorderStyle="Outset" 
                        Font-Bold="True" Font-Names="Segoe Print" ForeColor="Red" />
                </td>
                <td style="font-family: 'Segoe Print'; font-size: medium">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
            Font-Names="Segoe Print" ForeColor="Aqua">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
