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
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.PostDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => src.ThumbnailImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => 10))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => 1))
                ;
        }
    }
}
