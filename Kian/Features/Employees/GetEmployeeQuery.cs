using AutoMapper;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class GetEmployeeQuery : IRequest<Response<IEnumerable<Kian.Entities.Employees>>>
    {
    }

    public class GetEmployeeHandler : ResponseHandler<IEnumerable<Kian.Entities.Employees>>,
        IRequestHandler<GetEmployeeQuery, Response<IEnumerable<Kian.Entities.Employees>>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<Entities.Employees>>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var models = await _employeesRepo.GetAllAsync();

            return Success(models);
        }
    }
}
