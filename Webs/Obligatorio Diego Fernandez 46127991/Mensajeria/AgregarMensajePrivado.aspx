<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarMensajePrivado.aspx.cs" Inherits="AgregarMensajePrivado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 889px">
    <form id="form1" runat="server" 
    
    style="background-color: #BEDEDE; background-image: url('Imagenes/abstracto.jpg'); height: 885px;">
    <div align="center" 
        
        style="font-family: 'Segoe Print'; font-size: xx-large; color: #33CCFF; text-decoration: underline;">
    Agregar Mensaje Privado</div>
    <br />
    <table style="width:100%; height: 531px;" align="center">
        <tr>
            <td class="style2" style="font-family: 'Segoe Print'; color: #FFFFFF">
                Nombre:</td>
            <td class="style2">
                <asp:TextBox ID="txtUsuario" runat="server" Width="313px" BackColor="#D0F0FF" 
                    BorderStyle="None"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btnNombre" runat="server" Text="Ingresar" 
                    onclick="btnNombre_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Names="Segoe Print" 
                    Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style1" style="font-family: 'Segoe Print'; color: #FFFFFF">
                Destinatario:</td>
            <td class="style1">
                <asp:TextBox ID="txtDestinatario" runat="server" Width="313px" 
                    BackColor="#D0F0FF" BorderStyle="None"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btnDestinatario" runat="server" Text="ingresar" 
                    onclick="btnDestinatario_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Names="Segoe Print" 
                    Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td class="style4" style="font-family: 'Segoe Print'; color: #FFFFFF">
                Asunto:</td>
            <td class="style4">
                <asp:TextBox ID="txtAsunto" runat="server" Width="915px" BackColor="#D0F0FF" 
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style6" style="font-family: 'Segoe Print'; color: #FFFFFF">
                Texto:</td>
            <td class="style6">
                <asp:TextBox ID="txtTexto" runat="server" Height="246px" Width="915px" 
                    BackColor="#D0F0FF" BorderStyle="None"></asp:TextBox>
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style1" align="     ">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    onclick="btnEnviar_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Names="Segoe Print" 
                    Font-Size="Smaller" ForeColor="Red" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" BackColor="White" BorderColor="White" BorderStyle="Outset" 
                    Font-Bold="True" Font-Names="Segoe Print" Font-Size="Smaller" ForeColor="Red" />
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style5" align="                               ">
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblError" runat="server" Font-Names="Segoe Print"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
        Font-Bold="True" Font-Names="Segoe Print" Font-Overline="False" 
        Font-Strikeout="False" Font-Underline="True" ForeColor="Aqua">Volver</asp:LinkButton>
    </form>
</body>
</html>
