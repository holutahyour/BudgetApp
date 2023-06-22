using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Savings.Commands
{
    public class CreateSavingCommand : IRequest<Saving>
    {
        public SavingModel Saving { get; set; }
    }

    public class CreateSavingCommandHandler : IRequestHandler<CreateSavingCommand, Saving>
    {
        private readonly ISavingRepository _incomeRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public CreateSavingCommandHandler(ISavingRepository incomeRepository, IMapper mapper, IBaseDbContext context)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Saving> Handle(CreateSavingCommand request, CancellationToken cancellationToken)
        {
            var income =_mapper.Map<Saving>(request.Saving);

            income = await _incomeRepository.Update(income);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            var incomeData = _mapper.Map<Saving>(income);

            return incomeData;
        }
    }
}
