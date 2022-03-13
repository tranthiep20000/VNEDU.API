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
    /// Tương tác database của Student
    /// CreatedBy: TTThiep(03/03/2022)
    /// </summary>
    public class StudentRepository : SQLServerDBContent, IStudentRepository
    {
        #region Contructor
        public StudentRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int StudentId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteStudent";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
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
                var sqlCommand = "Proc_GetStudents";
                var students = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return students;
            }
        }

        public object GetById(int StudentId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetStudentById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                var student = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student;
            }
        }

        public Object GetInformationStudentByPhoneNumber(string PhoneNumber)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetInformationStudentByPhoneNumber";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PhoneNumber", PhoneNumber);
                var student = sqlConnection.QueryFirstOrDefault<Object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return student;
            }
        }

        public Object GetPagingStudent(string? ValueFilter, int PageIndex, int PageSize)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetPagingStudents";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ValueFilter", ValueFilter);
                parameters.Add("@PageIndex", PageIndex);
                parameters.Add("@PageSize", PageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var students = sqlConnection.Query<Object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                // 2. trả về dữ liệu
                var totalRecord = parameters.Get<int>("@TotalRecord");
                var totalPage = parameters.Get<int>("@TotalPage");
                return new
                {
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    Data = students
                };
            }
        }

        public int Insert(Student student)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertStudent";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentCode", student.StudentCode);
                parameters.Add("@FullName", student.FullName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DateOfBirth", student.DateOfBirth);
                parameters.Add("@PhoneNumber", student.PhoneNumber);
                parameters.Add("@Address", student.Address);
                parameters.Add("@CreatedBy", student.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Student student, int StudentId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateStudent";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StudentId", StudentId);
                parameters.Add("@StudentCode", student.StudentCode);
                parameters.Add("@FullName", student.FullName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DateOfBirth", student.DateOfBirth);
                parameters.Add("@PhoneNumber", student.PhoneNumber);
                parameters.Add("@Address", student.Address);
                parameters.Add("@ModifiedBy", student.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Student CheckStudentCode(string StudentCode)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetStudentByStudentCode";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@StudentCode", StudentCode);
                var studentCodeCheck = sqlConnection.QueryFirstOrDefault<Student>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return studentCodeCheck;
            }
        }

        public bool CheckStudentCodeUpdate(int StudentId, string StudentCode)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckStudentCode";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@StudentId", StudentId);
                parameterscheck.Add("@StudentCode", StudentCode);
                var studentCodeCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in studentCodeCheck)
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

        public Student CheckPhoneNumber(string PhoneNumber)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetStudentByPhoneNumber";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@PhoneNumber", PhoneNumber);
                var phoneNumberCheck = sqlConnection.QueryFirstOrDefault<Student>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return phoneNumberCheck;
            }
        }

        public bool CheckPhoneNumberUpdate(int StudentId, string PhoneNumber)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckStudentPhoneNumber";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@StudentId", StudentId);
                parameterscheck.Add("@PhoneNumber", PhoneNumber);
                var phoneNumberCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in phoneNumberCheck)
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
