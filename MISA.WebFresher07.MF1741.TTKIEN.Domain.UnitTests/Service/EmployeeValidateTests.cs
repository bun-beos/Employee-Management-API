using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace MISA.WebFresher07.MF1741.TTKIEN.Domain.UnitTests
{
    [TestFixture]
    public class EmployeeValidateTests
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        public EmployeeValidate EmployeeValidate { get; set; }

        [SetUp]
        public void Setup()
        {
            EmployeeRepository = Substitute.For<IEmployeeRepository>();
            EmployeeValidate = Substitute.For<EmployeeValidate>(EmployeeRepository);
        }

        [Test]
        public async Task CheckEmployeeExistAsync_NotExistEmployee_Success()
        {
            //Arrange
            var employee = new Employee();

            //Act
            await EmployeeValidate.CheckEmployeeExistAsync(employee);

            //Assert
            await EmployeeRepository.Received(1).IsExistEmployeeAsync(employee.EmployeeCode);
        }

        [Test]
        public async Task CheckEmployeeExistAsync_NotExistEmployee_ThrowException()
        {
            //Arrange
            var employee = new Employee();
            EmployeeRepository.IsExistEmployeeAsync(employee.EmployeeCode).Returns(true);

            //Act && Assert
            var exception = Assert.ThrowsAsync<ConflictException>(async () => await EmployeeValidate.CheckEmployeeExistAsync(employee));

            Assert.That(exception.ErrorCode, Is.EqualTo((int)ErrorCodeEnum.ConflictExceptionCode));

            await EmployeeRepository.Received(1).IsExistEmployeeAsync(employee.EmployeeCode);
        }
    }
}
