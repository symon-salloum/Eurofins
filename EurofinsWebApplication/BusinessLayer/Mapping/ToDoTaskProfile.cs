﻿using AutoMapper;
using BusinessLayer.Domain.ToDoTask;
using BusinessLayer.DTO;

namespace BusinessLayer.Mapping
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<ToDoTask, ToDoTaskDTO>();
            CreateMap<ToDoTaskDTO, ToDoTask>();
        }
    }
}
