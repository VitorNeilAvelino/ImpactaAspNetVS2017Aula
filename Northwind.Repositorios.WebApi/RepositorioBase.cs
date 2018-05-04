using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi
{
    public class RepositorioBase<T>
    {
        private string _url;

        public RepositorioBase(string url)
        {
            _url = url.TrimEnd('/');
        }

        public HttpClient Cliente { get; private set; } = new HttpClient();

        public async Task<T> Post(T entidade)
        {
            using (var resposta = await Cliente.PostAsJsonAsync($"{_url}", entidade))
            {
                resposta.EnsureSuccessStatusCode();

                return await resposta.Content.ReadAsAsync<T>();
            }
        }

        public async Task Put(int id, T entidade)
        {
            using (var response = await Cliente.PutAsJsonAsync($"{_url}/{id}", entidade))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<T>> Get()
        {
            using (var response = await Cliente.GetAsync($"{_url}"))
            {
                return await response.Content.ReadAsAsync<List<T>>();
            }
        }

        public async Task<T> Get(int id)
        {
            using (var response = await Cliente.GetAsync($"{_url}/{id}"))
            {
                return await response.Content.ReadAsAsync<T>();
            }
        }

        public async Task Delete(int id)
        {
            using (var response = await Cliente.DeleteAsync($"{_url}/{id}"))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}