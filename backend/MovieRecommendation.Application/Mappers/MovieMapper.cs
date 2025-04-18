﻿using MovieRecommendation.Application.DTOs;
using MovieRecommendation.Domain.Entities;
namespace MovieRecommendation.Application.Mappers
{
    public static class MovieMapper
    {
        public static MovieDTO ToDto(this Movie movie) 
        {
            return new MovieDTO
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Title = movie.Title,
                MeanRating = movie.MeanRating
            }; 
        }
        public static Movie ToEntity(this CreateMovieDTO movieDto)
        {
            return new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre
            };
        }
    }
}
