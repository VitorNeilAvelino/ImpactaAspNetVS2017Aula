using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitulo06.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void RequestGetMethodTeste()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.example.com?nome=Vitor&cpf=123");
            request.Method = "GET";
            request.Date = DateTime.Now;
            request.UserAgent = "Visual Studio";

            Console.WriteLine(GetRequestToString(request));

            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Query string: " + request.RequestUri.Query);

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));
        }

        [TestMethod]
        public void RequestPostMethodTeste()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://httpbin.org/post");
            request.Method = "POST";

            var dados = "placa=ABC1234&ano=2014&modelo=Fiesta";
            var bytes = new ASCIIEncoding().GetBytes(dados);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            request.GetRequestStream().Write(bytes, 0, bytes.Length);

            Console.WriteLine(GetRequestToString(request, dados));

            Console.WriteLine(new string('-', 100));

            var response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(GetResponseToString(response));
        }

        private string GetResponseToString(HttpWebResponse response)
        {
            var statusLine = $"HTTP/{response.ProtocolVersion} {(int)response.StatusCode} {response.StatusDescription}";
            var reader = new StreamReader(response.GetResponseStream());

            return statusLine +
                Environment.NewLine +
                GetHeaders(response.Headers) +
                Environment.NewLine +
                reader.ReadToEnd();
        }

        private string GetRequestToString(HttpWebRequest request, string dados = "")
        {
            var requestLine = $"{request.Method} {request.RequestUri} HTTP/1.1";

            return requestLine +
                Environment.NewLine +
                GetHeaders(request.Headers) +
                Environment.NewLine + 
                dados;
        }

        private string GetHeaders(WebHeaderCollection header)
        {
            var headers = "";

            foreach (var key in header.AllKeys)
            {
                headers += $"{key}: {header[key]}" + Environment.NewLine;
            }

            return headers;
        }
    }
}
