﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IndustrialServicesSystem.Application.Posts.Commands.ChangePostCommentAcceptance;
using IndustrialServicesSystem.Application.Posts.Commands.ChangePostInSliderStatus;
using IndustrialServicesSystem.Application.Posts.Commands.ChangePostShowStatus;
using IndustrialServicesSystem.Application.Posts.Commands.ChangePostSuggestionStatus;
using IndustrialServicesSystem.Application.Posts.Commands.CreatePost;
using IndustrialServicesSystem.Application.Posts.Commands.CreatePostComment;
using IndustrialServicesSystem.Application.Posts.Commands.DeletePost;
using IndustrialServicesSystem.Application.Posts.Commands.DeletePostComment;
using IndustrialServicesSystem.Application.Posts.Commands.LikePost;
using IndustrialServicesSystem.Application.Posts.Commands.UpdatePost;
using IndustrialServicesSystem.Application.Posts.Queries.GetAcceptedPostComments;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetIndexPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetMonthlyMostViewedPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetMostViewedPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetPost;
using IndustrialServicesSystem.Application.Posts.Queries.GetPostsByCategory;
using IndustrialServicesSystem.Application.Posts.Queries.GetPostsByPagination;
using IndustrialServicesSystem.Application.Posts.Queries.GetRejectedPostCommentsQuery;
using IndustrialServicesSystem.Application.Posts.Queries.GetSliderPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetSuggestedPosts;
using IndustrialServicesSystem.Application.Posts.Queries.GetWeeklyMostViewedPosts;
using Swashbuckle.AspNetCore.Annotations;

namespace WebUI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PostController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// دریافت اطلاعات پست از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی</param>
        /// <returns></returns>
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<GetPostVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetPostQuery() { Guid = guid });
        }

        /// <summary>
        /// دریافت پست ها از طریق دسته بندی
        /// </summary>
        /// <param name="categoryGuid">آیدی دسته بندی</param>
        /// <param name="page">شماره صفحه</param>
        /// <returns></returns>
        [HttpGet("[action]/{categoryId}/{page}")]
        public async Task<ActionResult<GetPostsByCategoryVm>> GetByCategory(Guid categoryGuid, int page)
        {
            return await Mediator.Send(new GetPostsByCategoryQuery() { CategoryGuid = categoryGuid, Page = page });
        }

        /// <summary>
        /// دریافت تمامی پست ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllPostVm>> GetAll()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        /// <summary>
        /// دریافت تمامی پست ها Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetAllPostVm>> GetAllAnonymous()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        /// <summary>
        /// دریافت 3 پست شاخص Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetIndexPostsVm>> GetIndexesAnonymous()
        {
            return await Mediator.Send(new GetIndexPostsQuery());
        }

        /// <summary>
        /// دریافت 5 پست منتخب هفته Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetWeeklyMostViewedPostsVm>> GetWeeklyMostViewed()
        {
            return await Mediator.Send(new GetWeeklyMostViewedPostsQuery());
        }

        /// <summary>
        /// دریافت 5 پست منتخب ماه Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetMonthlyMostViewedPostsVm>> GetMonthlyMostViewed()
        {
            return await Mediator.Send(new GetMonthlyMostViewedPostsQuery());
        }

        /// <summary>
        /// دریافت 15 پست پربازدید Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetMostViewedPostsVm>> GetMostViewedAnonymous()
        {
            return await Mediator.Send(new GetMostViewedPostsQuery());
        }

        /// <summary>
        /// دریافت پست های اسلایدر
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetSliderPostsVm>> GetSliderPosts()
        {
            return await Mediator.Send(new GetSliderPostsQuery());
        }

        /// <summary>
        /// دریافت پست های منتخبین سردبیر
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetSuggestedPostsVm>> GetSuggestedPosts()
        {
            return await Mediator.Send(new GetSuggestedPostsQuery());
        }

        /// <summary>
        /// دریافت پست ها از طریق شماره صفحه
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <returns></returns>
        [HttpGet("[action]/{page}")]
        public async Task<ActionResult<GetPostsByPaginationVm>> GetByPagination(int page)
        {
            return await Mediator.Send(new GetPostsByPaginationQuery() { Page = page });
        }

        /// <summary>
        /// دریافت نظرات پذیرفته شده
        /// </summary>
        /// <param name="postGuid">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postGuid}/[action]")]
        public async Task<ActionResult<AcceptedPostCommentsVm>> GetAcceptedComments(Guid postGuid)
        {
            return await Mediator.Send(new GetAcceptedPostCommentsQuery() { PostGuid = postGuid });
        }

        /// <summary>
        /// دریافت نظرات پذیرفته نشده
        /// </summary>
        /// <param name="postGuid">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postGuid}/[action]")]
        public async Task<ActionResult<RejectedPostCommentsVm>> GetRejectedComments(Guid postGuid)
        {
            return await Mediator.Send(new GetRejectedPostCommentsQuery() { PostGuid = postGuid });
        }

        /// <summary>
        /// افزودن پست جدید
        /// </summary>
        /// <param name="command">اطلاعات پست</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreatePostCommandVm>> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// لایک پست
        /// </summary>
        /// <param name="command">آیدی پست</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Like(LikePostCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت نمایش پست
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangePostShowStatusVm>> ChangeShowStatus(ChangePostShowStatusCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت نمایش پست در اسلایدر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangePostInSliderStatusVm>> ChangeInSliderStatus(ChangePostInSliderStatusCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت نمایش پست در منتخبین سردبیر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangePostSuggestionStatusVm>> ChangeSuggestionStatus(ChangePostSuggestionStatusCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن نظر جدید
        /// </summary>
        /// <param name="command">اطلاعات نظر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateComment(CreatePostCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت پذیرش نظر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> ChangeCommentAcceptance(ChangePostCommentAcceptanceCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش پست
        /// </summary>
        /// <param name="command">اطلاعات نظر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<UpdatePostCommandVm>> Update(UpdatePostCommandDto command)
        {
            if (command == null)
            {
                return new UpdatePostCommandVm
                {
                    Message = "مقادیر ارسال نشده",
                    State = -1
                };
            }

            return await Mediator.Send(new UpdatePostCommand { Command = command, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// حذف پست
        /// </summary>
        /// <param name="guid">آیدی پست</param>
        /// <returns></returns>
        [HttpPost("[action]/{guid}")]
        public async Task<ActionResult<DeletePostCommandVm>> Delete(Guid guid)
        {
            return await Mediator.Send(new DeletePostCommand { PostGuid = guid });
        }

        /// <summary>
        /// حذف نظر
        /// </summary>
        /// <param name="guid">آیدی نظر</param>
        /// <returns></returns>
        [HttpPost("[action]/{guid}")]
        public async Task<ActionResult<int>> DeleteComment(Guid guid)
        {
            return await Mediator.Send(new DeletePostCommentCommand { PostCommentGuid = guid });
        }
    }
}