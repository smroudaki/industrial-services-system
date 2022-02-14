﻿using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Posts.Queries.GetPostsByPagination
{
    public class GetPostsByPaginationDto : IMapFrom<Post>
    {
        public Guid PostGuid { get; set; }

        public string UserFullName { get; set; }

        public int ViewCount { get; set; }

        public int LikeCount { get; set; }

        public string Title { get; set; }

        public bool IsShow { get; set; }

        public bool IsSuggested { get; set; }

        public bool IsInSlider { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
