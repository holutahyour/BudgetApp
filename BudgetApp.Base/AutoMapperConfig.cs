using AutoMapper;
using BudgetApp.Base.Domain.DTO;
using BudgetApp.Base.Domain.Entities;
using BudgetApp.Base.Domain.Models;

namespace BudgetApp.Base
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserData>().ReverseMap();
            CreateMap<Budget, BudgetData>().ReverseMap();
            CreateMap<Expense, ExpenseData>().ReverseMap();
            CreateMap<Income, IncomeData>().ReverseMap();
            CreateMap<Saving, SavingData>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Budget, BudgetModel>().ReverseMap();
            CreateMap<Expense, ExpenseModel>().ReverseMap();
            CreateMap<Income, IncomeModel>().ReverseMap();
            CreateMap<Saving, SavingModel>().ReverseMap();
        }
    }
}
