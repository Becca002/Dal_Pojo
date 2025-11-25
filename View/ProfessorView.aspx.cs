using Bll;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class ProfessorView : System.Web.UI.Page
    {
        private ProfessorBll _professorBll;

        public ProfessorView()
        {
            _professorBll = new ProfessorBll();
        }

        private void ExibirMensagem(string mensagem)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + mensagem + "');";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        private void LimparCamposInsercao()
        {
            txtNovoNome.Text = string.Empty;
            txtNovoCpf.Text = string.Empty;
            txtNovoTitulacao.Text = string.Empty;
            txtNovoArea.Text = string.Empty;
            txtNovoSexo.Text = string.Empty;
        }

        private void Inserir()
        {
            Professor professor = new Professor();
            professor.Nome = txtNovoNome.Text;
            professor.Cpf = txtNovoCpf.Text;
            professor.Titulacao = txtNovoTitulacao.Text;
            professor.Area = txtNovoArea.Text;

            if (!string.IsNullOrEmpty(txtNovoSexo.Text))
            {
                professor.Sexo = txtNovoSexo.Text[0];
            }

            if (_professorBll.InserirProfessor(professor))
            {
                ExibirMensagem("Professor inserido com sucesso");
                LimparCamposInsercao();
                Lib.ExibirDadosProfessor(_professorBll, gvdProfessor);
            }
            else
            {
                ExibirMensagem("Erro ao inserir professor");
            }
        }

        private void Editar(int pIndice)
        {
            Professor professor = new Professor();
            Label lblCodProfessor = gvdProfessor.Rows[pIndice].FindControl("lblCodProfessor") as Label;
            if (lblCodProfessor != null)
            {
                professor.CodProfessor = Convert.ToInt32(lblCodProfessor.Text);
            }

            TextBox txtNome = gvdProfessor.Rows[pIndice].FindControl("txtNome") as TextBox;
            if (txtNome != null)
            {
                professor.Nome = txtNome.Text;
            }

            TextBox txtCpf = gvdProfessor.Rows[pIndice].FindControl("txtCpf") as TextBox;
            if (txtCpf != null)
            {
                professor.Cpf = txtCpf.Text;
            }

            TextBox txtSexo = gvdProfessor.Rows[pIndice].FindControl("txtSexo") as TextBox;
            if (txtSexo != null)
            {
                if (!string.IsNullOrEmpty(txtSexo.Text))
                {
                    professor.Sexo = txtSexo.Text[0];
                }
            }

            TextBox txtTitulacao = gvdProfessor.Rows[pIndice].FindControl("txtTitulacao") as TextBox;
            if (txtTitulacao != null)
            {
                professor.Titulacao = txtTitulacao.Text;
            }

            TextBox txtArea = gvdProfessor.Rows[pIndice].FindControl("txtArea") as TextBox;
            if (txtArea != null)
            {
                professor.Area = txtArea.Text;
            }

            if (_professorBll.EditarProfessor(professor))
            {
                ExibirMensagem("Professor editado com sucesso");
                PosicionarRegistroNoGrid(-1);
            }
            else
            {
                ExibirMensagem("Erro ao editar professor");
            }
        }

        private void Excluir(int pIndice)
        {
            Professor professor = new Professor();
            Label lblCodProfessor = gvdProfessor.Rows[pIndice].FindControl("lblCodProfessor") as Label;
            professor.CodProfessor = Convert.ToInt32(lblCodProfessor.Text);

            if (_professorBll.ExcluirProfessor(professor))
            {
                ExibirMensagem("Professor excluído com sucesso");
                PosicionarRegistroNoGrid(-1);
            }
            else
            {
                ExibirMensagem("Erro ao excluir professor");
            }
        }

        private void PosicionarRegistroNoGrid(int pIndice)
        {
            gvdProfessor.EditIndex = pIndice;
            Lib.ExibirDadosProfessor(_professorBll, gvdProfessor);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lib.ExibirDadosProfessor(_professorBll, gvdProfessor);
            }
        }

        protected void Insert(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void gvdProfessor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PosicionarRegistroNoGrid(e.NewEditIndex);
        }

        protected void gvdProfessor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PosicionarRegistroNoGrid(-1);
        }

        protected void gvdProfessor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Editar(e.RowIndex);
        }

        protected void gvdProfessor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Excluir(e.RowIndex);
        }
    }
}