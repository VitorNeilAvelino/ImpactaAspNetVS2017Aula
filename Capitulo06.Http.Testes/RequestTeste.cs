using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo06.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void GetRequestTeste()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com");
            request.Method = "GET";

            //request.UserAgent = "Visual Studio";
            //request.Date = DateTime.Now;

            //request.ProtocolVersion = new Version("2.0"); //No momento, só há suporte para solicitações das versões HTTP/1.0 e HTTP/1.1.
            //request.Headers.Add(HttpRequestHeader.UserAgent, "Visual Studio"); //O cabeçalho 'User-Agent' deve ser modificado com a propriedade ou o método adequado.
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(new Cookie("Tema", "azul")); //O parâmetro '{0}' não pode ser uma cadeia de caracteres vazia. Nome do parâmetro: cookie.Domain

            Console.WriteLine(GetRequestToString(request));
        }

        public string GetRequestToString(HttpWebRequest request)
        {
            var requestLine = $"{request.Method} {request.RequestUri} HTTP/{request.ProtocolVersion}";
            var headers = "";

            foreach (var key in request.Headers.AllKeys)
            {
                headers += $"{key}: {request.Headers[key]}" + Environment.NewLine;
            }

            return requestLine + Environment.NewLine + headers;
        }
    }
}