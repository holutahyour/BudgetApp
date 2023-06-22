using AutoMapper;
using MediatR;
using BudgetApp.Base.Persistence;
using BudgetApp.Persistence.Interfaces;

namespace BudgetApp.Services.Savings.Commands
{
    public class DeleteSavingCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteSavingCommandHandler : IRequestHandler<DeleteSavingCommand, string>
    {
        private readonly ISavingRepository _savingRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDbContext _context;

        public DeleteSavingCommandHandler(ISavingRepository savingRepository, IMapper mapper, IBaseDbContext context)
        {
            _savingRepository = savingRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(DeleteSavingCommand request, CancellationToken cancellationToken)
        {
            var saving = await _savingRepository.GetSavingById(request.Id);

            if (saving == null)
                throw new Exception($"invaild saving with id {request.Id}");

            var result = await _savingRepository.Delete(saving);

            _context.SaveChangesAsync(cancellationToken).Wait(cancellationToken);

            if (result)
                return "saving successfully deleted";
            else
                throw new Exception("unable to delete saving due to some errors");
        }
    }
}
