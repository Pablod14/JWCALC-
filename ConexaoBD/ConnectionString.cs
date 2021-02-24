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
    public class BaseConnectionString
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
        #endregion

        #region Campos

        internal int TimeOut = 0;
        private readonly List<string> CamposFixosEntytiFramework = new List<string> { "Metadata", "Provider" }; 

        #endregion

        #region Constantes

        private const string C_TIPOCONEXAOENTYTI = "EntityFramework";
        private const string C_TIPOCONEXAOADO = "ADO";

        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="pTimeOut">TimeOut da Conexao</param>
        public BaseConnectionString(int pTimeOut = 30)
        {
            this.TimeOut = pTimeOut;
        }

        /// <summary>
        /// Retorna a String de Conexão em texto dependendo do Tipo solicitado (Conexão ADO tradicional ou Conexão Entity Framework)
        /// </summary>
        /// <typeparam name="T">Tipo ConnectionString_ADO ou ConnectionString_EntityFramework</typeparam>
        /// <returns>String de conexão em texto</returns>
        public string RetornaStringConexao<T>()
        {
            T jsonString;
            string tipoConexao = string.Empty, 
                                 ProviderConnectionString = string.Empty, 
                                 stringDeConexao = string.Empty ;

            //Definindo o tipo de conexão
            if (typeof(T).Equals(typeof(ConnectionString_ADO)))
                tipoConexao = C_TIPOCONEXAOADO;
            else if (typeof(T).Equals(typeof(ConnectionString_EntityFramework)))
                tipoConexao = C_TIPOCONEXAOENTYTI;

            //Carregando arquivo JSON com os dados da conexão
            using (StreamReader file = File.OpenText(ConfigurationManager.ConnectionStrings[tipoConexao].ConnectionString))
            {
                jsonString = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(file.ReadToEnd());
                file.Close();
            }

            //Captura os campos e monta a cadeia de conexão
            List<string> camposStringConexao = new List<string>();
            PropertyInfo[] propriedades = jsonString.GetType().GetProperties();

            foreach (PropertyInfo item in propriedades.Where(x => x != null))
            {
                //Setando valor do TimeOut
                if (item.Name == "ConnectTimeout")
                    item.SetValue(jsonString, TimeOut);

                if (tipoConexao == C_TIPOCONEXAOENTYTI && !CamposFixosEntytiFramework.Any(x => x == item.Name))
                    ProviderConnectionString += $"{item.GetCustomAttribute<DisplayAttribute>().Name} = {item.GetValue(jsonString)};";
                else
                {
                    string chaveAtual = $"{item.GetCustomAttribute<DisplayAttribute>().Name} = {item.GetValue(jsonString)}";

                    if (!camposStringConexao.Contains(chaveAtual))
                        camposStringConexao.Add(chaveAtual);
                }
            }

            if (tipoConexao == C_TIPOCONEXAOENTYTI)
                stringDeConexao = $"{string.Join(";", camposStringConexao)};Provider Connection String = '{ProviderConnectionString}'";
            else
                stringDeConexao = string.Join(";", camposStringConexao);

            return stringDeConexao;
        }
    }

    /// <summary>
    /// Classe modelo específica das conexões ADO
    /// </summary>
    [Serializable()]
    public class ConnectionString_ADO : BaseConnectionString
    {
        #region Atributos 
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

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="pTimeout">TimeOut da Conexao</param>
        public ConnectionString_ADO(int pTimeout = 30)
        {
            base.TimeOut = pTimeout;
        }
    }

    /// <summary>
    /// Classe modelo específica das conexões Entity Framework
    /// </summary>
    [Serializable()]
    public class ConnectionString_EntityFramework : BaseConnectionString
    {
        #region Propriedades
        [Display(Name = "Data Source")]
        public string Datasource { get; set; }

        [Display(Name = "Initial Catalog")]
        public string InitialCatalog { get; set; }

        [Display(Name = "Metadata")]
        public string Metadata { get; set; }

        [Display(Name = "Provider")]
        public string Provider { get; set; }

        [Display(Name = "MultipleActiveResultSets")]
        public bool MultipleActiveResultSets { get; set; }

        [Display(Name = "App")]
        public string App { get; set; } 
        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="pTimeout">TimeOut da Conexao</param>
        public ConnectionString_EntityFramework(int pTimeout = 30)
        {
            base.TimeOut = pTimeout;
        }
    }
}
