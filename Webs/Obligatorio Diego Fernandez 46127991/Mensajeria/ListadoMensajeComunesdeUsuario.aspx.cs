using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;


public partial class ListadoMensajeComunesdeUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                List<Usuario> colUsuarios = LogicaUsuarios.ListarUsuarios();
                Session["TodoslosUsuarios"] = colUsuarios;

                List<TiposDeMensaje> colTipos = LogicaMensajes.ListarTipos();
                Session["TodosLosTipos"] = colTipos;

                if (colUsuarios.Count > 0 && colTipos.Count > 0)
                {
                    DdlUsuarios.DataSource = colUsuarios;
                    DdlUsuarios.DataTextField = "User";
                    DdlUsuarios.DataBind();
                    DdlUsuarios.Items.Insert(0, "--------");

                    DdlTipodeMensaje.DataSource = colTipos;
                    DdlTipodeMensaje.DataTextField = "Codigo";
                    DdlTipodeMensaje.DataBind();
                    DdlTipodeMensaje.Items.Insert(0, "--------");
                }
                else
                {
                    DdlUsuarios.DataSource = null;
                    DdlUsuarios.DataBind();
                    DdlTipodeMensaje.DataSource = null;
                    DdlTipodeMensaje.DataBind();

                    throw new Exception("No hay usuarios que mostrar ni codigo que mostrar");
                }



                List<Mensaje> colMensaje = LogicaMensajes.ListarMensajes();
                Session["TodoslosMensajes"] = colMensaje;

                if (colMensaje.Count == 0)
                {
                    DdlUsuarios.Enabled = false;
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
            TiposDeMensaje cod = LogicaMensajes.Buscar(DdlTipodeMensaje.Text);

            List<Mensaje> colMensajes = (List<Mensaje>)Session["TodoslosMensajes"];
            Mensaje oComunes = null;


            if (DdlEnviaORecibe.SelectedIndex == 0)
                throw new Exception("Selecciones una Opcion");

            else if (DdlEnviaORecibe.SelectedIndex == 1)
            {
                foreach (Mensaje c in colMensajes)
                {
                    if (c is Comunes)
                    {
                        if (c.CargoUsuario == user && c.Tipo == cod)
                        {
                            oComunes = c;
                            break;

                        }

                        GvComunes.DataSource = LogicaMensajes.ListarPorUsuario(user, cod, DdlEnviaORecibe.SelectedIndex);
                        GvComunes.DataBind();
                    }
                }
            }
            else if (DdlEnviaORecibe.SelectedIndex == 2)
            {
                foreach (Mensaje c in colMensajes)
                {
                    if (c is Comunes)
                    {
                        if (c.CargoDest == user && c.Tipo == cod)
                        {
                            oComunes = c;
                            break;
                        }

                        GvComunes.DataSource = LogicaMensajes.ListarPorUsuario(user, cod, DdlEnviaORecibe.SelectedIndex);
                        GvComunes.DataBind();
                    }
                }
            }

            DdlUsuarios.SelectedIndex = 0;
            DdlTipodeMensaje.SelectedIndex = 0;
            DdlEnviaORecibe.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }

    }

}