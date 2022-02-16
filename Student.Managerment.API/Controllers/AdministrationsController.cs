using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API admin
    /// CreatedBy: TTThiep(23/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministrationsController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// lấy tất cả người dùng
        /// </summary>
        /// <returns>Danh sách người dùng</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET: api/<AdministrationsController>
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
                    var sqlCommand = "Proc_GetAdministrations";
                    var administrations = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, administrations);
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
        /// Lấy thông tin một người dùng
        /// </summary>
        /// <param name="AdministrationId">Mã người dùng</param>
        /// <returns>Thông tin một người dùng</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // GET api/<AdministrationsController>/5
        [HttpGet("{AdministrationId}")]
        public IActionResult Get(int AdministrationId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetAdministrationById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@AdministrationId", AdministrationId);
                    var administration = connection.QueryFirstOrDefault<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, administration);
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
        /// Thêm một người dùng
        /// </summary>
        /// <param name="administration">Người dùng</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // POST api/<AdministrationsController>
        [HttpPost]
        public IActionResult Post([FromBody] Administration administration)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // mã người dùng không được để trống
                    if (administration.AdministrationCode == null || administration.AdministrationCode == "")
                    {
                        var result = new
                        {
                            devMsg = "Mã người dùng không được phép để trống.",
                            userMsg = "Mã người dùng không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mã người dùng không được phép trùng
                    else if (administration.AdministrationCode != null || administration.AdministrationCode != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_GetAdministrationByCode";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@AdministrationCode", administration.AdministrationCode);
                        var administrationCode = connection.QueryFirstOrDefault<object>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);
                        // đóng chuỗi kết nối
                        connection.Close();
                        if (administrationCode != null)
                        {
                            var result = new
                            {
                                devMsg = $"Mã người dùng < {administration.AdministrationCode} > đã tồn tại trong hệ thống.",
                                userMsg = $"Mã người dùng < {administration.AdministrationCode} > đã tồn tại trong hệ thống.",
                            };
                            return StatusCode(400, result);
                        }
                    }
                   
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertAdministration";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@AdministrationCode", administration.AdministrationCode);
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
        /// Sửa một người dùng
        /// </summary>
        /// <param name="AdministrationId">Mã người dùng</param>
        /// <param name="administration">Người dùng</param>
        /// <returns>Số bản ghi sủa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // PUT api/<AdministrationsController>/5
        [HttpPut("{AdministrationId}")]
        public IActionResult Put(int AdministrationId, [FromBody] Administration administration)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // mã người dùng không được để trống
                    if (administration.AdministrationCode == null || administration.AdministrationCode == "")
                    {
                        var result = new
                        {
                            devMsg = "Mã người dùng không được phép để trống.",
                            userMsg = "Mã người dùng không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mật khẩu không được để trống
                    else if (administration.PassWord == null || administration.PassWord == "")
                    {
                        var result = new
                        {
                            devMsg = "Mật khẩu không được phép để trống.",
                            userMsg = "Mật Khẩu không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mã người dùng không được phép trùng
                    else if (administration.AdministrationCode != null || administration.AdministrationCode != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_CheckAdministrationCode";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@AdministrationId", AdministrationId);
                        parameterscheck.Add("@AdministrationCode", administration.AdministrationCode);
                        var administrationcheck = connection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                        // đóng chuỗi kết nối
                        connection.Close();
                        foreach (var i in administrationcheck)
                        {
                            if (i.Value == 0)
                            {
                                var result = new
                                {
                                    devMsg = $"Mã người dùng < {administration.AdministrationCode} > đã tồn tại trong hệ thống.",
                                    userMsg = $"Mã người dùng < {administration.AdministrationCode} > đã tồn tại trong hệ thống.",
                                };
                                return StatusCode(400, result);
                            }
                        }
                    }
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateAdministration";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@AdministrationId", AdministrationId);
                    parameters.Add("@AdministrationCode", administration.AdministrationCode);
                    parameters.Add("@PassWord", administration.PassWord);
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
        /// Xóa một người dùng
        /// </summary>
        /// <param name="AdministrationId">Mã người dùng</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(23/01/2022)
        // DELETE api/<AdministrationsController>/5
        [HttpDelete("{AdministrationId}")]
        public IActionResult Delete(int AdministrationId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteAdministration";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@AdministrationId", AdministrationId);
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
