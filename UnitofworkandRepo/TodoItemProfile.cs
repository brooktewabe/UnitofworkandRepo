using AutoMapper;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo
{

    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, ToDoItemRespDTO>();
        }
    }

}
