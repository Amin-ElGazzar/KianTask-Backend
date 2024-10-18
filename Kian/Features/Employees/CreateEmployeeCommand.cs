using AutoMapper;
using FluentValidation;
using Kian.Contract.Repositories;
using Kian.Response;
using MediatR;

namespace Kian.Features.Employees
{
    public class CreateEmployeeCommand : IRequest<Kian.Response.Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateEmployeeHandler : ResponseHandler<string>, IRequestHandler<CreateEmployeeCommand, Kian.Response.Response<string>>
    {
        private readonly IEmployeesRepo _employeesRepo;
        private readonly IUnitOFWork _unitOFWork;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeesRepo employeesRepo, IUnitOFWork unitOFWork, IMapper mapper)
        {
            _employeesRepo = employeesRepo;
            _unitOFWork = unitOFWork;
            _mapper = mapper;
        }
        public async Task<Response.Response<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var modle = _mapper.Map<Kian.Entities.Employees>(request);

            await _employeesRepo.CreateAsync(modle);

            await _unitOFWork.SaveChangesAsync(cancellationToken);

            return Created();
        }
    }


    public class CreateEmployeesValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeesValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

            RuleFor(e => e.Address)
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

            RuleFor(e => e.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary must be a positive number.");

            RuleFor(e => e.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }

}
