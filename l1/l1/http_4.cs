using System;
using System.Web;

namespace l1
{
    public class http_4 : IHttpHandler
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
            context.Response.AddHeader("Content-Type", "text/html");

            if (context.Request.HttpMethod == "POST")
            {
                    var x = int.Parse(context.Request.Form["x"]);
                    var y = int.Parse(context.Request.Form["y"]);
                    var sum = x + y;
                    context.Response.Write(sum);
            }
            else
            {
                context.Response.StatusCode = 405;
                context.Response.AddHeader("Content-Type", "text/html");
                context.Response.Write("<h2>Only POST method allowed.</h2>");
            }
        }

        #endregion
    }
}
