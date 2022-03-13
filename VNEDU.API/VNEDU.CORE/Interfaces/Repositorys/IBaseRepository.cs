using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Interfaces.Repositorys
{
    /// <summary>
    /// Giao diện triển khai Base
    /// CreateBy: TTThiep(28/02/2022)
    /// </summary>
    /// <typeparam name="VNEDUEntity"></typeparam>
    public interface IBaseRepository<VNEDUEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreateBy: TTThiep(28/02/2022)
        Object Get();

        /// <summary>
        /// Lấy thông tin một đối tượng
        /// </summary>
        /// <param name="EntityId"></param>
        /// <returns>Thông tin đôi tượng được lấy ra</returns>
        /// CreateBy: TTThiep(28/02/2022)
        Object GetById(int EntityId);

        /// <summary>
        /// Thêm thông tin một đối tượng
        /// </summary>
        /// <param name="vneduentity"></param>
        /// <returns>Số lượng bản ghi được thêm</returns>
        /// CreateBy: TTThiep(28/02/2022)
        int Insert(VNEDUEntity vneduentity);

        /// <summary>
        /// Sửa thông tin một đối tượng
        /// </summary>
        /// <param name="vneduentity"></param>
        /// <param name="EntityId"></param>
        /// <returns>Số lượng bản ghi được sửa</returns>
        /// CreateBy: TTThiep(28/02/2022)
        int Update(VNEDUEntity vneduentity, int EntityId);

        /// <summary>
        /// Xóa thông tin một đối tượng
        /// </summary>
        /// <param name="EntityId"></param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        /// CreateBy: TTThiep(28/02/2022)
        int Delete(int EntityId);
    }
}
