using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Interfaces.Services
{
    /// <summary>
    /// Giao diện dịch vụ base
    /// CreatedBy: TTThiep(28/02/2022)
    /// </summary>
    /// <typeparam name="VNEDUEntity"></typeparam>
    public interface IBaseService<VNEDUEntity>
    {
        /// <summary>
        /// Xử lý nghiệp vụ thêm mới dữ liệu
        /// CreatedBy: TTThiep(28/02/2022)
        /// </summary>
        /// <param name="vneduentity"></param>
        /// <returns>Số bản ghi thêm mới thành công</returns>
        int Insert(VNEDUEntity vneduentity);

        /// <summary>
        /// Xử lý nghiệp vụ sửa dữ liệu
        /// CreatedBy: TTThiep(28/02/2022)
        /// </summary>
        /// <param name="vneduentity"></param>
        /// <returns>Số bản ghi sửa thành công</returns>
        int Update(VNEDUEntity vneduentity, int EntityId);

        /// <summary>
        /// Xử lý nghiệp vụ Xóa dữ liệu
        /// CreatedBy: TTThiep(28/02/2022)
        /// </summary>
        /// <param name="vneduentity"></param>
        /// <returns>Số bản ghi xóa thành công</returns>
        int Delete(int EntityId);
    }
}
