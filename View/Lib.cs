using Bll;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace View
{
    public class Lib
    {
        public static void ExibirDadosAluno(AlunoBll aluno, GridView pGrid)
        {
            pGrid.DataSource = aluno.ListarAlunos();
            pGrid.DataBind();
        }

        public static void ExibirDadosProfessor(ProfessorBll professor, GridView pGrid)
        {
            pGrid.DataSource = professor.ListarProfessores();
            pGrid.DataBind();
        }
    }
}