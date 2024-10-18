using AutoMapper;

namespace Kian.Features.Employees
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeCommand, Kian.Entities.Employees>();
            CreateMap<UpdateEmployeeCommand, Kian.Entities.Employees>();
            CreateMap<ActiveEmployeeCommand, Kian.Entities.Employees>();
        }
    }
}
