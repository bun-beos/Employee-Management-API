using Dapper;
using MISA.WebFresher07.MF1741.TTKIEN.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MISA.WebFresher07.MF1741.TTKIEN.Application;

namespace MISA.WebFresher07.MF1741.TTKIEN.Infrastructure
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
