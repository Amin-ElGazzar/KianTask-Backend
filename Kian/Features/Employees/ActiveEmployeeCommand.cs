using AutoMapper;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class ActiveEmployeeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

    public class ActiveEmployeeHandler : ResponseHandler<string>, IRequestHandler<ActiveEmployeeCommand, Kian.Response.Response<string>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public ActiveEmployeeHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response.Response<string>> Handle(ActiveEmployeeCommand request, CancellationToken cancellationToken)
        {

            var model = await _employeesRepo.GetById(request.Id);

            if (model == null) return NotFound("Employee not found");

            _mapper.Map(request, model);

            model.LastUpdateDate = DateTime.Now;

            _employeesRepo.Update(model);

            await _unitOFWork.SaveChangesAsync(cancellationToken);

            return EditSuccess(string.Empty);
        }
    }

}
