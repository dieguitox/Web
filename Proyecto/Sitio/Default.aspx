<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 1168px">
    <form id="form1" runat="server">
    <div align="center" 
        
        style="margin-left: 1px; background-color: #FFCCCC; font-family: 'Segoe Print'; color: #FFFFFF; background-image: url('Imagenes/abstracto.jpg'); font-size: medium; height: 1165px;">
    
        <asp:ImageButton ID="ImageButton1" runat="server" Height="204px" 
            Width="900px" ImageUrl="~/Imagenes/logo(1).png" />
        <br />
        <br />
        Página Principal<br />
        <br />
        <asp:LinkButton ID="LnkBtnMantenimientoUsuarios" runat="server" 
            PostBackUrl="~/MantenimientoUsuarios.aspx" ForeColor="Aqua">Mantenimiento Usuarios</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LnkBtnMantenimientoTiposMensajes" runat="server" 
            PostBackUrl="~/MantenimientoTiposMensjaes.aspx" ForeColor="Aqua">Mantenimiento Tipos de Mensajes</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LnlBtnAgregarMensajePrivado" runat="server"  
            PostBackUrl="~/AgregarMensajePrivado.aspx" ForeColor="Aqua">Agregar Mensaje Privado</asp:LinkButton>
    
        <br />
        <asp:LinkButton ID="LnkBtnAgregarMensajeComun" runat="server" 
            PostBackUrl="~/AgregarMensajeComun.aspx" ForeColor="Aqua">Agregar Mensaje Común</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LnkBtnLsitadoMEnsajesComunesdeunUsuario" runat="server" 
            PostBackUrl="~/ListadoMensajeComunesdeUsuario.aspx" ForeColor="Aqua">Listado de Mensajes Comunes de un Usuario</asp:LinkButton>
    
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" 
            PostBackUrl="~/ListadoMensajesPrivadosDeUsuario.aspx" ForeColor="Aqua">Listado Mensajes Privados de un Usuario</asp:LinkButton>
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
