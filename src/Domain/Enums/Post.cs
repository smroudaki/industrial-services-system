using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreatePostState
    {
        Success = 1,
        DocumentGuidProblem = 2,
        UserNotFound = 3,
        DocumentNotFound = 4,
        SliderNotFound = 5
    }

    public enum UpdatePostState
    {
        Success = 1,
        DocumentNotFound = 2,
        UserNotFound = 3,
        PostNotFound = 4,
        SliderNotFound = 5
    }

    public enum GetPostState
    {
        Success = 1,
        PostNotFound = 2
    }

    public enum GetAllPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetMostViewedPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetIndexPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetSuggestedPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetSliderPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum DeletePostState
    {
        Success = 1,
        PostNotFound = 2
    }

    public enum ChangePostShowStatusState
    {
        Success = 1,
        PostNotFound = 2
    }

    public enum ChangePostInSliderStatusState
    {
        Success = 1,
        PostNotFound = 2,
        SliderNotFound = 3
    }

    public enum ChangePostSuggestionStatusState
    {
        Success = 1,
        PostNotFound = 2
    }
}
