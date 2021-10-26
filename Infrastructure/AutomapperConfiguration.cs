using AutoMapper;
using Buecherapp.Models;
using Buecherapp.ViewModels;


// TODO: Comment
namespace Buecherapp.Infrastructure
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<BookEditViewModel, Book>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));

            CreateMap<Book, BookListViewModel>();
        }
    }

}