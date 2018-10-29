using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace UsandoDapper
{
    class Program
    {
        static string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        static void Main(string[] args)
        {
            //Exemplo1();
            Exemplo2();

            Console.ReadKey();
        }

        private static void Exemplo1()
        {
            var conexaoBD = new SqlConnection(strConexao);
            conexaoBD.Open();

            var resultado = conexaoBD.Query("Select * from Contatos order by Nome");

            Console.WriteLine("{0} - {1} - {2}", "Código", "Nome", "Endereço");

            foreach (var contato in resultado)
            {
                Console.WriteLine("{0} - {1} - {2}", contato.Id, contato.Nome, contato.Logradouro);
            }

            conexaoBD.Close();            
        }

        private static void Exemplo2()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                IEnumerable contatos = conexaoBD.Query<Contato>("Select * from Contatos Order By Nome");                

                Console.WriteLine("{0} - {1} - {2}", "Código", "Nome", "Endereço");

                foreach (Contato contato in contatos)
                {
                    Console.WriteLine("{0} - {1} - {2}", contato.Id, contato.Nome, contato.Logradouro);
                }
            }
        }

        private static void Exemplo3()
        {
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                IEnumerable contatos = conexaoBD.Query<Contato>
                (
                    "Select * from Contatos Where Bairro Like @Bairro", new { Bairro ="%Santa Terezinha%"}
                );

                Console.WriteLine();
            }
        }
    }
}
