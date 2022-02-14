using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Posts.Queries.GetAcceptedPostComments
{
    public class AcceptedPostCommentDto : IMapFrom<PostComment>
    {
        public Guid PcGuid { get; set; }

        public string UserFullName { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostComment, AcceptedPostCommentDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.Comment.User.FirstName + " " + s.Comment.User.LastName))
                .ForMember(d => d.CommentText, opt => opt.MapFrom(s => s.Comment.Message))
                .ForMember(d => d.CommentDate, opt => opt.MapFrom(s => s.Comment.ModifiedDate));
        }
    }
}
