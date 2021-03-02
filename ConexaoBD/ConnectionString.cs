using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Negocios.ConexaoBD
{
    /// <summary>
    /// Classe base para a String de Conexão
    /// </summary>
    [Serializable()]
    public class ConnectionString
    {
        #region Campos

        internal int TimeOut = 0;
        internal string NomeBancoDeDados;

        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="pTimeOut">TimeOut da Conexao</param>
        public ConnectionString(string pNomeDataBase, int pTimeOut = 30)
        {
            this.NomeBancoDeDados = pNomeDataBase;
            this.TimeOut = pTimeOut;
        }

        /// <summary>
        /// Retorna a String de Conexão em texto dependendo do Tipo solicitado (Conexão ADO tradicional ou Conexão Entity Framework)
        /// </summary>
        /// <typeparam name="T">Tipo ConnectionStringModelo ou ConnectionString_EntityFramework</typeparam>
        /// <returns>String de conexão em texto</returns>
        public string RetornaStringConexao()
        {
            ConnectionStringModelo jsonString;
            string ProviderConnectionString = string.Empty,
                   stringDeConexao = string.Empty;

            //Carregando arquivo JSON com os dados da conexão
            using (StreamReader file = File.OpenText(ConfigurationManager.ConnectionStrings["ADO"].ConnectionString))
            {
                jsonString = Newtonsoft.Json.JsonConvert.DeserializeObject<ConnectionStringModelo>(file.ReadToEnd());
                file.Close();
            }

            //Captura os campos e monta a cadeia de conexão
            List<string> camposStringConexao = new List<string>();
            PropertyInfo[] propriedades = jsonString.GetType().GetProperties();

            foreach (PropertyInfo item in propriedades.Where(x => x != null))
            {

                switch (item.Name)
                {
                    //Setando valor do TimeOut
                    case "ConnectTimeout":
                        item.SetValue(jsonString, TimeOut);
                        break;
                    case "Database":
                        if (!string.IsNullOrWhiteSpace(NomeBancoDeDados))
                            item.SetValue(jsonString, NomeBancoDeDados);
                        break;
                    default:
                        break;
                }

                string chaveAtual = $"{item.GetCustomAttribute<DisplayAttribute>().Name} = {item.GetValue(jsonString)}";

                if (!camposStringConexao.Contains(chaveAtual))
                    camposStringConexao.Add(chaveAtual);
            }

            stringDeConexao = string.Join(";", camposStringConexao);

            return stringDeConexao;
        }
    }

    /// <summary>
    /// Classe modelo específica das conexões ADO
    /// </summary>
    [Serializable()]
    internal class ConnectionStringModelo
    {
        #region Propriedades
        [Display(Name = "Connect Timeout")]
        public int ConnectTimeout { get; set; }

        [Display(Name = "Integrated Security")]
        public bool IntegratedSecurity { get; set; }

        [Display(Name = "Encrypt")]
        public bool Encrypt { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Server")]
        public string Server { get; set; }

        [Display(Name = "Database")]
        public string Database { get; set; }

        [Display(Name = "TrustServerCertificate")]
        public bool TrustServerCertificate { get; set; }

        [Display(Name = "ApplicationIntent")]
        public string ApplicationIntent { get; set; }

        [Display(Name = "MultiSubnetFailover")]
        public bool MultiSubnetFailover { get; set; }
        #endregion
    }
}
