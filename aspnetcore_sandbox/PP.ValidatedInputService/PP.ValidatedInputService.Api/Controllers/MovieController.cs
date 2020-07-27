using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PP.ValidatedInputService.Api.Models;
using PP.ValidatedInputService.Api.Services;
using PP.ValidatedInputService.Api.DTOs;
using System.Collections.Generic;

namespace PP.ValidatedInputService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository _repository;
        private readonly ILogger<MovieController> _logger;

        public MovieController(MovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _repository = movieRepository;
            _logger = logger;
        }

        [HttpGet]
        public ApiResponse<IEnumerable<Movie>> Get(
            [MinLength(3)]
            string phrase = null, 
            DateTime? releasedFrom = null, 
            DateTime? releasedTo = null)
        {
            return new ApiResponse<IEnumerable<Movie>>(_repository.Find(phrase, releasedFrom, releasedTo));
        }

        [HttpPost]
        public ApiResponse<object> Post([FromBody, Required] Movie movie)
        {
            _repository.Add(movie);
            
            return ApiResponse<object>.Ok();
        }
    }
}
