using System;
using System.Web;

namespace l1
{
    public class http_6 : IHttpHandler
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
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            var x = context.Request.Params.Get("x");
            var y = context.Request.Params.Get("y");
            var method = context.Request.HttpMethod;
            switch (method.ToUpper())
            {
                case "GET":
                    context.Response.WriteFile("D:\\универ\\ПИС\\лаба\\l1\\l1\\static\\Http6.html");
                    break;
                case "POST":
                    context.Response.Write(int.Parse(x) + " * " + int.Parse(y) + " = " + (int.Parse(x) * int.Parse(y)));
                    break;
            }
        }

        #endregion
    }
}
