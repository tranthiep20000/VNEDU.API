namespace Student.Managerment.API.Models
{
    /// <summary>
    /// Thông tin bảng điểm
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    public class DetailedTableScore
    {
        #region propertys
        /// <summary>
        /// Khóa chính bảng học sinh
        /// CreatedBy: TTThiep(22/01/2022)
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Khóa chính bảng học kì
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Khóa chính bảng năm học
        /// </summary>
        public int SchoolYearId { get; set; }

        /// <summary>
        /// Khóa chính bảng môn học
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Điểm miệng
        /// </summary>
        public float ScoreOral { get; set; }

        /// <summary>
        /// Điểm 15 phút
        /// </summary>
        public float Score15Minutes { get; set; }

        /// <summary>
        /// Điểm 1 tiết
        /// </summary>
        public float Score1Period { get; set; }

        /// <summary>
        /// Điểm cuối kì
        /// </summary>
        public float ScoreFinal { get; set; }
        #endregion
    }
}
