using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private Autor autorlivro;

        string servidor = "FABIO-MOBILE\\SQLEXPRESS";
        string banco    = "Livraria";
        string usuario  = "sa";
        string senha    = "1234";
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

        public Autor Autorlivro
        {
            get { return autorlivro; }
            set { autorlivro = value; }
        }
        #endregion

        public Livro()
        {

        }

        public Livro(int parCodigo)
        {
            this.CodLivro = parCodigo;
            this.Consulta();
        }

        public void Consulta()
        {
            // Cria instancia da classe SqlConnection
            SqlConnection cnn = new SqlConnection();

            // Estabelece a string de conexão com o banco de dados
            // Consultar http://www.connectionstrings.com para obter mais tipos de string de conexão
            cnn.ConnectionString = "Data Source=" + servidor + ";" +
                "Initial Catalog=" + banco + ";" +
                "User ID=" + usuario + ";" +
                "Password=" + senha + ";" +
                "Current Language=us_english;Connection Timeout=10";
            try
            {
                //abre conexão
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Livro WHERE CodLivro = @Codigo");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Codigo", this.CodLivro);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dtLivro = new DataTable();
                ad.Fill(dtLivro);

                if (dtLivro.Rows.Count > 0)
                {
                    this.Titulo = dtLivro.Rows[0]["Titulo"].ToString();
                    this.NumPaginas = Convert.ToInt32(dtLivro.Rows[0]["NumPaginas"]);
                    this.Ano = Convert.ToInt32(dtLivro.Rows[0]["Ano"]);
                    this.Editora = dtLivro.Rows[0]["Editora"].ToString();
                    this.Preco = Convert.ToDecimal(dtLivro.Rows[0]["Preco"]);
                    //this.Autorlivro.CodAutor = Convert.ToInt32(dtLivro.Rows[0]["CodAutor"]);
                    this.Autorlivro = new Autor(Convert.ToInt32(dtLivro.Rows[0]["CodAutor"]));
                }
                else
                {
                    throw new Exception("Código informado é inválido!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        public int Insere()
        {
            int NumInseridos = 0;

            SqlConnection cnn = new SqlConnection();
            // Consultar http://www.connectionstrings.com para obter mais tipos de string de conexão
            cnn.ConnectionString = "Data Source=" + servidor + ";" +
                "Initial Catalog=" + banco + ";" +
                "User ID=" + usuario + ";" +
                "Password=" + senha + ";" +
                "Current Language=us_english;Connection Timeout=10";

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Livro(Titulo,NumPaginas,Ano,Editora,Preco,CodAutor) VALUES (@Titulo, @NumPaginas, @Ano, @Editora,@Preco,@CodAutor)");
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@Titulo", this.Titulo);
                cmd.Parameters.AddWithValue("@NumPaginas", this.NumPaginas);
                cmd.Parameters.AddWithValue("@Ano", this.Ano);
                cmd.Parameters.AddWithValue("@Editora", this.Editora);
                cmd.Parameters.AddWithValue("@Preco", this.Preco);
                cmd.Parameters.AddWithValue("@CodAutor", this.Autorlivro);

                NumInseridos = cmd.ExecuteNonQuery();
                return NumInseridos;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return NumInseridos;
        }
    }
    }
}