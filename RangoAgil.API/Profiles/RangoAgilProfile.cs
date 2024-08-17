﻿using AutoMapper;
using RangoAgil.API.Entities;
using RangoAgil.API.Models;

namespace RangoAgil.API.Profiles;

public class RangoAgilProfile : Profile
{
    public RangoAgilProfile()
    {
        CreateMap<Rango, RangoDTO>().ReverseMap();
        CreateMap<Rango, RangoForCreateDTO>().ReverseMap();
        CreateMap<Rango, RangoForUpdateDTO>().ReverseMap();
        CreateMap<Ingredient, IngredientDTO>().ForMember(
            d => d.RangoId,
            o => o.MapFrom(s => s.Rangos.First().Id)
            );
    }
}
