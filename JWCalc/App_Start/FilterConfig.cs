using System.Web;
using System.Web.Mvc;

namespace JWCalc
{
    /// <summary>
    /// Classe que armazena mensagens de erro da aplicação
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
