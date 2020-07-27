using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.FileProviders;
using PP.ValidatedInputService.Api.Models;

namespace PP.ValidatedInputService.Api.Services
{
    public class MovieRepository
    {
        private static ICollection<Movie> _movies;

        static MovieRepository() 
        {
            var provider = new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
            using (var stream = provider.GetFileInfo("Data/movies.json").CreateReadStream())
            {
                var reader = new StreamReader(stream, Encoding.UTF8);
                var json = reader.ReadToEnd();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                _movies = JsonSerializer.Deserialize<List<Movie>>(json, options);
            }
        }

        public IEnumerable<Movie> Find(string phrase, DateTime? fromDate, DateTime? toDate) 
        {
            return MovieRepository._movies.Where(m => {
                if ((phrase != null && !m.Title.ToLower().Contains(phrase.ToLower()))
                    || (fromDate.HasValue && m.Release < fromDate)
                    || (toDate.HasValue && m.Release > toDate)) return false;
                return true;
            });
        }

        public void Add(Movie movie)
        {
            MovieRepository._movies.Add(movie);
        }
    }
}