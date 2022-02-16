using Dapper;
using Microsoft.AspNetCore.Mvc;
using Student.Managerment.API.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controller
{
    /// <summary>
    /// Thông tin API của học sinh
    /// CreateBy: TTThiep(22/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";


        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        /// <summary>
        /// Lấy tất cả học sinh
        /// </summary>
        /// <returns>Danh sách học sinh</returns>
        /// CreateBy: TTThiep(26/01/2022)
        // GET: api/<StudentsController>
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
                    var sqlCommand = "Proc_GetStudents";
                    var students = connection.Query<object>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, students);
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
        /// Lấy thông tin của một học sinh theo khóa chính
        /// </summary>
        /// <param name="StudentId">Khóa chính</param>
        /// <returns>Thông tin của một học sinh</returns>
        /// CreatedBy: TTThiep(10/02/2022)
        [HttpGet("{StudentId}")]
        public IActionResult Get(int StudentId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetStudentById";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentId", StudentId);
                    var student = connection.QueryFirstOrDefault(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, student);
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
        /// Lấy thông tin của một học sinh theo số điện thoại và mật khẩu 
        /// </summary>
        /// <param name="PhoneNumber">Số điện thoại</param>
        /// <param name="PassWord">Mật khẩu</param>
        /// <returns>Thông tin của một học sinh</returns>
        /// CreateBy: TTThiep(22/01/2022)
        // GET api/<StudentsController>/5
        [HttpGet("getStudentByPhoneNumberAndPassword")]
        public IActionResult Get(string PhoneNumber, string PassWord)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetStudentByPhoneNumberAndPassword";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@PhoneNumber", PhoneNumber);
                    parameters.Add("@PassWord", PassWord);
                    var student = connection.QueryFirstOrDefault(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, student);
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
        /// Thêm một học sinh
        /// </summary>
        /// <param name="student">học sinh</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: TTThiep(11/02/2022)
        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.Student student)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // mã học sinh không được để trống
                    if (student.StudentCode == null || student.StudentCode == "")
                    {
                        var result = new
                        {
                            devMsg = "Mã học sinh không được phép để trống.",
                            userMsg = "Mã học sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // tên học sinh không được để trống
                    else if (student.FullName == null || student.FullName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên học sinh không được phép để trống.",
                            userMsg = "Tên học sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // giới tính không được để trống
                    else if (student.Gender == null)
                    {
                        var result = new
                        {
                            devMsg = "Giới tính không được phép để trống.",
                            userMsg = "Giới tính không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // ngày sinh không được để trống
                    else if (student.DateOfBirth == null)
                    {
                        var result = new
                        {
                            devMsg = "Ngày sinh không được phép để trống.",
                            userMsg = "Ngày sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Số điện thoại không được để trống
                    else if (student.PhoneNumber == null || student.PhoneNumber == "")
                    {
                        var result = new
                        {
                            devMsg = "Số điện thoại không được phép để trống.",
                            userMsg = "Số điện thoại không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Khối học không được để trống
                    else if (student.GradeId == null)
                    {
                        var result = new
                        {
                            devMsg = "Khối học không được phép để trống.",
                            userMsg = "Khối học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Lớp học không được để trống
                    else if (student.ClassId == null)
                    {
                        var result = new
                        {
                            devMsg = "Lớp học không được phép để trống.",
                            userMsg = "Lớp học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mã học sinh không được phép trùng
                    if (student.StudentCode != null || student.StudentCode != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_GetStudentByCode";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@StudentCode", student.StudentCode);
                        var studentCode = connection.QueryFirstOrDefault<object>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);
                        // đóng chuỗi kết nối
                        connection.Close();
                        if (studentCode != null)
                        {
                            var result = new
                            {
                                devMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống.",
                                userMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống.",
                            };
                            return StatusCode(400, result);
                        }
                    }
                    // số điện thoại không được phép trùng
                    if (student.PhoneNumber != null || student.PhoneNumber != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_GetStudentByPhoneNumber";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@PhoneNumber", student.PhoneNumber);
                        var phonenumber = connection.QueryFirstOrDefault<object>(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure);
                        // đóng chuỗi kết nối
                        connection.Close();
                        if (phonenumber != null)
                        {
                            var result = new
                            {
                                devMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống.",
                                userMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống.",
                            };
                            return StatusCode(400, result);
                        }
                    }
                   
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_InsertStudent";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentCode", student.StudentCode);
                    parameters.Add("@FullName", student.FullName);
                    parameters.Add("@Gender", student.Gender);
                    parameters.Add("@DateOfBirth", student.DateOfBirth);
                    parameters.Add("@PhoneNumber", student.PhoneNumber);
                    parameters.Add("@GradeId", student.GradeId);
                    parameters.Add("@ClassId", student.ClassId);
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
        /// Sửa thông tin một học sinh theo khóa chính
        /// </summary>
        /// <param name="StudentId">khóa chính</param>
        /// <param name="student">học sinh</param>
        /// <returns>sô bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(11/02/2022)
        [HttpPut("{StudentId}")]
        public IActionResult Put(int StudentId, Models.Student student)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // validate dữ liệu
                    // mã học sinh không được để trống
                    if (student.StudentCode == null || student.StudentCode == "")
                    {
                        var result = new
                        {
                            devMsg = "Mã học sinh không được phép để trống.",
                            userMsg = "Mã học sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // tên học sinh không được để trống
                    else if (student.FullName == null || student.FullName == "")
                    {
                        var result = new
                        {
                            devMsg = "Tên học sinh không được phép để trống.",
                            userMsg = "Tên học sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // giới tính không được để trống
                    else if (student.Gender == null)
                    {
                        var result = new
                        {
                            devMsg = "Giới tính không được phép để trống.",
                            userMsg = "Giới tính không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // ngày sinh không được để trống
                    else if (student.DateOfBirth == null)
                    {
                        var result = new
                        {
                            devMsg = "Ngày sinh không được phép để trống.",
                            userMsg = "Ngày sinh không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Số điện thoại không được để trống
                    else if (student.PhoneNumber == null || student.PhoneNumber == "")
                    {
                        var result = new
                        {
                            devMsg = "Số điện thoại không được phép để trống.",
                            userMsg = "Số điện thoại không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mật khẩu không được để trống
                    else if (student.PassWord == null || student.PassWord == "")
                    {
                        var result = new
                        {
                            devMsg = "Mật khẩu không được phép để trống.",
                            userMsg = "Mật khẩu không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Khối học không được để trống
                    else if (student.GradeId == null)
                    {
                        var result = new
                        {
                            devMsg = "Khối học không được phép để trống.",
                            userMsg = "Khối học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // Lớp học không được để trống
                    else if (student.ClassId == null)
                    {
                        var result = new
                        {
                            devMsg = "Lớp học không được phép để trống.",
                            userMsg = "Lớp học không được phép để trống."
                        };
                        return StatusCode(400, result);
                    }
                    // mã học sinh không được phép trùng
                    if (student.StudentCode != null || student.StudentCode != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_CheckStudentCode";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@StudentId", StudentId);
                        parameterscheck.Add("@StudentCode", student.StudentCode);
                        var studentcodecheck = connection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                        // đóng chuỗi kết nối
                        connection.Close();
                        foreach (var i in studentcodecheck)
                        {
                            if (i.Value == 0)
                            {
                                var result = new
                                {
                                    devMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống.",
                                    userMsg = $"Mã học sinh < {student.StudentCode} > đã tồn tại trong hệ thống.",
                                };
                                return StatusCode(400, result);
                            }
                        }
                    }
                    // số điện thoại không được phép trùng
                    if (student.PhoneNumber != null || student.PhoneNumber != "")
                    {
                        // thực hiện lấy dữ liệu trong database
                        // mở chuỗi kết nối
                        connection.Open();
                        var sqlCommandcheck = "Proc_CheckStudentPhonenumber";
                        DynamicParameters parameterscheck = new DynamicParameters();
                        parameterscheck.Add("@StudentId", StudentId);
                        parameterscheck.Add("@PhoneNumber", student.PhoneNumber);
                        var phonenumbercheck = connection.Query(sqlCommandcheck, param: parameterscheck, commandType: System.Data.CommandType.StoredProcedure).First();
                        // đóng chuỗi kết nối
                        connection.Close();
                        foreach (var i in phonenumbercheck)
                        {
                            if (i.Value == 0)
                            {
                                var result = new
                                {
                                    devMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống.",
                                    userMsg = $"Số điện thoại < {student.PhoneNumber} > đã tồn tại trong hệ thống.",
                                };
                                return StatusCode(400, result);
                            }
                        }
                    }

                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdateStudent";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentId", StudentId);
                    parameters.Add("@StudentCode", student.StudentCode);
                    parameters.Add("@FullName", student.FullName);
                    parameters.Add("@Gender", student.Gender);
                    parameters.Add("@DateOfBirth", student.DateOfBirth);
                    parameters.Add("@PhoneNumber", student.PhoneNumber);
                    parameters.Add("@PassWord", student.PassWord);
                    parameters.Add("@GradeId", student.GradeId);
                    parameters.Add("@ClassId", student.ClassId);
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
        /// Sửa mật khẩu của một học sinh
        /// </summary>
        /// <param name="StudentId">Khóa chính</param>
        /// <param name="PassWord">Mật khẩu</param>
        /// <returns>Số bản ghi sửa thành công</returns>
        /// CreatedBy: TTThiep(10/02/2022)
        // PUT api/<StudentsController>/5
        [HttpPut("UpdatePassword")]
        public IActionResult Put(int StudentId, string PassWord)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_UpdatePaswordStudent";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentId", StudentId);
                    parameters.Add("@PassWord", PassWord);
                    var res = connection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, res);
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
        /// Xóa thông tin của một học sinh
        /// </summary>
        /// <param name="StudentId">Khóa chính</param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: TTThiep(10/02/2022)
        // DELETE api/<StudentsController>/5
        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int StudentId)
        {

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_DeleteStudent";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentId", StudentId);
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
