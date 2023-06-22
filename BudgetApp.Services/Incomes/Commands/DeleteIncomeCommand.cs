using AutoMapper;
using MediatR;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Incomes.Commands
{
    public class DeleteIncomeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand, string>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public DeleteIncomeCommandHandler(IIncomeRepository incomeRepository, IMapper mapper, IBaseDbContext context)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await _incomeRepository.GetIncomeById(request.Id);

            if (income == null)
                throw new Exception($"invaild income with id {request.Id}");

            var result = await _incomeRepository.Delete(income);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            if (result)
                return "income successfully deleted";
            else
                throw new Exception("unable to delete income due to some errors");
        }
    }
}
