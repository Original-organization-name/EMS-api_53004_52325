using EMS.Contracts.Employee;
using EMS.Data.Employee.Entities;
using Mapster;

namespace EMS.Contracts.Mapster;

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
            
        config.NewConfig<ContactDto, Contact>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Data, src => src.Data)
            .Map(dest => dest.Privacy, src => src.Privacy);
        
        config.NewConfig<Contact, ContactDto>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Data, src => src.Data)
            .Map(dest => dest.Privacy, src => src.Privacy);
        
        config.NewConfig<Contact, ContactModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Data, src => src.Data)
            .Map(dest => dest.Privacy, src => src.Privacy);
        
        config.NewConfig<PaymentMethodDto, PaymentMethod>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.BankAccount, src => src.BankAccount);
        
        config.NewConfig<PaymentMethod, PaymentMethodDto>()
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.BankAccount, src => src.BankAccount);
            
        config.NewConfig<EmployeeDto, Data.Employee.Employee>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Surname, src => src.Surname)
            .Map(dest => dest.Pesel, src => src.Pesel)
            .Map(dest => dest.Nip, src => src.Nip)
            .Map(dest => dest.Birthdate, src => src.Birthdate)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Address, src => src.Address.Adapt<Address>())
            .Map(dest => dest.Contacts, src => src.Contacts.Adapt<List<Contact>>())
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.Adapt<PaymentMethod>());
            
        config.NewConfig<Data.Employee.Employee, EmployeeModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Surname, src => src.Surname)
            .Map(dest => dest.Pesel, src => src.Pesel)
            .Map(dest => dest.Nip, src => src.Nip)
            .Map(dest => dest.Birthdate, src => src.Birthdate)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Address, src => src.Address.Adapt<AddressDto>())
            .Map(dest => dest.Contacts, src => src.Contacts.Adapt<List<ContactModel>>())
            .Map(dest => dest.PaymentMethod, src => src.PaymentMethod.Adapt<PaymentMethodDto>());
    }
}