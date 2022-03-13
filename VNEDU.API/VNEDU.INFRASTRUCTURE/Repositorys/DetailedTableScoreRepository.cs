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
    /// Tương tác database DetailedTableScore
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class DetailedTableScoreRepository : SQLServerDBContent, IDetailedTableScoreRepository
    {
        #region Contructor
        public DetailedTableScoreRepository()
        {

        }
        #endregion

        #region Method
        public object GetById(int DetailedTableScoreId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_GetDetailedTableScoreById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DetailedTableScoreId", DetailedTableScoreId);
                var detailedTableScore = sqlConnection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return detailedTableScore;
            }
        }

        public int Update(DetailedTableScore detailedTableScore, int DetailedTableScoreId)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                // 1. thực hiện lấy dữ liệu trong database
                var sqlCommand = "Proc_UpdateDetailedTableScore";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DetailedTableScoreId", DetailedTableScoreId);
                parameters.Add("@FirstOralScore", detailedTableScore.FirstOralScore);
                parameters.Add("@SecondOralScore", detailedTableScore.SecondOralScore);
                parameters.Add("@ThirdOralScore", detailedTableScore.ThirdOralScore);
                parameters.Add("@First15minutesScore", detailedTableScore.First15minutesScore);
                parameters.Add("@Second15minutesScore", detailedTableScore.Second15minutesScore);
                parameters.Add("@Third15minutesScore", detailedTableScore.Third15minutesScore);
                parameters.Add("@OnePeriodScore", detailedTableScore.OnePeriodScore);
                parameters.Add("@FinalScore", detailedTableScore.FinalScore);
                parameters.Add("@ModifiedBy", detailedTableScore.ModifiedBy);
                var res = sqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                // 2. trả về dữ liệu
                return res;
            }
        }
        #endregion
    }
}
