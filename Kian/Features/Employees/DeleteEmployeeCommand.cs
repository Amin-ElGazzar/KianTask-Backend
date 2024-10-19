using AutoMapper;
using FluentValidation;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class DeleteEmployeeCommand : IRequest<Response<string>>
    {
        public int Id { get; private set; }
        public DeleteEmployeeCommand(int id)
        {
            this.Id = id;
        }
    }

    public class DeleteEmployeeHandler : ResponseHandler<string>, IRequestHandler<DeleteEmployeeCommand, Response<string>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public DeleteEmployeeHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = await _employeesRepo.GetById(request.Id);

            if (model == null) return NotFound("Employee not found");

            _employeesRepo.Delete(model);

            _unitOFWork.SaveChangesAsync(cancellationToken);

            return Deleted<string>();
        }
    }

    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required..");
        }
    }
}
