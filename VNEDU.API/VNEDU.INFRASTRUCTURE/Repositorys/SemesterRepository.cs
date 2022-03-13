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
    /// Tương tác database Semester
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SemesterRepository : SQLServerDBContent, ISemesterRepository
    {
        #region Contructor
        public SemesterRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int SemesterId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteSemester";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SemesterId", SemesterId);
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
                var sqlCommand = "Proc_GetSemesters";
                var semesters = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return semesters;
            }
        }

        public object GetById(int SemesterId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetSemesterById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SemesterId", SemesterId);
                var semester = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return semester;
            }
        }

        public int Insert(Semester semester)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertSemester";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SemesterName", semester.SemesterName);
                parameters.Add("@CreatedBy", semester.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Semester semester, int SemesterId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateSemester";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SemesterName", semester.SemesterName);
                parameters.Add("@ModifiedBy", semester.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Semester CheckSemesterName(string SemesterName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetSemesterBySemesterName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SemesterName", SemesterName);
                var semesternameCheck = sqlConnection.QueryFirstOrDefault<Semester>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return semesternameCheck;
            }
        }

        public bool CheckSemesterNameUpdate(int SemesterId, string SemesterName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckSemesterName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SemesterId", SemesterId);
                parameterscheck.Add("@SemesterName", SemesterName);
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
