using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API khối
    /// CreatedBy: TTThiep(23/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả khối
        /// </summary>
        /// <returns>Danh sách khối</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET: api/<GradesController>
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
                    var sqlCommand = "Proc_GetGrades";
                    var grades = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, grades);
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
        /// Lấy thông tin một khối
        /// </summary>
        /// <param name="GradeId">Mã khối</param>
        /// <returns>Thông tin một khối</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET api/<GradesController>/5
        [HttpGet("{GradeId}")]
        public IActionResult Get(int GradeId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetGradeById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@GradeId", GradeId);
                    var grade = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, grade);
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
        /// Thêm một khối
        /// </summary>
        /// <param name="grade">Khối</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // POST api/<GradesController>
        [HttpPost]
        public IActionResult Post([FromBody] Grade grade)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên khối không được để trống
                    if (grade.GradeName == null || grade.GradeName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên khối không được phép để trống.",
                            userMsg = "Tên khối không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertGrade";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@GradeName", grade.GradeName);
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
        /// Sửa một khối
        /// </summary>
        /// <param name="GradeId">Mã khối</param>
        /// <param name="grade">Khối</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // PUT api/<GradesController>/5
        [HttpPut("{GradeId}")]
        public IActionResult Put(int GradeId, [FromBody] Grade grade)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên khối không được để trống
                    if (grade.GradeName == null || grade.GradeName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên khối không được phép để trống.",
                            userMsg = "Tên khối không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateGrade";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@GradeId", GradeId);
                    parameters.Add("@GradeName", grade.GradeName);
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
        /// Xóa một khối
        /// </summary>
        /// <param name="GradeId">Mã khối</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // DELETE api/<GradesController>/5
        [HttpDelete("{GradeId}")]
        public IActionResult Delete(int GradeId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteGrade";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@GradeId", GradeId);
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
