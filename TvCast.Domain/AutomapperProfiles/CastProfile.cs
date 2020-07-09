using System.Collections.Generic;
using AutoMapper;
using TvCast.Domain.TvMazeModels;
using TvCast.Entity.Entities;
using TvCast.Entity.Entities.Data;

namespace TvCast.Domain.AutomapperProfiles
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<TvMazeShow, IList<Casting>>()
                .ConstructUsing((s, rc) =>
                {
                    IList<Casting> casts = new List<Casting>();

                    foreach (var c in s.Embedded.Cast)
                    {
                        var cast = new Casting();
                        cast.Show = new Show
                        {
                            Id = s.Id,
                            Data = new ShowData
                            {
                                Name = s.Name,
                                Image = new ImageData
                                {
                                    Medium = s.Image?.Medium,
                                    Original = s.Image?.Medium
                                }
                            }
                        };
                        if (c.Person != null)
                        {
                            cast.Person = new Person
                            {
                                Id = c.Person?.Id,
                                Data = new PersonData
                                {
                                    Name = c.Person?.Name,
                                    Birthday = c.Person?.Birthday,
                                    Image = new ImageData
                                    {
                                        Medium = c.Person?.Image?.Medium,
                                        Original = c.Person?.Image?.Original
                                    }
                                }
                            };
                        }
                        if (c.Character != null)
                        {
                            cast.Character = new Character
                            {
                                Id = c.Character?.Id,
                                Data = new CharacterData
                                {
                                    Name = c.Character?.Name,
                                    Image = new ImageData
                                    {
                                        Medium = c.Character?.Image?.Medium,
                                        Original = c.Character?.Image?.Original
                                    }
                                }
                            };    
                        }
                        
                        casts.Add(cast);
                    }
                    return casts;
                });
        }
    }
}