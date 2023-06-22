using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Incomes.Commands
{
    public class UpdateIncomeCommand : IRequest<Income>
    {
        public int Id { get; set; }
        public Income Income { get; set; }
    }

    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand, Income>
    {
        private readonly IIncomeRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public UpdateIncomeCommandHandler(IIncomeRepository expenseRepository, IMapper mapper, IBaseDbContext context)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Income> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var expense = request.Income;

            //var result = _expenseRepository.GetAllIncomes().Result.Any(x => x.Id == request.Id);

            //if (!result)
            //    throw new Exception($"invaild expense with id {request.Id}");

            expense.Id = request.Id;

            expense = await _expenseRepository.Update(request.Income);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var expenseData = _mapper.Map<Income>(expense);

            return expenseData;
        }
    }
}
