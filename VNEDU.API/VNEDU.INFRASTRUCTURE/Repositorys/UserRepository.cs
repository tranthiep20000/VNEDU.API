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
    /// Tương tác database của User
    /// </summary>
    public class UserRepository : SQLServerDBContent, IUserRepository
    {
        #region Contructor
        public UserRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int UserId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
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
                var sqlCommand = "Proc_GetUsers";
                var users = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return users;
            }
        }

        public Object GetPagingUser(string? ValueFilter, int PageIndex, int PageSize)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetPagingUsers";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ValueFilter", ValueFilter);
                parameters.Add("@PageIndex", PageIndex);
                parameters.Add("@PageSize", PageSize);
                parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                parameters.Add("@TotalPage", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var users = sqlConnection.Query<Object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                // 2. trả về dữ liệu
                var totalRecord = parameters.Get<int>("@TotalRecord");
                var totalPage = parameters.Get<int>("@TotalPage");
                return new
                {
                    TotalRecord = totalRecord,
                    TotalPage = totalPage,
                    Data = users
                };
            }
        }

        public object GetUserByPhoneNumberPassword(string PhoneNumber, string Password)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetUserByPhoneNumberAndPassword";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PhoneNumber", PhoneNumber);
                parameters.Add("@Password", Password);
                var user = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return user;
            }
        }

        public object GetById(int UserId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetUserById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                var user = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return user;
            }
        }

        public int Insert(Used used)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", used.UserName);
                parameters.Add("@PhoneNumber", used.PhoneNumber);
                parameters.Add("@Password", used.Password);
                parameters.Add("@DecentralizationId", used.DecentralizationId);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Used used, int UserId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                parameters.Add("@UserName", used.UserName);
                parameters.Add("@PhoneNumber", used.PhoneNumber);
                parameters.Add("@Password", used.Password);
                parameters.Add("@DecentralizationId", used.DecentralizationId);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int UpdatePassword(int UserId, string Password)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdatePasswordUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                parameters.Add("@Password", Password);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Used CheckPhoneNumber(string PhoneNumber)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetUserByPhoneNumber";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@PhoneNumber", PhoneNumber);
                var phonenumberCheck = sqlConnection.QueryFirstOrDefault<Used>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return phonenumberCheck;
            }
        }

        public bool CheckPhoneNumberUpdate(int UserId, string PhoneNumber)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckPhoneNumber";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@UserId", UserId);
                parameterscheck.Add("@PhoneNumber", PhoneNumber);
                var phonenumberCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in phonenumberCheck)
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
