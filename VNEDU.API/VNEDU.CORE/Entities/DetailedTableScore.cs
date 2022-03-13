using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEDU.CORE.Entities
{
    /// <summary>
    /// Thông tin bảng điểm
    /// CreatedBy: TTThiep(04/03/2022)
    /// </summary>
    public class DetailedTableScore
    {
        /// <summary>
        /// Mã bảng điểm
        /// </summary>
        public int DetailedTableScoreId { get; set; }

        /// <summary>
        /// Điểm miệng 1
        /// </summary>
        public float FirstOralScore { get; set; }

        /// <summary>
        /// Điểm miệng 2
        /// </summary>
        public float? SecondOralScore { get; set; }

        /// <summary>
        /// Điểm miệng 3
        /// </summary>
        public float? ThirdOralScore { get; set; }

        /// <summary>
        /// Điểm 15 phút 1
        /// </summary>
        public float? First15minutesScore { get; set; }

        /// <summary>
        /// Điểm 15 phút 2
        /// </summary>
        public float? Second15minutesScore { get; set; }

        /// <summary>
        /// Điểm 15 phút 3
        /// </summary>
        public float? Third15minutesScore { get; set; }

        /// <summary>
        /// Điểm 1 tiết
        /// </summary>
        public float? OnePeriodScore { get; set; }

        /// <summary>
        /// Điểm cuối kì
        /// </summary>
        public float? FinalScore { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
