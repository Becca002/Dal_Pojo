using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Conexao
    {
        private static string stringConexao = "server=127.0.0.1;user=root;password=root;database=dataschool";

        public static MySqlConnection ConectarBD()
        {
            MySqlConnection conexao = new MySqlConnection(stringConexao);
            conexao.Open();
            return conexao;
        }       
    }
}
