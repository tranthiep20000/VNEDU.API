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
    /// Tương tác database của Student_Subject
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class Student_SubjectRepository : SQLServerDBContent, IStudent_SubjectRepository
    {
        #region Contructor
        public Student_SubjectRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int StudentId, int SubjectId, int SemesterId, int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteStudent_Subject";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@SubjectId", SubjectId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SchoolYearId", SchoolYearId);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public object Get(int StudentId, int SemesterId, int SchoolYearId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetStudent_SubjectByStudentSemesterSchoolYear";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SchoolYearId", SchoolYearId);
                var student_subjects = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student_subjects;
            }
        }

        public Object GetPagingStudentSubjectBySchoolYearSemesterSubjectClass(int SchoolYearId, int SemesterId, int SubjectId, int ClassId, string? ValueFilter, int PageIndex, int PageSize)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetPagingStudent_SubjectBySchoolYearSemesterSubjectClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SubjectId", SubjectId);
                parameters.Add("@ClassId", ClassId);
                parameters.Add("@ValueFilter", ValueFilter);
                parameters.Add("@PageIndex", PageIndex);
                parameters.Add("@PageSize", PageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var student_subjects = sqlConnection.Query<Object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                // 2. trả về dữ liệu
                var totalRecord = parameters.Get<int>("@TotalRecord");
                var totalPage = parameters.Get<int>("@TotalPage");
                return new
                {
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    Data = student_subjects
                };
            }
        }

        public object GetScoreByStudent(int SchoolYearId, int SemesterId, int StudentId, int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetStudent_SubjectBySchoolYearSemesterStudentClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@ClassId", ClassId);
                var student_subjects = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student_subjects;
            }
        }

        public object GetScoreBySubject(int SchoolYearId, int SemesterId, int SubjectId, int ClassId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetStudent_SubjectBySchoolYearSemesterSubjectClass";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SchoolYearId", SchoolYearId);
                parameters.Add("@SemesterId", SemesterId);
                parameters.Add("@SubjectId", SubjectId);
                parameters.Add("@ClassId", ClassId);
                var student_subjects = sqlConnection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student_subjects;
            }
        }

        public int Insert(Student_Subject student_Subject)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertStudent_Subject";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", student_Subject.StudentId);
                parameters.Add("@SubjectId", student_Subject.SubjectId);
                parameters.Add("@SemesterId", student_Subject.SemesterId);
                parameters.Add("@SchoolYearId", student_Subject.SchoolYearId);
                parameters.Add("@CreatedBy", student_Subject.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public object CheckStudentSubject(int SubjectId, int SemesterId, int SchoolYearId, int StudentId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetStudent_SubjectBySubjectSemesterSchoolYearStudent";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SubjectId", SubjectId);
                parameterscheck.Add("@SemesterId", SemesterId);
                parameterscheck.Add("@SchoolYearId", SchoolYearId);
                parameterscheck.Add("@StudentId", StudentId);
                var studentsubjectCheck = sqlConnection.QueryFirstOrDefault<object>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return studentsubjectCheck;
            }
        }
        #endregion
    }
}
