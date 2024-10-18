using AutoMapper;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class GetEmployeeByIdQuery : IRequest<Response<Kian.Entities.Employees>>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdHandler : ResponseHandler<Kian.Entities.Employees>, IRequestHandler<GetEmployeeByIdQuery, Response<Kian.Entities.Employees>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response<Entities.Employees>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _employeesRepo.GetById(request.Id);

            if (model == null) return NotFound("Employee not found");

            return Success(model);
        }
    }
}
