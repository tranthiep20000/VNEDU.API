using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Services
{
    /// <summary>
    /// Giao diện dịch vụ DetailedTableScore
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public interface IDetailedTableScoreService
    {
       /// <summary>
       /// Xử lý nghiệp vụ sửa dữ liêu
       /// </summary>
       /// <param name="detailedTableScore">Bảng điểm</param>
       /// <param name="DetailedTableScoreId">Mã bảng điểm</param>
       /// <returns>Số bản ghi sửa thành công</returns>
       /// CreatedBy: TTThiep(04/03/2022)
        int Update(DetailedTableScore detailedTableScore, int DetailedTableScoreId);
    }
}
