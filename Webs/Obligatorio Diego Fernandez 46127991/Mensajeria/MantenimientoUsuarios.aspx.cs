using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;

public partial class MantenimientoUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
            LimpioFormulario();
    }

    private void LimpioFormulario()
    {

        BtnBuscar.Enabled = true;
        BtnAgregar.Enabled = false;
        BtnModificar.Enabled = false;
        BtnEliminar.Enabled = false;

        txtUsuario.Text = "";
        txtUsuario.Enabled = true;
        txtNombre.Text = "";
        txtNombre.Enabled = false;
        txtCedula.Text = "";
        txtCedula.Enabled = false;
    }

    private void ActivoBotones(bool esAlta = true)
    {
        BtnModificar.Enabled = !esAlta;
        BtnEliminar.Enabled = !esAlta;
        BtnAgregar.Enabled = esAlta;
        BtnBuscar.Enabled = false;

        txtUsuario.Enabled = false;
        txtNombre.Enabled = true;
        txtCedula.Enabled = true;
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string usuario = "";

            usuario = txtUsuario.Text;

            Usuario user = LogicaUsuarios.Buscar(usuario);

            if (usuario.Trim() == "")
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "El nombre está vacío. Ingrese otro nombre de usuario.";
            }

            else if (user is Usuario)
            {

                txtNombre.Text = user.Nombre;
                txtCedula.Text = ((Usuario)user).Cedula.ToString();

                ActivoBotones(false);

                Session["UserUsuario"] = user;

            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay usuarios registradas con ese nombre de usuario";

                Session["UserUsuario"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string username = txtUsuario.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            int cedula = Convert.ToInt32(txtCedula.Text);

            Usuario user = new Usuario(username, nombre, cedula);

            LogicaUsuarios.Agregar(user);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta con exito";

            LimpioFormulario();

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario user = (Usuario)Session["UserUsuario"];

            user.Nombre = txtNombre.Text.Trim();
            user.Cedula = Convert.ToInt32(txtCedula.Text.Trim());

            LogicaUsuarios.Modificar(user);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificacion exitosa";

            LimpioFormulario();

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }

    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario user = (Usuario)Session["UserUsuario"];

            LogicaUsuarios.Eliminar(user);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Se elimino correctamente";

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}