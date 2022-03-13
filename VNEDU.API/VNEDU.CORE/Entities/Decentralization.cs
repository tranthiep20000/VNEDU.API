using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin quyền
    /// CreatedBy: TTThiep(01/03/2022)
    /// </summary>
    public class Decentralization
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public int DecentralizationId { get; set; }

        /// <summary>
        /// Tên quyền
        /// </summary>
        public string? DecentralizationName { get; set; }

        /// <summary>
        /// Mô tả quyền
        /// </summary>
        public string? Description { get; set; }
    }
}
