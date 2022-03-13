using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNEDU.CORE.Entities;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai DetailedTableScore
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public interface IDetailedTableScoreRepository
    {
       /// <summary>
       /// Sửa thông tin của một bảng điểm
       /// </summary>
       /// <param name="detailedTableScore">Bảng điểm</param>
       /// <param name="DetailedTableScoreId">Mã bảng điểm</param>
       /// <returns>Số bản ghi sửa thành công</returns>
       /// CreatedBy: TTThiep(04/03/2022)
        int Update(DetailedTableScore detailedTableScore, int DetailedTableScoreId);

        object GetById(int DetailedTableScoreId);
    }
}
