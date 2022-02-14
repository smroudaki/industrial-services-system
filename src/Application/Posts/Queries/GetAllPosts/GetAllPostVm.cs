using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetAllPostDto> Posts { get; set; }
    }
}
