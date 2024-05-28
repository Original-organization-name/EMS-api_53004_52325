using EMS.DTO.Employee;
using EMS.Data.Employees.Entities;
using Mapster;

namespace EMS.DTO.Mapster;

public class EmployeeRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddressDto, Address>()
            .Map(dest => dest.CountryCode, src => src.CountryCode)
            .Map(dest => dest.City, src => src.City)
            .Map(dest => dest.District, src => src.District)
            .Map(dest => dest.PostCode, src => src.PostCode)
            .Map(dest => dest.Street, src => src.Street)
            .Map(dest => dest.HouseNumber, src => src.HouseNumber)
            .Map(dest => dest.ApartmentNumber, src => src.ApartmentNumber);
        
        config.NewConfig<Address, AddressDto>()
            .Map(dest => dest.CountryCode, src => src.CountryCode)
            .Map(dest => dest.City, src => src.City)
            .Map(dest => dest.District, src => src.District)
            .Map(dest => dest.PostCode, src => src.PostCode)
            .Map(dest => dest.Street, src => src.Street)
            .Map(dest => dest.HouseNumber, src => src.HouseNumber)
            .Map(dest => dest.ApartmentNumber, src => src.ApartmentNumber);
        
        config.NewConfig<PaymentMethodDto, PaymentMethod>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.BankAccount, src => src.BankAccount);
        
        config.NewConfig<PaymentMethod, PaymentMethodDto>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.BankAccount, src => src.BankAccount);
            
        config.NewConfig<EmployeeDto, Data.Employees.Employee>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Surname, src => src.Surname)
            .Map(dest => dest.Pesel, src => src.Pesel)
            .Map(dest => dest.Nip, src => src.Nip)
            .Map(dest => dest.Birthdate, src => src.Birthdate)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Address, src => src.Address.Adapt<Address>())
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.Adapt<PaymentMethod>());
            
        config.NewConfig<Data.Employees.Employee, EmployeeModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Surname, src => src.Surname)
            .Map(dest => dest.Pesel, src => src.Pesel)
            .Map(dest => dest.Nip, src => src.Nip)
            .Map(dest => dest.Birthdate, src => src.Birthdate)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Address, src => src.Address.Adapt<AddressDto>())
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.Adapt<PaymentMethodDto>());
    }
}