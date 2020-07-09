using System.Linq;
using AutoMapper;
using TvCast.Domain.Models;
using TvCast.Entity.Entities;

namespace TvCast.Domain.AutomapperProfiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<Show, ShowModel>()
                .ConvertUsing((s, d) =>
                {
                    var model = new ShowModel
                    {
                        Id = s.Id,
                        Name = s.Data?.Name,
                        Castings = s.Castings?.Select(i => new CastingModel
                        {
                            Character = new CharacterModel
                            {
                                Id = i.Character?.Id, 
                                Name = i.Character?.Data.Name, 
                                Image = new ImageModel
                                {
                                    Medium = i.Character?.Data?.Image?.Medium, 
                                    Original = i.Character?.Data?.Image?.Original
                                }
                            },
                            Person = new PersonModel
                            {
                                Id = i.Person?.Id,
                                Name = i.Person?.Data?.Name,
                                Birthday = i.Person?.Data?.Birthday
                            }
                        })
                    };
                    return model;
                });
        }
    }
}