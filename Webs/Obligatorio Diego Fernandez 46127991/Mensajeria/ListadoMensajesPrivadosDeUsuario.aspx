<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoMensajesPrivadosDeUsuario.aspx.cs" Inherits="ListadoMensajesPrivadosDeUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" 
        style="height: 1819px; background-image: url('Imagenes/abstracto.jpg');">
    
        <div style="font-family: 'Segoe Print'; font-size: xx-large; text-decoration: underline; color: #00FFFF">
            Listado de Mensajes Privados</div>
        <br />
        <br />
        <table align="center" 
            style="width: 100%; font-family: 'Segoe Print'; font-size: small;">
            <tr>
                <td class="style2">
                </td>
                <td align="center" class="style2">
        <asp:DropDownList ID="DdlUsuarios" runat="server" AutoPostBack="True" 
                        Font-Names="Segoe Print" BackColor="#D0F0FF">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DdlEnviaORecibe" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DdlEnviaORecibe_SelectedIndexChanged" Font-Names="Segoe Print" 
                        BackColor="#D0F0FF">
            <asp:ListItem Value="N/D">-------</asp:ListItem>
            <asp:ListItem Value="1">Enviados</asp:ListItem>
            <asp:ListItem Value="2">Recibidos</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
        <asp:GridView ID="GvPrivados" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Font-Names="Segoe Print" Width="955px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CargoUsuario.Nombre" HeaderText="Usuario" />
                <asp:BoundField DataField="cargoDest.Nombre" HeaderText="Destinatario" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td align="center" class="style1">
                    <br />
        <asp:Label ID="lblError" runat="server" Font-Names="Segoe Print"></asp:Label>
                </td>
                <td class="style1">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
        <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                        Font-Names="Segoe Print" ForeColor="Aqua">Volver</asp:LinkButton>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
&nbsp;</div>
    <p>
        &nbsp;</p>
    <p align="center">
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p align="center">
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form>
    </body>
</html>
