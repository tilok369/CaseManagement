using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASACaseFileManagement.API.Helpers;
using ASACaseFileManagement.API.Models;
using ASACaseManagement.Services.Entities;
using AutoMapper;

namespace ASACaseFileManagement.API.Profiles
{
    public class RespondentProfile: Profile
    {
        public RespondentProfile()
        {
            CreateMap<Respondent, RespondentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
        }
    }
}
