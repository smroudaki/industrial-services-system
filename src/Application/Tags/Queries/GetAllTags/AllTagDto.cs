﻿using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Tags.Queries.GetAllTags
{
    public class AllTagDto : IMapFrom<Tag>
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, AllTagDto>()
                .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.TagGuid))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
