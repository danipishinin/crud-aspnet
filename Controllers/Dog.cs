using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//----------------------------
// BIBLIOTECAS ADICIONAIS
//----------------------------
using Npgsql;
using System.Data;

namespace Cadastro_Pets.Controllers
{
    public class Dog
    {
        //-----------------------------------------------
        //                  ATRIBUTOS
        //-----------------------------------------------
        private int idcachorro;
        private string nome;
        private int idade;
        private decimal peso;
        private string raca;
        private int cpfresponsavel;
        private string nomeresponsavel;

        public int Cpfresponsavel { get => cpfresponsavel; set => cpfresponsavel = value; }
        public string NomeResponsavel { get => nomeresponsavel; set => nomeresponsavel = value; }
        public int Idcachorro { get => idcachorro; set => idcachorro = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Idade { get => idade; set => idade = value; }
        public decimal Peso { get => peso; set => peso = value; }
        public string Raca { get => raca; set => raca = value; }

        //-----------------------------------------------
        //                MÉTODOS 
        //-----------------------------------------------

        public void inserir()
        {
            try
            {
                NpgsqlConnection conBanco; // criando o objeto
                String strConexao;

                //-----------------------------------------------
                //    Preparando conexão com o banco de dados
                //-----------------------------------------------

                strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                             "Password=momoi; Database=pets";

                conBanco = new NpgsqlConnection(strConexao);

                //-----------------------------------------------
                //    Preparando o comando SQL
                //-----------------------------------------------
                NpgsqlCommand cmdSQL; // objeto pra fazer o insert no banco
                String strComando;

                strComando = "INSERT INTO dog(nome, idade, peso, raca, nomeresponsavel, cpfresponsavel) " +
                             "VALUES(@nome, @idade, @peso, @raca, @nomeresponsavel, @cpfresponsavel)";

                cmdSQL = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter o_Parametro;

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@nome";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.nome;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@idade";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = this.idade;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@peso";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Numeric;
                o_Parametro.Value = this.peso;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@raca";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.raca;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@nomeresponsavel";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.nomeresponsavel;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@cpfresponsavel";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = this.cpfresponsavel;
                cmdSQL.Parameters.Add(o_Parametro);

                //-----------------------------------------------
                //    Executando as operações
                //-----------------------------------------------
                conBanco.Open(); // abrindo a conexão com o  banco

                // Prepare() é obrigatório ser chamada para configurar
                // internamente o comando SQL e os parametros informados.
                cmdSQL.Prepare();
                cmdSQL.ExecuteNonQuery();

                conBanco.Close(); // fechando a conexão com o banco
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "\nDog.inserir");
            }
        }

        public void atualizar()
        {
            try
            {
                NpgsqlConnection conBanco; // criando o objeto
                String strConexao;

                //-----------------------------------------------
                //    Preparando conexão com o banco de dados
                //-----------------------------------------------

                strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                             "Password=momoi; Database=pets";

                conBanco = new NpgsqlConnection(strConexao);

                //-----------------------------------------------
                //    Preparando o comando SQL
                //-----------------------------------------------
                NpgsqlCommand cmdSQL; // objeto pra fazer o insert no banco
                String strComando;

                strComando = "UPDATE dog SET nome = @nome, idade = @idade, peso = @peso, raca = @raca, " +
                                "nomeresponsavel = @nomeresponsavel, cpfresponsavel = @cpfresponsavel" +
                                " where idcachorro = @idcachorro";

                cmdSQL = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter o_Parametro;
                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@nome";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.nome;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@idade";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = this.idade;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@peso";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Numeric;
                o_Parametro.Value = this.peso;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@raca";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.raca;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@nomeresponsavel";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
                o_Parametro.Size = 100;
                o_Parametro.Value = this.nomeresponsavel;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@cpfresponsavel";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = this.cpfresponsavel;
                cmdSQL.Parameters.Add(o_Parametro);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@idcachorro";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = idcachorro;
                cmdSQL.Parameters.Add(o_Parametro);
                //-----------------------------------------------
                //    Executando as operações
                //-----------------------------------------------
                conBanco.Open(); // abrindo a conexão com o  banco

                // Prepare() é obrigatório ser chamada para configurar
                // internamente o comando SQL e os parametros informados.
                cmdSQL.Prepare();
                cmdSQL.ExecuteNonQuery();

                conBanco.Close(); // fechando a conexão com o banco

            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "\nDog.atualizar");
            }
        }
        public void excluir()
        {
            try
            {
                NpgsqlConnection conBanco; // criando o objeto
                String strConexao;

                //-----------------------------------------------
                //    Preparando conexão com o banco de dados
                //-----------------------------------------------

                strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                             "Password=momoi; Database=pets";

                conBanco = new NpgsqlConnection(strConexao);

                //-----------------------------------------------
                //    Preparando o comando SQL
                //-----------------------------------------------
                NpgsqlCommand cmdSQL; // objeto pra fazer o insert no banco
                String strComando;

                strComando = "Delete From dog where idcachorro = @idcachorro";

                cmdSQL = new NpgsqlCommand(strComando, conBanco);

                NpgsqlParameter o_Parametro;
                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@idcachorro";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = idcachorro;
                cmdSQL.Parameters.Add(o_Parametro);

                //-----------------------------------------------------------
                // Executando as operações
                //-----------------------------------------------------------
                conBanco.Open();

                // Prepare() é obrigatório ser chamada para configurar
                // internamente o comando SQL e os parametros informados.                
                //cmdSQL.Prepare();
                cmdSQL.ExecuteNonQuery();

                conBanco.Close();

            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "\nDog.excluir");
            }
        }

        public DataTable selecionar()
        {
            try
            {
                NpgsqlConnection conBanco;
                String strConexao;
                DataTable dtCachorro = new DataTable();

                //-----------------------------------------------
                //    Preparando conexão com o banco de dados
                //-----------------------------------------------

                strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                             "Password=momoi; Database=pets";

                conBanco = new NpgsqlConnection(strConexao);

                //-----------------------------------------------
                //    Preparando o comando SQL
                //-----------------------------------------------
                String strComando;
                strComando = "Select * from dog Order By idcachorro";

                NpgsqlDataAdapter daPesquisa;
                daPesquisa = new NpgsqlDataAdapter(strComando, conBanco);

                conBanco.Open();
                daPesquisa.Fill(dtCachorro);
                conBanco.Close();
                return dtCachorro;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "\nDog.selecionar");
            }
        }

        public DataTable obterPorIdCachorro()
        {
            try
            {
                NpgsqlConnection conBanco;
                NpgsqlDataAdapter daPesquisa;
                DataTable dtCachorro = new DataTable();
                NpgsqlParameter o_Parametro;

                String strConexao;
                String strComando;

                strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                             "Password=momoi; Database=pets";

                conBanco = new NpgsqlConnection(strConexao);

                strComando = "Select * From dog Where idcachorro = @idcachorro";

                daPesquisa = new NpgsqlDataAdapter(strComando, conBanco);

                o_Parametro = new NpgsqlParameter();
                o_Parametro.ParameterName = "@idcachorro";
                o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                o_Parametro.Value = idcachorro;
                daPesquisa.SelectCommand.Parameters.Add(o_Parametro);

                conBanco.Open();

                int nroLinhas;

                nroLinhas = daPesquisa.Fill(dtCachorro);

                conBanco.Close();

                return dtCachorro;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message + "\nDog.obterPorIdCachorro");
            }
        }
    }
}