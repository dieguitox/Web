using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;


public partial class MantenimientoTiposMensjaes : System.Web.UI.Page
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

        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtNombreCodigo.Text = "";
        txtNombreCodigo.Enabled = false;
    }

    private void ActivoBotones(bool esAlta = true)
    {
        BtnModificar.Enabled = !esAlta;
        BtnEliminar.Enabled = !esAlta;
        BtnAgregar.Enabled = esAlta;
        BtnBuscar.Enabled = false;

        txtCodigo.Enabled = false;
        txtNombreCodigo.Enabled = true;
    }

    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = "";

            codigo = txtCodigo.Text.Trim();

            TiposDeMensaje Cod = LogicaMensajes.Buscar(codigo);

            if (codigo == "")
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Debe ingresar un código";
            }
            else if (Cod is TiposDeMensaje)
            {
                txtNombreCodigo.Text = Cod.Nombre;

                ActivoBotones(false);

                Session["TipoCodigo"] = Cod;
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay codigos registrados";

                Session["TipoCodigo"] = null;
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
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombreCodigo.Text.Trim();

            TiposDeMensaje cod = new TiposDeMensaje(codigo, nombre);

            LogicaMensajes.Agregar(cod);

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
            TiposDeMensaje cod = (TiposDeMensaje)Session["TipoCodigo"];

            cod.Nombre = txtNombreCodigo.Text.Trim();

            LogicaMensajes.Modificar(cod);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificacion con exito";

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
            TiposDeMensaje cod = (TiposDeMensaje)Session["TipoCodigo"];

            LogicaMensajes.Eliminar(cod);

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