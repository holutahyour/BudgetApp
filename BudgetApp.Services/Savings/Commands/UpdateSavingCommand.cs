using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Savings.Commands
{
    public class UpdateSavingCommand : IRequest<Saving>
    {
        public int Id { get; set; }
        public Saving Saving { get; set; }
    }

    public class UpdateSavingCommandHandler : IRequestHandler<UpdateSavingCommand, Saving>
    {
        private readonly ISavingRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public UpdateSavingCommandHandler(ISavingRepository expenseRepository, IMapper mapper, IBaseDbContext context)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Saving> Handle(UpdateSavingCommand request, CancellationToken cancellationToken)
        {
            var expense = request.Saving;

            //var result = _expenseRepository.GetAllSavings().Result.Any(x => x.Id == request.Id);

            //if (!result)
            //    throw new Exception($"invaild expense with id {request.Id}");

            expense.Id = request.Id;

            expense = await _expenseRepository.Update(request.Saving);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var expenseData = _mapper.Map<Saving>(expense);

            return expenseData;
        }
    }
}
