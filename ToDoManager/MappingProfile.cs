﻿using AutoMapper;
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

        CreateMap<TaskItem, TaskItemWithCategoryDto>();

        CreateMap<TaskItemForCreationDto, TaskItem>().
            ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<TaskItemForUpdateDto, TaskItem>();

        CreateMap<CategoryForCreationDto, Category>();

        CreateMap<CategoryForUpdateDto, Category>();

        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
