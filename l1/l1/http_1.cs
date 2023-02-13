using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace l1
{
    public class http_1 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var aaa = context.Request.Params.Get("ParmA");
            var bbb = context.Request.Params.Get("ParmB");
            var XYZ = context.Request.FilePath.Split('.').LastOrDefault();
            var method = context.Request.HttpMethod;
            var responseTxt = String.Empty;
            switch (method.ToUpper())
            {
                case "GET":
                    responseTxt = $"GET - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
                case "POST":
                    responseTxt = $"POST - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
                case "PUT":
                    responseTxt = $"PUT - Http - {XYZ}:ParmA = {aaa}, ParmB = {bbb}";
                    break;
            }
            context.Response.Write(responseTxt);
        }
        //http://localhost:49743/1.SED?ParmA=aa&ParmB=bbb
        #endregion
    }
}
