using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pojo;

namespace Dal
{
    public class ProfessorDal
    {
        public bool InserirProfessor(Professor professor)
        {
            professor.CodProfessor = Persistencia.RetornarProximoId("professor", "codprofessor");
            return ((Persistencia.ExecutarSQL(
                "Insert Into professor(codprofessor, nome, cpf, sexo, titulacao, area) " +
                "Values(@codprofessor, @nome, @cpf, @sexo, @titulacao, @area)", professor)).RecordsAffected > 0);
        }

        public bool EditarProfessor(Professor professor)
        {
            return ((Persistencia.ExecutarSQL(
                "Update Professor Set nome=@nome, cpf=@cpf, sexo=@sexo," +
                "titulacao=@titulacao, area=@area Where CodProfessor=@codprofessor", professor)).RecordsAffected > 0);
        }

        public bool ExcluirProfessor(Professor professor)
        {
            return ((Persistencia.ExecutarSQL(
                "Delete From Professor Where CodProfessor=@codprofessor", professor)).RecordsAffected > 0);
        }

        public List<Professor> ListarProfessores()
        {
            using (var dr = Persistencia.ExecutarSQL("Select codprofessor, nome, cpf, sexo, titulacao, area From professor",
                null))
            {
                List<Professor> professores = new List<Professor>();
                while (dr.Read())
                {
                    Professor p = new Professor();
                    p.CodProfessor = Convert.ToInt32(dr["codprofessor"]);
                    p.Nome = dr["nome"].ToString();
                    p.Cpf = dr["cpf"].ToString();
                    p.Sexo = Convert.ToChar(dr["sexo"]);
                    p.Titulacao = dr["titulacao"].ToString();
                    p.Area = dr["area"].ToString();
                    professores.Add(p);
                }
                return professores;
            }
        }
    }
}
