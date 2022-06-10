using AutoMapper;
using EmployeeBase.BLL.Models;
using EmployeeBase.Controllers.InputModels;
using EmployeeBase.Controllers.OutputModels;

namespace API
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<EmployeeInputModel, EmployeeModel>();
            CreateMap<EmployeeUpdateModel, EmployeeModel>();
            CreateMap<EmployeePromotionModel, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeOutputModel>();
        }
    }
}
