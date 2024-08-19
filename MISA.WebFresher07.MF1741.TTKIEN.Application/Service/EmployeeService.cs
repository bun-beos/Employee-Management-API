using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application
{
    public class EmployeeService : BaseService<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidate _employeeValidate;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeValidate employeeValidate, IMapper mapper) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeValidate = employeeValidate;
            _mapper = mapper;
        }

        /// <summary>
        /// Hàm chuyển Employee sang EmployeeDto
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Thông tin nhân viên đầu ra</returns>
        public override EmployeeDto MapEntityToEntityDto(Employee employee)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public override Employee MapEntityDtoToEntity(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return employee;
        }

        /// <summary>
        /// Hàm chuyển EmployeeCreateDto sang Employee
        /// </summary>
        /// <param name="entityCreateDto">Thông tin nhân viên mơi</param>
        /// <returns>Thông tin nhân viên đầu ra</returns>
        public override Employee MapEntityCreateDtoToEntity(EmployeeCreateDto employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);

            employee.EmployeeId = Guid.NewGuid();
            employee.CreateDate = DateTime.Now;
            employee.CreateBy = "TTKIEN";
            employee.ModifiedDate = DateTime.Now;
            employee.ModifiedBy = "TTKIEN";
            
            return employee;
        }

        /// <summary>
        /// validate business dữ liệu nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên mới</param>
        /// <returns></returns>
        public override async Task ValidateCreateBusiness(Employee employee)
        {
            // Check trùng mã nhân viên
            await _employeeValidate.CheckEmployeeExistAsync(employee);
        }

        /// <summary>
        /// Hàm chuyển EmployeeUpdateDto sang Employee
        /// </summary>
        /// <param name="entityUpdateDto">Thông tin nhân viên đã sửa</param>
        /// <param name="entity">Thông tin nhân viên mới</param>
        /// <returns>Thông tin nhân viên đầu ra</returns>
        public override Employee MapEntityUpdateDtoToEntity(EmployeeUpdateDto employeeUpdateDto, Employee employee)
        {
            var newEmployee = _mapper.Map(employeeUpdateDto, employee);

            newEmployee.ModifiedDate = DateTime.Now;
            newEmployee.ModifiedBy = "TTKIEN";
            
            return newEmployee;
        }

        /// <summary>
        /// validate business dữ liệu nhân viên vừa sửa
        /// </summary>
        /// <param name="employee">thông tin mới của nhân viên</param>
        /// <param name="employeeOld">thông tin cũ của nhân viên</param>
        /// <returns></returns>
        public override async Task ValidateUpdateBusiness(Employee employee, Employee employeeOld)
        {
            if (employee.EmployeeCode != employeeOld.EmployeeCode)
            {
                await _employeeValidate.CheckEmployeeExistAsync(employee);
            }
        }

        public async Task<(List<EmployeeDto>,int)> FilterAsync(int pageSize, int pageNumber, string? fullName = null, string? employeeCode = null, string? phoneNumber = null)
        {
            var (employees, totalRows) = await _employeeRepository.FilterAsync(pageSize, pageNumber, fullName, employeeCode, phoneNumber);

            var employeeDtos = employees.Select(employee => MapEntityToEntityDto(employee)).ToList();

            return (employeeDtos, totalRows);
        }

    }
}
