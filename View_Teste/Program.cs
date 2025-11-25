using Bll;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_Teste
{
    public class Program
    {
        static void Main(string[] args)
        {
            //01 - montando o objeto Aluno
            Aluno al1 = new Aluno();
            al1.Nome = "João Silva";
            al1.Cpf = "123.456.789-00";
            al1.Sexo = "M";
            al1.Idade = 20;

            Aluno al2 = new Aluno();
            al2.Nome = "Gabriel";
            al2.Cpf = "987.456.789-00";
            al2.Sexo = "M";
            al2.Idade = 40;

            Aluno al3 = new Aluno();
            al3.Nome = "Fernanda teste";
            al3.Cpf = "128.560.789-77";
            al3.Sexo = "F";
            al3.Idade = 35;

            //02 - utilizando a camada BLL para inserir o aluno
            AlunoBll alunobll = new AlunoBll();

            var listaAlunos = alunobll.ListarAlunos();
            foreach (var aluno in listaAlunos)
            {
                alunobll.ExcluirAluno(aluno);
            }

            if (!alunobll.InserirAluno(al1) || !alunobll.InserirAluno(al2)){
                Console.WriteLine("Erro ao inserir alunos iniciais.");
                Console.ReadKey();
            }

            if (alunobll.InserirAluno(al3))
            {
                Console.WriteLine("Aluno inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao inserir aluno.");
            }

            //03 - alterando o nome do aluno e atualizando no banco
            al1.Nome = "ALUNO ALTERADO";
            if (alunobll.EditarAluno(al3))
            {
                Console.WriteLine("Aluno alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao alterar aluno.");
            }

            //04 - listando os alunos cadastrados no banco
            var alunos = alunobll.ListarAlunos();
            Console.WriteLine("Lista de Alunos:");
            listaAlunos.ForEach(a =>
            {
                Console.WriteLine($"Código: {a.CodAluno}, Nome: {a.Nome}, CPF: {a.Cpf}, Sexo: {a.Sexo}, Idade: {a.Idade}");
            });

            //05 - excluindo o aluno do banco
            if (alunobll.ExcluirAluno(al3))
            {
                Console.WriteLine("Aluno excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao excluir aluno.");
            }

            Console.ReadKey();
        }
    }
}
