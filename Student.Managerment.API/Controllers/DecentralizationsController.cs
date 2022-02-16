using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API Quyền
    /// CreatedBy: TTThiep(23/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DecentralizationsController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        // GET: api/<DecentralizationsController>
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
                    var sqlCommand = "Proc_GetDecentralizations";
                    var decentralizations = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, decentralizations);
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

        // GET api/<DecentralizationsController>/5
        [HttpGet("{DecentralizationId}")]
        public IActionResult Get(int DecentralizationId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetDecentralizationById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DecentralizationId", DecentralizationId);
                    var decentralization = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, decentralization);
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

        // POST api/<DecentralizationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Decentralization decentralization)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên quyền không được để trống
                    if (decentralization.DecentralizationName == null || decentralization.DecentralizationName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên quyền không được phép để trống.",
                            userMsg = "Tên quyền không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mô tả quyền không được để trống
                    else if (decentralization.DescriptionName == null || decentralization.DescriptionName == "")
                    {
                        var result = new
                        {
                            devMsg = "Mô tả quyền không được phép để trống.",
                            userMsg = "Mô tả quyền không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertDecentralization";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DecentralizationName", decentralization.DecentralizationName);
                    parameters.Add("@DescriptionName", decentralization.DescriptionName);
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

        // PUT api/<DecentralizationsController>/5
        [HttpPut("{DecentralizationId}")]
        public IActionResult Put(int DecentralizationId, [FromBody] Decentralization decentralization)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // Tên quyền không được để trống
                    if (decentralization.DecentralizationName == null || decentralization.DecentralizationName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên quyền không được phép để trống.",
                            userMsg = "Tên quyền không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mô tả quyền không được để trống
                    else if (decentralization.DescriptionName == null || decentralization.DescriptionName == "")
                    {
                        var result = new
                        {
                            devMsg = "Mô tả quyền không được phép để trống.",
                            userMsg = "Mô tả quyền không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateDecentralization";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DecentralizationId", DecentralizationId);
                    parameters.Add("@DecentralizationName", decentralization.DecentralizationName);
                    parameters.Add("@DescriptionName", decentralization.DescriptionName);
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

        // DELETE api/<DecentralizationsController>/5
        [HttpDelete("{DecentralizationId}")]
        public IActionResult Delete(int DecentralizationId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteDecentralization";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@DecentralizationId", DecentralizationId);
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
