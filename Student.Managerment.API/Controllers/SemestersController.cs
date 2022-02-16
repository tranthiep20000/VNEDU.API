using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API học kì
    /// CreateBy: TTThiep(22/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SemestersController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả học kì
        /// </summary>
        /// <returns>Danh sách học kì</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET: api/<SemestersController>
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
                    var sqlCommand = "Proc_GetSemesters";
                    var semesters = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, semesters);
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
        /// Lấy một học kì
        /// </summary>
        /// <param name="SemesterId">Mã học kì</param>
        /// <returns>Thông tin một học kì</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET api/<SemestersController>/5
        [HttpGet("{SemesterId}")]
        public IActionResult Get(int SemesterId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetSemesterById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SemesterId", SemesterId);
                    var semester = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, semester);
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
        /// Thêm một học kì
        /// </summary>
        /// <param name="semester">học kì</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreateBy: TTThiep(22/01/2022)
        // POST api/<SemestersController>
        [HttpPost]
        public IActionResult Post([FromBody] Semester semester)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên học kì không được để trống
                    if (semester.SemesterName == null || semester.SemesterName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên học kì không được phép để trống.",
                            userMsg = "Tên học kì không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertSemester";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SemesterName", semester.SemesterName);
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
        /// Sửa một học kì
        /// </summary>
        /// <param name="SemesterId">Mã học kì</param>
        /// <param name="semester">Học kì</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // PUT api/<SemestersController>/5
        [HttpPut("{SemesterId}")]
        public IActionResult Put(int SemesterId, [FromBody] Semester semester)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên học kì không được để trống
                    if (semester.SemesterName == null || semester.SemesterName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên học kì không được phép để trống.",
                            userMsg = "Tên học kì không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateSemester";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SemesterId", SemesterId);
                    parameters.Add("@SemesterName", semester.SemesterName);
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
        /// Xóa một học kì
        /// </summary>
        /// <param name="SemesterId">Mã học kì</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreateBy: TTThiep(22/01/2022)
        // DELETE api/<SemestersController>/5
        [HttpDelete("{SemesterId}")]
        public IActionResult Delete(int SemesterId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteSemester";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SemesterId", SemesterId);
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
