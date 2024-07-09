using AutoMapper;
using Domain.Entities;
using Entities;
using Shared.DataTransferObjects;
namespace ToDoManager;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>()
            .ForMember(c => c.UserName, opt => opt.MapFrom(x => x.Email));

        CreateMap<TaskItem, TaskItemDto>();
    }
}
