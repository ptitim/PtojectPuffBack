using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Service.DTO
{
        public class SeanceDto
        {
                public int Id { get; private set; }
                
                public decimal? Price { get; private set; }
                
                public DateTime? Date { get; private set; }
                
                #region Methods
                
                /// <summary>
                /// Extract data
                /// </summary>
                /// <param name="entity"></param>
                /// <returns></returns>
                public static SeanceDto Extract(Seance entity)
                {
                        var dto = new SeanceDto();
                        if (entity == null)
                                return dto;
                        
                        dto.Id = entity.Id;
                        dto.Date = entity.Date;
                        dto.Price = entity.Price;
                        
                        return dto;
                }

//                public static List<SeanceDto> Extract(List<Seance> entities)
//                {
//                        return entities.Select(SeanceDto.Extract).ToList();
//                }

                /// <summary>
                /// Extract data
                /// </summary>
                /// <param name="entities"></param>
                /// <returns></returns>
                public static List<SeanceDto> Extract(IEnumerable<SeanceEvent> entities)
                {
                        return entities.Select(se => SeanceDto.Extract(se.Seance)).ToList();
                }
                
                
                /// <summary>
                /// Populate seance data
                /// Create entity if none given
                /// </summary>
                /// <param name="dto"></param>
                /// <param name="entity"></param>
                /// <returns></returns>
                public static Seance Populate(SeanceDto dto, Seance entity = null)
                {
                        if(entity == null)
                                entity = new Seance();
                        
                        
                        entity.Date = dto.Date ?? default(DateTime);
                        entity.Price = dto.Price;

                        return entity;
                }

//                public static ICollection<Seance> Populate(List<SeanceDto> dtos, List<Seance> entities)
//                {
//                        return dtos.Select(sc =>
//                        {
//                                var entity = entities.FirstOrDefault(en => en.Id == sc.Id);
//
//                                return SeanceDto.Populate(sc, entity);
//                        })
//                }
                #endregion
        }
}