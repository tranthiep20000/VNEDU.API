using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;
using VNEDU.CORE.Interfaces.Repositorys;

namespace VNEDU.INFRASTRUCTURE.Repositorys
{
    /// <summary>
    /// Tương tác database của Class
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public class ClassRepository : SQLServerDBContent, IClassRepository
    {
        #region Contructor
        public ClassRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ClassId", ClassId);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public object Get()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetClasss";
                var classs = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return classs;
            }
        }

        public object GetById(int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetClassById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ClassId", ClassId);
                var Class = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return Class;
            }
        }

        public object GetBySchoolYearId(int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetClassBySchoolYearId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                var Class = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return Class;
            }
        }

        public int Insert(Class Class)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ClassName", Class.ClassName);
                parameters.Add("@SchoolYearId", Class.SchoolYearId);
                parameters.Add("@CreatedBy", Class.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Class Class, int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ClassId", ClassId);
                parameters.Add("@ClassName", Class.ClassName);
                parameters.Add("@SchoolYearId", Class.SchoolYearId);
                parameters.Add("@ModifiedBy", Class.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Class CheckClassName(string ClassName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetClassByClassName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@ClassName", ClassName);
                var classnameCheck = sqlConnection.QueryFirstOrDefault<Class>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return classnameCheck;
            }
        }

        public bool CheckClassNameUpdate(int ClassId, string ClassName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckClassName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@ClassId", ClassId);
                parameterscheck.Add("@ClassName", ClassName);
                var classnameCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in classnameCheck)
                {
                    if (i.Value == 0)
                    {
                        // 2. trả về dữ liệu
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion
    }
}
