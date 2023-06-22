using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Incomes.Commands
{
    public class CreateIncomeCommand : IRequest<Income>
    {
        public IncomeModel Income { get; set; }
    }

    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, Income>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateIncomeCommandHandler(IIncomeRepository incomeRepository, IMapper mapper, IBaseDbContext context)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Income> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income =_mapper.Map<Income>(request.Income);

            income = await _incomeRepository.Update(income);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var incomeData = _mapper.Map<Income>(income);

            return incomeData;
        }
    }
}
