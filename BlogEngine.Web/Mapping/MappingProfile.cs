using AutoMapper;
using BlogEngine.Model;
using BlogEngine.Web.ViewModels;

namespace BlogEngine.Web.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.PostDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => src.ThumbnailImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => src.ViewCount))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments != null ? src.Comments.Count : 0))
                ;

            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CommentDate, opt => opt.MapFrom(src => src.CommentDate))
                ;
        }
    }
}
