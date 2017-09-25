using System;
using System.Collections.Generic;
using DataAccess.Entity;
using Google.Protobuf.WellKnownTypes;

namespace Service.DTO
{
    public class MovieDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; private set; }
        
        public DateTime ReleaseDate { get; private set; }
        
        public TimeSpan TimeLength { get; private set; } 
        
        public int PG { get; private set; }
        
        public List<FullNameDto> Real { get; private set; }
        
        public List<FullNameDto> Actors { get; private set; }
        
        public string Synopsis { get; private set; }

        #region Methods

        /// <summary>
        /// Extract entity data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MovieDto Extract(Movie entity)
        {
            var dto = new MovieDto();
            if (entity == null)
                return dto;

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.ReleaseDate = entity.ReleaseDate;
            dto.TimeLength = entity.TimeLength;
            dto.PG = entity.PG;
            dto.Real = FullNameDto.ParseString(entity.Real);
            dto.Actors = FullNameDto.ParseString(entity.Actors);

            dto.Synopsis = entity.Synopsis;

            return dto;
        }
    
        /// <summary>
        /// Popualte movie data
        /// Create a new entity if none given
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Movie Populate(MovieDto dto, Movie entity = null)
        {
            if(entity == null)
                entity = new Movie();

            entity.Name = dto.Name;
            entity.ReleaseDate = dto.ReleaseDate;
            entity.TimeLength = dto.TimeLength;
            entity.PG = dto.PG;
            entity.Real = FullNameDto.Serialize(dto.Real);
            entity.Actors = FullNameDto.Serialize(dto.Actors);
            entity.Synopsis = dto.Synopsis;

            return entity;
        }
        #endregion
    }
}