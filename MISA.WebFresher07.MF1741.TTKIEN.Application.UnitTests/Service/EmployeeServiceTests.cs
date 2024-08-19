using AutoMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.Application.UnitTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        public IEmployeeValidate EmployeeValidate { get; set; }

        public EmployeeService EmployeeService { get; set; }

        public IMapper Mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = Substitute.For<IEmployeeValidate>();
            Mapper = Substitute.For<IMapper>();

            EmployeeService = Substitute.For<EmployeeService>(EmployeeRepository, EmployeeValidate, Mapper);
        }

        /// <summary>
        /// Hàm unit test lấy tất cả nhân viên thành công
        /// </summary>
        [Test]
        public async Task GetAllAsync_Success()
        {
            // Arrange
            // Act
            var employeeDtos = EmployeeService.GetAllAsync();

            // Assert
            await EmployeeRepository.Received(1).GetAllAsync();
        }

        /// <summary>
        /// Hàm unit test lấy một nhân viên thành công
        /// </summary>
        [Test]
        public async Task GetAsync_EmployeeId_Success()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await EmployeeService.GetAsync(id);

            // Assert
            await EmployeeRepository.Received(1).GetAsync(id);

        }

        /// <summary>
        /// Hàm unit test thêm mới nhân viên - EmployeeId empty
        /// </summary>
        [Test]
        public async Task InsertAsync_EmptyEmployeeId_NotEmptyEmployeeId()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };

            EmployeeService.MapEntityCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act 
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            Assert.That(employee.EmployeeId, Is.Not.EqualTo(Guid.Empty));
        }

        /// <summary>
        /// Hàm unit test thêm mới nhân viên - Kiểm tra audit fields sau khi insert
        /// </summary>
        [Test]
        public async Task InsertAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };

            EmployeeService.MapEntityCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act 
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            Assert.That(employee.CreateBy, Is.EqualTo("TTKIEN"));
            Assert.That(employee.ModifiedBy, Is.EqualTo("TTKIEN"));
        }

        /// <summary>
        /// Hàm unit test thêm mới nhân viên - Kiểm tra gọi đến các hàm khi insert
        /// </summary>
        [Test]
        public async Task InserAsync_ValidInput_Success()
        {
            // Arrange
            var employeeCreateDto = new EmployeeCreateDto();
            var employee = new Employee()
            {
                EmployeeId = Guid.Empty
            };

            EmployeeService.MapEntityCreateDtoToEntity(employeeCreateDto).Returns(employee);

            // Act 
            var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

            // Assert
            await EmployeeService.Received(1).ValidateCreateBusiness(employee);

            await EmployeeRepository.Received(1).InsertAsync(employee);
        }

        /// <summary>
        /// Hàm unit test hàm sửa nhân viên - Kiểm tra audit fields sau khi insert
        /// </summary>
        [Test]
        public async Task UpdateAsync_EmployeeAuditNull_EmployeeAuditNotNull()
        {
            // Arrange
            var employeeUpdateDto = new EmployeeUpdateDto();
            var id = Guid.NewGuid();
            var employee = new Employee()
            {
                EmployeeId = id,
            };
            var newEmployee = new Employee();

            EmployeeRepository.GetAsync(id).Returns(employee);
            EmployeeService.MapEntityUpdateDtoToEntity(employeeUpdateDto, employee).Returns(newEmployee);

            // Act
            var employeeDto = await EmployeeService.UpdateAsync(id, employeeUpdateDto);

            // Assert
            Assert.That(newEmployee.ModifiedBy, Is.EqualTo("TTKIEN"));
        }

        /// <summary>
        /// Hàm unit test hàm sửa nhân viên - Kiểm tra gọi đến các hàm khi update
        /// </summary>
        [Test]
        public async Task UpdateAsync_ValidInput_Success()
        {
            // Arrange
            var employeeUpdateDto = new EmployeeUpdateDto();
            var id = Guid.NewGuid();
            var employee = new Employee()
            {
                EmployeeId = id,
            };
            var newEmployee = new Employee();

            EmployeeRepository.GetAsync(id).Returns(employee);
            EmployeeService.MapEntityUpdateDtoToEntity(employeeUpdateDto, employee).Returns(newEmployee);

            // Act
            var employeeDto = await EmployeeService.UpdateAsync(id, employeeUpdateDto);

            // Assert
            await EmployeeService.Received(1).ValidateUpdateBusiness(newEmployee, employee);

            await EmployeeRepository.Received(1).UpdateAsync(newEmployee);
        }

        /// <summary>
        /// Hàm unit test cho hàm xóa một nhân viên
        /// </summary>
        [Test]
        public async Task DeleteAsync_Employee_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            var employee = new Employee()
            {
                EmployeeId = id,
            };

            EmployeeRepository.GetAsync(id).Returns(employee);

            // Act
            await EmployeeService.DeleteAsync(id);

            // Assert
            await EmployeeRepository.Received(1).DeleteAsync(employee);
        }
    }
}
