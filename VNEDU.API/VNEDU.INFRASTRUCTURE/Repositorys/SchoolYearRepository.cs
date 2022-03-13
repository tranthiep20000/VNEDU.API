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
    /// Tương tác database của SchoolYear
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SchoolYearRepository : SQLServerDBContent, ISchoolYearRepository
    {
        #region Contructor
        public SchoolYearRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
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
                var sqlCommand = "Proc_GetSchoolYears";
                var schoolYears = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return schoolYears;
            }
        }

        public object GetById(int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetSchoolYearById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                var schoolYear = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return schoolYear;
            }
        }

        public int Insert(SchoolYear schoolYear)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearName", schoolYear.SchoolYearName);
                parameters.Add("@CreatedBy", schoolYear.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(SchoolYear schoolYear, int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SchoolYearName", schoolYear.SchoolYearName);
                parameters.Add("@ModifiedBy", schoolYear.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public SchoolYear CheckSchoolYearName(string SchoolYearName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetSchoolYearBySchoolYearName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SchoolYearName", SchoolYearName);
                var schoolyearnameCheck = sqlConnection.QueryFirstOrDefault<SchoolYear>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return schoolyearnameCheck;
            }
        }

        public bool CheckSchoolYearNameUpdate(int SchoolYearId, string SchoolYearName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckSchoolYearName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SchoolYearId", SchoolYearId);
                parameterscheck.Add("@SchoolYearName", SchoolYearName);
                var schoolyearnameCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in schoolyearnameCheck)
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
