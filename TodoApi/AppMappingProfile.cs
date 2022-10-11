using AutoMapper;
using ToDo.Models;

namespace TodoApi
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>();
            
        }
    }
}
