using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;

public partial class ListadoMensajesPrivadosDeUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                List<Usuario> colUsuarios = LogicaUsuarios.ListarUsuarios();
                Session["Usuario"] = colUsuarios;

                if (colUsuarios.Count > 0)
                {
                    DdlUsuarios.DataSource = colUsuarios;
                    DdlUsuarios.DataTextField = "User";
                    DdlUsuarios.DataBind();
                    DdlUsuarios.Items.Insert(0, "--------");
                }
                else
                {
                    DdlUsuarios.DataSource = null;
                    DdlUsuarios.DataBind();

                    throw new Exception("No hay usuarios que mostrar");
                }

                List<Mensaje> colMensajes = LogicaMensajes.ListarMensajes();
                Session["TodoslosMensajes"] = colMensajes;

                if (colMensajes.Count == 0)
                {
                    DdlEnviaORecibe.Enabled = false;
                    throw new Exception("No hay mensajes disponibles");
                }

            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void DdlEnviaORecibe_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Usuario user = LogicaUsuarios.Buscar(DdlUsuarios.Text);
            int ddl = DdlEnviaORecibe.SelectedIndex;

            List<Mensaje> colMensajes = (List<Mensaje>)Session["TodoslosMensajes"];
            Mensaje oPrivados = null;

            if (DdlEnviaORecibe.SelectedIndex == 0)
                throw new Exception("Seleccione una opcion");
            else if (DdlEnviaORecibe.SelectedIndex == 1)
            {
                foreach (Mensaje p in colMensajes)
                {
                    if (p is Privados)
                    {
                        if (p.CargoUsuario == user)
                        {
                            oPrivados = p;
                            break;
                        }
                    }
                    GvPrivados.DataSource = LogicaMensajes.ListarPorUsuarioPrivado(user, DdlEnviaORecibe.SelectedIndex);
                    GvPrivados.DataBind();
                }
            }
            else if (DdlEnviaORecibe.SelectedIndex == 2)
            {
                foreach (Mensaje p in colMensajes)
                {
                    if (p is Privados)
                    {
                        if (p.CargoUsuario == user)
                        {
                            oPrivados = p;
                            break;
                        }

                        GvPrivados.DataSource = LogicaMensajes.ListarPorUsuarioPrivado(user, DdlEnviaORecibe.SelectedIndex);
                        GvPrivados.DataBind();
                    }
                }
            }

            DdlUsuarios.SelectedIndex = 0;
            DdlEnviaORecibe.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Blue;
            lblError.Text = ex.Message;
        }
    }

}