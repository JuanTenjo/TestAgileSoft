using AutoMapper;
using TestAgileSoft.Application.Dtos;
using TestAgileSoft.Application.Tasks.Commands;

namespace TestAgileSoft.Application.Profiles.Tasks
{
    public class TaksProfiles : Profile
    {
        public TaksProfiles() 
        {
            CreateMap<Domain.Entities.Tasks, TaskInfoDto>().ReverseMap();
            CreateMap<TaskInfoDto, Domain.Entities.Tasks> ().ReverseMap();
            CreateMap<CreateTaskCommand, Domain.Entities.Tasks>().ReverseMap();
            CreateMap<Domain.Entities.Tasks, CreateTaskCommand>().ReverseMap();
        }
    }
}
