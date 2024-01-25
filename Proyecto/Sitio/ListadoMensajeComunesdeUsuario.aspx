<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoMensajeComunesdeUsuario.aspx.cs" Inherits="ListadoMensajeComunesdeUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" 
        
        style="height: 1164px; font-family: 'Segoe Print'; color: #00FFFF; font-size: xx-large; background-image: url('Imagenes/abstracto.jpg');">
    
        Listado de Mensajes Comunes<br />
        <br />
        <table style="width:100%;">
            <tr>
                <td align="center" class="style1">
        <asp:DropDownList ID="DdlUsuarios" runat="server" AutoPostBack="True" 
                        Font-Names="Segoe Print" Height="30px" Width="127px" BackColor="#D0F0FF">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:DropDownList ID="DdlTipodeMensaje" runat="server" 
                        Font-Names="Segoe Print" BackColor="#D0F0FF">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DdlEnviaORecibe" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DdlEnviaORecibe_SelectedIndexChanged" Font-Names="Segoe Print" 
                        Width="127px" BackColor="#D0F0FF">
            <asp:ListItem Value="N/D">--------</asp:ListItem>
            <asp:ListItem Value="1">Enviados</asp:ListItem>
            <asp:ListItem Value="2">Recibidos</asp:ListItem>
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" style="font-size: small; font-family: 'Segoe Print'" 
                    class="style1">
        <asp:GridView ID="GvComunes" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="980px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CargoUsuario.Nombre" HeaderText="Usuario" />
                <asp:BoundField DataField="CargoDest.Nombre" HeaderText="Destinatario" />
                <asp:BoundField ApplyFormatInEditMode="True" DataField="Codigo.Nombre" 
                    HeaderText="Código" ReadOnly="True" />
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
            </tr>
            <tr>
                <td align="center" class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="font-size: small; font-family: 'Segoe Print'" 
                    class="style1">
        <asp:Label ID="lblError" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" 
                    
                    style="font-family: 'Segoe Print'; font-size: small; color: #00FFFF; text-decoration: underline;" 
                    class="style1">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
        <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
                        ForeColor="Aqua">Volver</asp:LinkButton>
    
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
