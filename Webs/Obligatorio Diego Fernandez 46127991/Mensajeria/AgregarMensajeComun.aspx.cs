using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;

public partial class AgregarMensajeComun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
            LimpioFormulario();
    }

    private void LimpioFormulario()
    {

        btnNombre.Enabled = true;
        btnDestinatario.Enabled = false;
        btnCodigo.Enabled = false;
        btnEnviar.Enabled = false;

        txtUsuario.Text = "";
        txtUsuario.Enabled = true;
        txtDestinatario.Text = "";
        txtDestinatario.Enabled = false;
        txtCodigo.Text = "";
        txtCodigo.Enabled = false;
        txtAsunto.Text = "";
        txtAsunto.Enabled = false;
        txtTexto.Text = "";
        txtTexto.Enabled = false;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }

    protected void btnNombre_Click(object sender, EventArgs e)
    {
        try
        {
            string usuario = "";

            usuario = txtUsuario.Text;

            Usuario Nom = LogicaUsuarios.Buscar(usuario);

            if (Nom is Usuario)
            {
                txtDestinatario.Enabled = true;
                btnDestinatario.Enabled = true;
            }
            else
            {
                lblError.ForeColor = Color.Blue;
                lblError.Text = "El usuario no es valido";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }

    }

    protected void btnDestinatario_Click(object sender, EventArgs e)
    {
        try
        {
            string dest = "";

            dest = txtDestinatario.Text;

            Usuario Destina = LogicaUsuarios.Buscar(dest);

            if (Destina is Usuario)
            {
                txtCodigo.Enabled = true;
                btnCodigo.Enabled = true;
            }
            else
            {
                lblError.ForeColor = Color.Blue;
                lblError.Text = "El destinatario no es valido";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnCodigo_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = "";

            codigo = txtCodigo.Text;

            TiposDeMensaje Cod = LogicaMensajes.Buscar(codigo);

            if (Cod is TiposDeMensaje)
            {
                txtAsunto.Enabled = true;
                txtTexto.Enabled = true;

                btnEnviar.Enabled = true;
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "El codigo no es valido";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnEnviar_Click1(object sender, EventArgs e)
    {
        try
        {
            Usuario nombre = (Usuario)LogicaUsuarios.Buscar(txtUsuario.Text.Trim());
            Usuario dest = (Usuario)LogicaUsuarios.Buscar(txtDestinatario.Text.Trim());
            TiposDeMensaje cod = (TiposDeMensaje)LogicaMensajes.Buscar(txtCodigo.Text.Trim());
            string asunto = txtAsunto.Text;
            string texto = txtTexto.Text;
            DateTime fecha = DateTime.Now;

            Mensaje mensaje = new Comunes(0, fecha, asunto, texto, nombre, dest, cod);//Probelma con el codigo
            
            LogicaMensajes.Agregar(mensaje);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Mensaje enviado";

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

}

