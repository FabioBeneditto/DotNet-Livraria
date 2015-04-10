using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrariaWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                mensagem.InnerHtml = "Olá do C# if do IsPostBack";
            }
            else
            {
                mensagem.InnerHtml = "Olá do C# else do IsPostBack";
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            mensagem.InnerHtml = "Olá " + txtNome.Text + "! Vamos para o Evento!";
        }
    }
}