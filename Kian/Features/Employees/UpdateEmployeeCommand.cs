using AutoMapper;
using FluentValidation;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class UpdateEmployeeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateEmployeeHandler : ResponseHandler<string>, IRequestHandler<UpdateEmployeeCommand, Response<string>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
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

    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary must be a positive number.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }
}
