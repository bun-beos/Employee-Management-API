using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class DepartmentService : BaseReadOnlyService<Department, DepartmentDto>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public override DepartmentDto MapEntityToEntityDto(Department department)
        {
            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public override Department MapEntityDtoToEntity(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            return department;
        }
    }
}
