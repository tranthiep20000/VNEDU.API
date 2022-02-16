using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API năm học
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolYearsController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";


        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả năm học
        /// </summary>
        /// <returns>Danh sách năm học</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET: api/<SchoolYearsController>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetSchoolYears";
                    var schoolyears = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, schoolyears);
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ Admin để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// Lấy thông tin một năm học
        /// </summary>
        /// <param name="SchoolYearId">Mã năm học</param>
        /// <returns>Thông tin một năm học</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET api/<SchoolYearsController>/5
        [HttpGet("{SchoolYearId}")]
        public IActionResult Get(int SchoolYearId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetSchoolYearById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SchoolYearId", SchoolYearId);
                    var schoolyear = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, schoolyear);
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ Admin để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// Thêm một năm học
        /// </summary>
        /// <param name="schoolyear">Năm học</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // POST api/<SchoolYearsController>
        [HttpPost]
        public IActionResult Post([FromBody] SchoolYear schoolyear)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên năm học không được để trống
                    if (schoolyear.SchoolYearName == null || schoolyear.SchoolYearName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên năm học không được phép để trống.",
                            userMsg = "Tên năm học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertSchoolYear";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SchoolYearName", schoolyear.SchoolYearName);
                    var res = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();

                    // 2. trả về dữ liệu
                    if (res > 0)
                    {
                        return StatusCode(201, res);
                    }
                    else
                    {
                        return StatusCode(200, res);
                    }
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ Admin để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// Sửa một năm học
        /// </summary>
        /// <param name="SchoolYearId">Mã năm học</param>
        /// <param name="schoolyear">Năm học</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // PUT api/<SchoolYearsController>/5
        [HttpPut("{SchoolYearId}")]
        public IActionResult Put(int SchoolYearId, [FromBody] SchoolYear schoolyear)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên năm học không được để trống
                    if (schoolyear.SchoolYearName == null || schoolyear.SchoolYearName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên năm học không được phép để trống.",
                            userMsg = "Tên năm học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateSchoolYear";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SchoolYearId", SchoolYearId);
                    parameters.Add("@SchoolYearName", schoolyear.SchoolYearName);
                    var res = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();

                    // 2. trả về dữ liệu
                    if (res > 0)
                    {
                        return StatusCode(201, res);
                    }
                    else
                    {
                        return StatusCode(200, res);
                    }
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ Admin để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// Xóa một năm học
        /// </summary>
        /// <param name="SchoolYearId">Mã năm học</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // DELETE api/<SchoolYearsController>/5
        [HttpDelete("{SchoolYearId}")]
        public IActionResult Delete(int SchoolYearId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteSchoolYear";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SchoolYearId", SchoolYearId);
                    var res = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();

                    // 2. trả về dữ liệu
                    if (res > 0)
                    {
                        return StatusCode(201, res);
                    }
                    else
                    {
                        return StatusCode(200, res);
                    }
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ Admin để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }
    }
}
