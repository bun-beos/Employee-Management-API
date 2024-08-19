using Dapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System.Data;
using static Dapper.SqlMapper;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using OfficeOpenXml;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net;
using Swashbuckle.Swagger;

namespace MISA.WebFresher07.MF1741.TTKIEN.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public override async Task<int> InsertAsync(Employee employee)
        {
            // Tạo biến đầu vào
            var param = new
            {
                p_EmployeeId = employee.EmployeeId,
                p_EmployeeCode = employee.EmployeeCode,
                p_FullName = employee.FullName,
                p_DateOfBirth = employee.DateOfBirth,
                p_Gender = employee.Gender,
                p_DepartmentId = employee.DepartmentId,
                p_PositionName = employee.PositionName,
                p_IdentityNumber = employee.IdentityNumber,
                p_IdentityDate = employee.IdentityDate,
                p_IdentityPlace = employee.IdentityPlace,
                p_Address = employee.Address,
                p_TelephoneNumber = employee.TelephoneNumber,
                p_MobilePhoneNumber = employee.MobilePhoneNumber,
                p_Email = employee.Email,
                p_BankAccount = employee.BankAccount,
                p_BankName = employee.BankName,
                p_BankBranch = employee.BankBranch,
                p_CreateDate = employee.CreateDate,
                p_CreateBy = employee.CreateBy,
                p_ModifiedDate = employee.ModifiedDate,
                p_ModifiedBy = employee.ModifiedBy,
            };

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.ExecuteAsync("Proc_Employee_Post", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public override async Task<int> UpdateAsync(Employee employee)
        {
            // Tạo biến đầu vào
            var param = new
            {
                p_EmployeeId = employee.EmployeeId,
                p_EmployeeCode = employee.EmployeeCode,
                p_FullName = employee.FullName,
                p_DateOfBirth = employee.DateOfBirth,
                p_Gender = employee.Gender,
                p_DepartmentId = employee.DepartmentId,
                p_PositionName = employee.PositionName,
                p_IdentityNumber = employee.IdentityNumber,
                p_IdentityDate = employee.IdentityDate,
                p_IdentityPlace = employee.IdentityPlace,
                p_Address = employee.Address,
                p_TelephoneNumber = employee.TelephoneNumber,
                p_MobilePhoneNumber = employee.MobilePhoneNumber,
                p_Email = employee.Email,
                p_BankAccount = employee.BankAccount,
                p_BankName = employee.BankName,
                p_BankBranch = employee.BankBranch,
                p_CreateDate = employee.CreateDate,
                p_CreateBy = employee.CreateBy,
                p_ModifiedDate = employee.ModifiedDate,
                p_ModifiedBy = employee.ModifiedBy,
            };

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.ExecuteAsync("Proc_Employee_Put", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<(List<Employee>, int)> FilterAsync(int pageSize, int pageNumber, string? fullName = null, string? employeeCode = null, string? mobilePhoneNumber = null)
        {
            // Tạo biến đầu vào
            var param = new
            {
                p_pageSize = pageSize,
                p_pageNumber = pageNumber,
                p_Fullname = fullName,
                p_EmployeeCode = employeeCode,
                p_MobilePhoneNumber = mobilePhoneNumber
            };

            // Thực hiện truy vấn
            var result = await UnitOfWork.Connection.QueryMultipleAsync($"proc_{TableName}_Filter", param, commandType: CommandType.StoredProcedure, transaction: UnitOfWork.Transaction);

            var employees = result.Read<Employee>().ToList();

            var totalRows = result.Read<int>().Single();

            return (employees, totalRows);

        }

        public async Task<bool> IsExistEmployeeAsync(string employeeCode)
        {
            // Tạo biến đầu vào
            var param = new { p_EmployeeCode = employeeCode };

            var result = await UnitOfWork.Connection.QuerySingleOrDefaultAsync("Proc_Employee_GetByCode", param, commandType: CommandType.StoredProcedure);

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
