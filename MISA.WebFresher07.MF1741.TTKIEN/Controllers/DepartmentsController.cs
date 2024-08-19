using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher07.MF1741.TTKIEN.Application;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System.Data;
using System.Net;
using System.Reflection;

namespace MISA.WebFresher07.MF1741.TTKIEN
{
    public class DepartmentsController : BaseReadOnlyController<DepartmentDto>
    {
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService) { }

        //private readonly IDepartmentService _departmentService;

        //public DepartmentsController(IDepartmentService departmentService)
        //{
        //    _departmentService = departmentService;
        //}

        //#region Hàm lấy tất cả đơn vị
        //// CreatedBy: ttkien (19/9/2023)
        //[HttpGet]
        //public async Task<List<Department>> GetAllDepartmentAsync()
        //{
        //    var result = await _departmentService.GetAllDepartmentAsync();
        //    return result;
        //}
        //#endregion
    }
}
