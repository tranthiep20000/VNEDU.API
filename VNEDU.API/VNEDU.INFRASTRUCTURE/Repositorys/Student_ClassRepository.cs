using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;
using VNEDU.CORE.Interfaces.Repositorys;

namespace VNEDU.INFRASTRUCTURE.Repositorys
{
    /// <summary>
    /// Tương tác database của Student_Class
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_ClassRepository : SQLServerDBContent, IStudent_ClassRepository
    {
        #region Contructor
        public Student_ClassRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int StudentId, int ClassId, int SemesterId, int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteStudent_Class";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@ClassId", ClassId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SchoolYearId", SchoolYearId);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public object Get(int SchoolYearId, int SemesterId, int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetStudent_ClassByClassSemesterSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@ClassId", ClassId);
                var student_class = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student_class;
            }
        }

        public Object GetPagingStudentClassByClassSemesterSchoolYear(int SchoolYearId, int SemesterId, int ClassId, string? ValueFilter, int PageIndex, int PageSize)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetPagingStudent_ClassByClassSemesterSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@ClassId", ClassId);
                parameters.Add("@ValueFilter", ValueFilter);
                parameters.Add("@PageIndex", PageIndex);
                parameters.Add("@PageSize", PageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var student_classs = sqlConnection.Query<Object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                // 2. trả về dữ liệu
                var totalRecord = parameters.Get<int>("@TotalRecord");
                var totalPage = parameters.Get<int>("@TotalPage");
                return new
                {
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    Data = student_classs
                };
            }
        }

        public object GetClassByStudentSchoolYearSemester(int StudentId, int SchoolYearId, int SemesterId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetClassByStudentSchoolYearSemester";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                var student_class = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student_class;
            }
        }

        public int Insert(Student_Class student_Class)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertStudent_Class";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", student_Class.StudentId);
                parameters.Add("@ClassId", student_Class.ClassId);
                parameters.Add("@SemesterId", student_Class.SemesterId);
                parameters.Add("@SchoolYearId", student_Class.SchoolYearId);
                parameters.Add("@CreatedBy", student_Class.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public object CheckStudentClass(int SchoolYearId, int SemesterId, int ClassId, int StudentId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetStudent_ClassByClassSemesterSchoolYearStudent";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SchoolYearId", SchoolYearId);
                parameterscheck.Add("@SemesterId", SemesterId);
                parameterscheck.Add("@ClassId", ClassId);
                parameterscheck.Add("@StudentId", StudentId);
                var studentclassCheck = sqlConnection.QueryFirstOrDefault<object>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return studentclassCheck;
            }
        }
        #endregion
    }
}
