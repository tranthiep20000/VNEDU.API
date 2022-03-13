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
    public class DecentralizationRepository : SQLServerDBContent, IDecentralizationRepository
    {
        #region Contructor
        public DecentralizationRepository()
        {

        }
        #endregion

        #region Method
        public int Delete(int DecentralizationId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_DeleteDecentralization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DecentralizationId", DecentralizationId);
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
                var sqlCommand = "Proc_GetDecentralizations";
                var decentralizations = sqlConnection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return decentralizations;
            }
        }

        public object GetById(int DecentralizationId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetDecentralizationById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DecentralizationId", DecentralizationId);
                var decentralization = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return decentralization;
            }
        }

        public int Insert(Decentralization decentralization)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_InsertDecentralization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DecentralizationName", decentralization.DecentralizationName);
                parameters.Add("@Description", decentralization.Description);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public int Update(Decentralization decentralization, int DecentralizationId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateDecentralization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DecentralizationId", DecentralizationId);
                parameters.Add("@DecentralizationName", decentralization.DecentralizationName);
                parameters.Add("@Description", decentralization.Description);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }

        public Decentralization CheckDecentralizationName(string DecentralizationName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_GetDecentralizationByDecentralizationName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@DecentralizationName", DecentralizationName);
                var decentralizationnameCheck = sqlConnection.QueryFirstOrDefault<Decentralization>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return decentralizationnameCheck;
            }
        }

        public bool CheckDecentralizationNameUpdate(int DecentralizationId ,string DecentralizationName)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. Lấy dữ liệu từ DB
                var sqlCommandcheck = "Proc_CheckDecentralizationName";
                DynamicParameters parameterscheck = new DynamicParameters();
                parameterscheck.Add("@DecentralizationId", DecentralizationId);
                parameterscheck.Add("@DecentralizationName", DecentralizationName);
                var decentralizationnameCheck = sqlConnection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                foreach (var i in decentralizationnameCheck)
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
