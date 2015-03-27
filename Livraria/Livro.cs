using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Livro
    {
        #region Variaveis Privadas
        private int codLivro;
        private string titulo;
        private int numPaginas;
        private int ano;
        private string editora;
        private decimal preco;
        private Autor autor;
        #endregion

        #region Metodos Publicos
        public int CodLivro
        {
            get { return codLivro; }
            set { codLivro = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public int NumPaginas
        {
            get { return numPaginas; }
            set { numPaginas = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public string Editora
        {
            get { return editora; }
            set { editora = value; }
        }

        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public Autor Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        #endregion

        public Livro()
        {

        }
    }
}