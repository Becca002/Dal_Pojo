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
    public partial class AlunoView : System.Web.UI.Page
    {
        private AlunoBll _alunoBll;

        public AlunoView()
        {
            _alunoBll = new AlunoBll();
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
            txtNovoIdade.Text = string.Empty;
            txtNovoSexo.Text = string.Empty;
        }

        private void Inserir()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtNovoNome.Text;
            aluno.Cpf = txtNovoCpf.Text;
            aluno.Idade = Convert.ToInt32(txtNovoIdade.Text);
            aluno.Sexo = txtNovoSexo.Text;

            if (_alunoBll.InserirAluno(aluno))
            {
                ExibirMensagem("Aluno inserido com sucesso");
                LimparCamposInsercao();
                Lib.ExibirDadosAluno(_alunoBll, gvdAluno);
            }
            else
            {
                ExibirMensagem("Erro ao inserir aluno");
            }
        }

        private void Editar(int pIndice)
        {
            Aluno aluno = new Aluno();
            Label lblCodAluno = gvdAluno.Rows[pIndice].FindControl("lblCodAluno") as Label;
            if (lblCodAluno != null)
            {
                aluno.CodAluno = Convert.ToInt32(lblCodAluno.Text);
            }
            TextBox txtNome = gvdAluno.Rows[pIndice].FindControl("txtNome") as TextBox;
            if (txtNome != null)
            {
                aluno.Nome = txtNome.Text;
            }
            TextBox txtCpf = gvdAluno.Rows[pIndice].FindControl("txtCpf") as TextBox;
            if (txtCpf != null)
            {
                aluno.Cpf = txtCpf.Text;
            }
            TextBox txtSexo = gvdAluno.Rows[pIndice].FindControl("txtSexo") as TextBox;
            if (txtSexo != null)
            {
                aluno.Sexo = txtSexo.Text;
            }
            TextBox txtIdade = gvdAluno.Rows[pIndice].FindControl("txtIdade") as TextBox;
            if (txtIdade != null)
            {
                aluno.Idade = Convert.ToInt32(txtIdade.Text);
            }

            if (_alunoBll.EditarAluno(aluno))
            {
                ExibirMensagem("Aluno editado com sucesso");
                PosicionarRegistroNoGrid(-1);
            }
            else
            {
                ExibirMensagem("Erro ao editar aluno");
            }
        }

        private void Excluir(int pIndice)
        {
            Aluno aluno = new Aluno();
            Label lblCodAluno = gvdAluno.Rows[pIndice].FindControl("lblCodAluno") as Label;
            aluno.CodAluno = Convert.ToInt32(lblCodAluno.Text);

            if (_alunoBll.ExcluirAluno(aluno))
            {
                ExibirMensagem("Aluno excluído com sucesso");
                PosicionarRegistroNoGrid(-1);
            }
            else
            {
                ExibirMensagem("Erro ao excluir aluno");
            }
        }

        private void PosicionarRegistroNoGrid(int pIndice)
        {
            gvdAluno.EditIndex = pIndice;
            Lib.ExibirDadosAluno(_alunoBll, gvdAluno);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Lib.ExibirDadosAluno(_alunoBll, gvdAluno);
            }
        }

        protected void Insert(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void gvdAluno_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PosicionarRegistroNoGrid(e.NewEditIndex);
        }

        protected void gvdAluno_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PosicionarRegistroNoGrid(-1);
        }

        protected void gvdAluno_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Editar(e.RowIndex);
        }

        protected void gvdAluno_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Excluir(e.RowIndex);
        }
    }
}