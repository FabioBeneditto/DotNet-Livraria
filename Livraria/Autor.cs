using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    public class Autor
    {

        #region Variaveis Privadas
        private int codAutor;
        private string nome;
        private string cpf;
        private DateTime dtNascimento;

        string servidor = "FABIO-MOBILE\\SQLEXPRESS";
        string banco = "Livraria";
        string usuario = "sa";
        string senha = "1234";
        #endregion

        #region Propriedades Publicas

        public int CodAutor
        {
            get { return codAutor; }
            set { codAutor = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public DateTime DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }

        #endregion

        /// <summary>
        /// Cria um objeto da classe Autor
        /// </summary>
        public Autor()
        {

        }

        /// <summary>
        /// Cria objeto da classe Autor e carrega suas propriedades
        /// </summary>
        /// <param name="parCodigo">Código do autor que será carregado</param>
        public Autor(int parCodigo)
        {
            this.CodAutor = parCodigo;
            this.Consulta();
        }

        /// <summary>
        /// Consulta as informações de um autor
        /// </summary>
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM Autor WHERE CodAutor = @Codigo");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Codigo", this.CodAutor);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dtAutor = new DataTable();
                ad.Fill(dtAutor);

                if (dtAutor.Rows.Count > 0)
                {
                    this.Cpf = dtAutor.Rows[0]["CPF"].ToString();
                    this.DtNascimento = Convert.ToDateTime(dtAutor.Rows[0]["DtNascimento"]);
                    this.Nome = dtAutor.Rows[0]["Nome"].ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Autor(Nome,CPF,DtNascimento) VALUES (@Nome, @CPF, @DtNasccimento)");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", this.Nome);
                cmd.Parameters.AddWithValue("@CPF", this.Cpf);
                cmd.Parameters.AddWithValue("@DtNascimento", this.DtNascimento);

                NumInseridos = cmd.ExecuteNonQuery();
                return NumInseridos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return NumInseridos;
        }

        public List<Autor> ListaAutores()
        {
            List<Autor> lstAutores = new List<Autor>;

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

                SqlCommand cmd = new SqlCommand("SELECT CodAutor, CPF, DtNascimento, Nome FROM Autor");
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader drAutor = cmd.ExecuteReader();

                if(drAutor.HasRows)
                {
                    while(drAutor.Read())
                    {
                        Autor au = new Autor
                        {
                            CodAutor = Convert.ToInt32(drAutor["CodAutor"]),
                            Nome = drAutor["Nome"].ToString(),
                            Cpf = drAutor["CPF"].ToString(),
                            DtNascimento = Convert.ToDateTime(drAutor["DtNascimento"])
                        };
                        lstAutores.Add(au);
                    }
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

            return lstAutores;
        }
    }
}
