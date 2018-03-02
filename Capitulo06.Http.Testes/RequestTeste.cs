using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo06.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void RequestGetMethodTeste()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com?usuarioId=42&cpf=22&");
            request.Method = "GET";

            //request.UserAgent = "Visual Studio";
            //request.Date = DateTime.Now;

            //request.ProtocolVersion = new Version("2.0"); //No momento, só há suporte para solicitações das versões HTTP/1.0 e HTTP/1.1.
            //request.Headers.Add(HttpRequestHeader.UserAgent, "Visual Studio"); //O cabeçalho 'User-Agent' deve ser modificado com a propriedade ou o método adequado.
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(new Cookie("Tema", "azul")); //O parâmetro '{0}' não pode ser uma cadeia de caracteres vazia. Nome do parâmetro: cookie.Domain

            Console.WriteLine(GetRequestToString(request));

            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Query string: " + request.RequestUri.Query);

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));
        }

        public string GetRequestToString(HttpWebRequest request)
        {
            var requestLine = $"{request.Method} {request.RequestUri} HTTP/{request.ProtocolVersion}";

            return requestLine +
                Environment.NewLine +
                GetHeaders(request.Headers);
        }

        private static string GetHeaders(WebHeaderCollection header)
        {
            var headers = "";

            foreach (var key in header.AllKeys)
            {
                headers += $"{key}: {header[key]}" + Environment.NewLine;
            }

            return headers;
        }

        public string GetResponseToString(HttpWebResponse response)
        {
            var statusLine = $"HTTP/{response.ProtocolVersion} {(int)response.StatusCode} {response.StatusDescription}";
            var reader = new StreamReader(response.GetResponseStream());

            return statusLine + 
                Environment.NewLine + 
                GetHeaders(response.Headers) +
                Environment.NewLine +
                reader.ReadToEnd();
        }
    }
}