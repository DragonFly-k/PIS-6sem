using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs("post", "get")]
        public string C01()
        {
            string result = $"{$"--Method: {Request.HttpMethod}\n"}\n" +
                $"{$"--Uri: {Request.Url.AbsoluteUri}\n"}\n" +
                $"{$"--Headers: {Request.Headers}\n"}\n" +
                $"{$"--QueryString: {Request.QueryString}\n"}\n";

            if (Request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    result += $"Body: {reader.ReadToEnd()}\n";
                }
            }

            return result;
        }

        [AcceptVerbs("post", "get")]
        public string C02()
        {
            string body;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = $"{reader.ReadToEnd()}\n";
            }

            return $"--Status: {Response.StatusCode} {Response.StatusDescription}\n" +
                $"--Headers: {Response.Headers}\n" +
                $"Body: {body}";
        }
    }
}