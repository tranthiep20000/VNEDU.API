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
    /// Tương tác database của Subject
    /// CreatedBy: TTThiep(02/03/2022)
    /// </summary>
    public class SubjectRepository : SQLServerDBContent, ISubjectRepository
    {
        #region Contructor
        public SubjectRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int SubjectId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteSubject";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectId", SubjectId);
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
                var sqlCommand = "Proc_GetSubjects";
                var subjects = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return subjects;
            }
        }

        public object GetById(int SubjectId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetSubjectById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectId", SubjectId);
                var subject = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return subject;
            }
        }

        public int Insert(Subject subject)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertSubject";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectName", subject.SubjectName);
                parameters.Add("@CreatedBy", subject.CreatedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Subject subject, int SubjectId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateSubject";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectId", SubjectId);
                parameters.Add("@SubjectName", subject.SubjectName);
                parameters.Add("@ModifiedBy", subject.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Subject CheckSubjectName(string SubjectName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetSubjectBySubjectName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SubjectName", SubjectName);
                var subjectnameCheck = sqlConnection.QueryFirstOrDefault<Subject>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return subjectnameCheck;
            }
        }

        public bool CheckSubjectNameUpdate(int SubjectId, string SubjectName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckSubjectName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@SubjectId", SubjectId);
                parameterscheck.Add("@SubjectName", SubjectName);
                var subjectnameCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in subjectnameCheck)
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
