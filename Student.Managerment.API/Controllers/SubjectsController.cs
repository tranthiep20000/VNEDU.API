using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API môn học
    /// CreatedBy: TTThiep(22/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả môn học
        /// </summary>
        /// <returns>Danh sách môn học</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET: api/<SubjectsController>
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
                    var sqlCommand = "Proc_GetSubjects";
                    var subjects = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, subjects);
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
        /// Lấy thông tin một môn học
        /// </summary>
        /// <param name="SubjectId">Mã môn học</param>
        /// <returns>Thông tin một môn học</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // GET api/<SubjectsController>/5
        [HttpGet("{SubjectId}")]
        public IActionResult Get(int SubjectId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetSubjectById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SubjectId", SubjectId);
                    var subject = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, subject);
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
        /// Thêm một môn học
        /// </summary>
        /// <param name="subject">Môn học</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // POST api/<SubjectsController>
        [HttpPost]
        public IActionResult Post([FromBody] Subject subject)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên môn học không được để trống
                    if (subject.SubjectName == null || subject.SubjectName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên môn học không được phép để trống.",
                            userMsg = "Tên môn học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertSubject";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SubjectName", subject.SubjectName);
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
        /// Sửa một môn học
        /// </summary>
        /// <param name="SubjectId">Mã môn học</param>
        /// <param name="subject">Môn học</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // PUT api/<SubjectsController>/5
        [HttpPut("{SubjectId}")]
        public IActionResult Put(int SubjectId, [FromBody] Subject subject)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên môn học không được để trống
                    if (subject.SubjectName == null || subject.SubjectName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên môn học không được phép để trống.",
                            userMsg = "Tên môn học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateSubject";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SubjectId", SubjectId);
                    parameters.Add("@SubjectName", subject.SubjectName);
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
        /// Xóa một môn học
        /// </summary>
        /// <param name="SubjectId">Mã môn học</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(22/01/2022)
        // DELETE api/<SubjectsController>/5
        [HttpDelete("{SubjectId}")]
        public IActionResult Delete(int SubjectId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteSubject";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SubjectId", SubjectId);
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
