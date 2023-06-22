using AutoMapper;
using MediatR;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Persistence.Interfaces;
using System;

namespace BudgetApp.Services.Savings.Queries
{
    public class GetSavingQuery : IRequest<Saving>
    {
        public int Id { get; set; }
    }

    public class GetSavingQueryHandler : IRequestHandler<GetSavingQuery, Saving>
    {
        private readonly ISavingRepository _savingRepository;
        private readonly IMapper _mapper;

        public GetSavingQueryHandler(ISavingRepository savingRepository, IMapper mapper)
        {
            _savingRepository = savingRepository;
            _mapper = mapper;
        }

        public async Task<Saving> Handle(GetSavingQuery request, CancellationToken cancellationToken)
        {
            var saving = await _savingRepository.GetSavingById(request.Id);

            if (saving == null)
                throw new Exception($"invaild saving with id {request.Id}");

            return saving;
        }
    }
}
