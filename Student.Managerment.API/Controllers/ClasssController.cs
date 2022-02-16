using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API lớp học
    /// CreatedBy: TTThiep(23/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClasssController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /* protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";


        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả lớp học
        /// </summary>
        /// <returns>Danh sách lớp học</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET: api/<ClasssController>
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
                    var sqlCommand = "Proc_GetClasss";
                    var classs = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, classs);
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
        /// Lấy thông tin một lớp học
        /// </summary>
        /// <param name="ClassId">Mã lớp học</param>
        /// <returns>Thông tin một lớp học</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET api/<ClasssController>/5
        [HttpGet("{ClassId}")]
        public IActionResult Get(int ClassId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetClassById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ClassId", ClassId);
                    var classs = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, classs);
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
        /// lấy tất cả lớp học theo khối
        /// </summary>
        /// <param name="GradeId">Mã khối</param>
        /// <returns>Danh sách lớp học theo khối</returns>
        /// CreatedBy: TTThiep(10/02/2022)
        [HttpGet("GetByGrade/{GradeId}")]
        public IActionResult GetByGrade(int GradeId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetClassByGradeId";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@GradeId", GradeId);
                    var classs = connection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, classs);
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
        /// Thêm một lớp học
        /// </summary>
        /// <param name="classs">Lớp học</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // POST api/<ClasssController>
        [HttpPost]
        public IActionResult Post([FromBody] Class classs)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên lớp học không được để trống
                    if (classs.ClassName == null || classs.ClassName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên lớp học không được phép để trống.",
                            userMsg = "Tên lớp học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Tên khối không được để trống
                    else if (classs.GradeId == null)
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
                    var sqlCommand = "Proc_InsertClass";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ClassName", classs.ClassName);
                    parameters.Add("@GradeId", classs.GradeId);
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
        /// Sửa một lớp học
        /// </summary>
        /// <param name="ClassId">Mã lớp học</param>
        /// <param name="classs">Lớp học</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // PUT api/<ClasssController>/5
        [HttpPut("{ClassId}")]
        public IActionResult Put(int ClassId, [FromBody] Class classs)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên lớp học không được để trống
                    if (classs.ClassName == null || classs.ClassName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên lớp học không được phép để trống.",
                            userMsg = "Tên lớp học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Tên khối không được để trống
                    else if (classs.GradeId == null)
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
                    var sqlCommand = "Proc_UpdateClass";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ClassId", ClassId);
                    parameters.Add("@ClassName", classs.ClassName);
                    parameters.Add("@GradeId", classs.GradeId);
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
        /// Xóa một lớp học
        /// </summary>
        /// <param name="ClassId">Mã lớp học</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // DELETE api/<ClasssController>/5
        [HttpDelete("{ClassId}")]
        public IActionResult Delete(int ClassId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteClass";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ClassId", ClassId);
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
