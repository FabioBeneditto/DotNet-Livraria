using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Autor aut = new Autor();

            Console.WriteLine("Consultando um Autor");
            Console.WriteLine("--------------------");

            Console.WriteLine("Digite o código do autor para pesquisar: ");
            aut.CodAutor = int.Parse(Console.ReadLine());

            aut.Consulta();

            Console.WriteLine("O nome do autor pesquisado é " + aut.Nome + " e nasceu no dia " + aut.DtNascimento.ToString("dd/MM/yyyy"));

            Console.WriteLine("Pressione Enter para continuar");
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Inserindo um novo Autor");
            Console.WriteLine("-----------------------");

            aut = new Autor();

            Console.WriteLine("Digite o nome do autor: ");
            aut.Nome = Console.ReadLine();

            Console.WriteLine("Digite o cpf do autor: ");
            aut.Cpf = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do autor: ");
            aut.DtNascimento = Convert.ToDateTime(Console.ReadLine());

            aut.Insere();

            Console.Read();
        }
    }
}
