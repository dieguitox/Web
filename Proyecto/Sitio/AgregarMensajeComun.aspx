<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarMensajeComun.aspx.cs" Inherits="AgregarMensajeComun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 889px">
    <form id="form1" runat="server" 
    
    style="background-color: #00FFCC; background-image: url('Imagenes/abstracto.jpg'); height: 893px;">
    <div align="center" 
        
        style="font-family: &quot;Segoe Print&quot;; font-size: xx-large; color: #00CCFF; text-decoration: underline;">
        Agregar Mensaje Comun</div>
    <br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style1" 
                style="font-family: 'Segoe Print'; color: #FFFFFF; font-size: medium">
                Nombre :</td>
            <td class="style4">
                <asp:TextBox ID="txtUsuario" runat="server" Width="315px" 
                    BorderStyle="None"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnNombre" runat="server" Text="Agregar" 
                    onclick="btnNombre_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Italic="False" 
                    Font-Names="Segoe Print" Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1" 
                style="font-family: 'Segoe Print'; color: #FFFFFF; font-size: medium">
                Destinatario :</td>
            <td class="style5">
                <asp:TextBox ID="txtDestinatario" runat="server" Width="315px" 
                    BackColor="#D0F0FF" BorderStyle="None"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnDestinatario" runat="server" Text="Agregar" 
                    onclick="btnDestinatario_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Italic="False" 
                    Font-Names="Segoe Print" Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" 
                style="font-family: 'Segoe Print'; color: #FFFFFF; font-size: medium">
                Código:</td>
            <td class="style5">
                <asp:TextBox ID="txtCodigo" runat="server" Width="315px" BackColor="#D0F0FF" 
                    BorderStyle="None"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnCodigo" runat="server" Text="Agregar" 
                    onclick="btnCodigo_Click" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Italic="False" 
                    Font-Names="Segoe Print" Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" 
                style="font-family: 'Segoe Print'; color: #FFFFFF; font-size: medium">
                Asunto:</td>
            <td class="style5">
                <asp:TextBox ID="txtAsunto" runat="server" Width="759px" BackColor="#D0F0FF" 
                    BorderStyle="None"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" 
                style="font-family: 'Segoe Print'; color: #FFFFFF; font-size: medium">
                Texto:</td>
            <td class="style5">
                <asp:TextBox ID="txtTexto" runat="server" Height="228px" Width="759px" 
                    BackColor="#D0F0FF" BorderStyle="None"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                </td>
            <td class="style6" align="char">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    onclick="btnEnviar_Click1" BackColor="White" BorderColor="White" 
                    BorderStyle="Outset" Font-Bold="True" Font-Italic="False" 
                    Font-Names="Segoe Print" Font-Size="Smaller" ForeColor="Red" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" BackColor="White" BorderColor="White" BorderStyle="Outset" 
                    Font-Bold="True" Font-Italic="False" Font-Names="Segoe Print" 
                    Font-Size="Smaller" ForeColor="Red" />
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style6" align="char">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblError" runat="server" Font-Names="Segoe Print"></asp:Label>
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style6" align="char">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
        BorderColor="#00CCFF" Font-Bold="True" Font-Names="Segoe Print" 
        ForeColor="Aqua">Volver</asp:LinkButton>
    </form>
</body>
</html>
