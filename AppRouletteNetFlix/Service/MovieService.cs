using System;
using System.Net.Http;
using System.Collections.Generic;
using AppRouletteNetFlix.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppRouletteNetFlix.Service
{
    public class MovieService
    {
        private HttpClient _client = new HttpClient();
        private List<Movie> _movies;

        public async Task<List<Movie>> LocalizarFilmesPorAtor(string ator)
        {
            if (string.IsNullOrWhiteSpace(ator)) {
                return null;
            }

            string url = string.Format("http://netflixroulette.net/api/api.php?actor={0}", ator);
            var response = await _client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                _movies = new List<Movie>();
                return _movies;
            }

            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Movie>>(content);

            _movies = new List<Movie>(movies);
            return _movies;
        }

    }
}
