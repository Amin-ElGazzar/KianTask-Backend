using Kian.Context;
using Kian.Contract.Repositories;
using Kian.Entities;

namespace Kian.Repositories;

public class EmployeesRepo : BaseRepo<Employees>, IEmployeesRepo
{
    private readonly ApplicationDbContext _context;

    public EmployeesRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
