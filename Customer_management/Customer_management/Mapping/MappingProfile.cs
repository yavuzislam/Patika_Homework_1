using AutoMapper;
using Customer_management.Common;
using Customer_management.CustomerOperations.Command.CreateCustomer;
using Customer_management.CustomerOperations.Command.PatchCustomer;
using Customer_management.CustomerOperations.Command.UpdateCustomer;
using Customer_management.CustomerOperations.Query.GetBooks;
using Customer_management.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Customer_management.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomersViewModel>().ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.Name + " " + src.Surname))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.IncomeLevel,
                opt => opt.MapFrom(src => ((IncomeLevelType)src.IncomeLevelId).ToString()))
            .ForMember(dest => dest.MartialStatus,
                opt => opt.MapFrom(src => ((MartialStatusType)src.MartialStatusId).ToString()));

        CreateMap<Customer, GetCustomerViewModel>().ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.Name + " " + src.Surname))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.IncomeLevel,
                opt => opt.MapFrom(src => ((IncomeLevelType)src.IncomeLevelId).ToString()))
            .ForMember(dest => dest.MartialStatus,
                opt => opt.MapFrom(src => ((MartialStatusType)src.MartialStatusId).ToString()));

        CreateMap<CreateCustomerModel, Customer>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date));

        CreateMap<UpdateCustomerModel, Customer>().ForMember(dest => dest.IncomeLevelId,
            opt => opt.MapFrom(src => ((IncomeLevelType)src.IncomeLevelId).ToString())).ForMember(
            dest => dest.MartialStatusId,
            opt => opt.MapFrom(src => ((MartialStatusType)src.MartialStatusId).ToString()));

        CreateMap<JsonPatchDocument<PatchCustomerModel>, PatchCustomerModel>().ForAllMembers(opt => opt.Ignore());
    }
}