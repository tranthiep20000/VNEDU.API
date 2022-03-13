using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;
using VNEDU.CORE.Interfaces.Repositorys;
using VNEDU.CORE.Interfaces.Services;

namespace VNEDU.CORE.Services
{
    /// <summary>
    /// Dịch vụ của DetailedTableScore
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class DetailedTableScoreService : IDetailedTableScoreService
    {
        #region Feild
        IDetailedTableScoreRepository _detailedTableScoreRepository;
        string errorMsg = "";
        #endregion

        #region Contructor
        public DetailedTableScoreService(IDetailedTableScoreRepository detailedTableScoreRepository)
        {
            _detailedTableScoreRepository = detailedTableScoreRepository;
        }
        #endregion

        #region Method
        public int Update(DetailedTableScore detailedTableScore, int DetailedTableScoreId)
        {
            // Thực hiện validate dữ liệu

            // Thực hiện sửa dữ liệu vào DB -> công việc này của Repository
            return _detailedTableScoreRepository.Update(detailedTableScore, DetailedTableScoreId);
        }

        #endregion
    }
}
