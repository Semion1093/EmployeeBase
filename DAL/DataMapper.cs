using AutoMapper;
using EmployeeBase.BLL.Models;
using EmployeeBase.DAL.Entities;

namespace EmployeeBase.DAL
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
