using Dal;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class ProfessorBll
    {
        private ProfessorDal _professorDal;
        public ProfessorBll()
        {
            _professorDal = new ProfessorDal();
        }
        public bool InserirProfessor(Professor professor)
        {
            return _professorDal.InserirProfessor(professor);
        }
        public bool EditarProfessor(Professor professor)
        {
            return _professorDal.EditarProfessor(professor);
        }
        public bool ExcluirProfessor(Professor professor)
        {
            return _professorDal.ExcluirProfessor(professor);
        }
        public List<Professor> ListarProfessores()
        {
            return _professorDal.ListarProfessores();
        }
    }
}
