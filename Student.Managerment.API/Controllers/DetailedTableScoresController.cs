using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.Managerment.API.Controllers
{
    /// <summary>
    /// Thông tin API bảng điểm 
    /// CreatedBy: TTThiep(24/01/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DetailedTableScoresController : ControllerBase
    {
        // 1. khai báo thông tin kết nối
        /*protected string connectionString = "Data Source=.;Initial Catalog=STUDENT_MANAGERMENT;Integrated Security=True";*/
        protected string connectionString = "workstation id=vnedustudent.mssql.somee.com;packet size=4096;user id=TranThiep_SQLLogin_1;pwd=ui2ozk1t8w;data source=vnedustudent.mssql.somee.com;persist security info=False;initial catalog=vnedustudent";

        // 2. khởi tạo kết nối tới database
        protected SqlConnection connection;

        // GET: api/<DetailedTableScoresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DetailedTableScoresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("getScoreInformation")]
        public IActionResult Get(int StudentId, int SchoolYearId, int SemesterId)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // 1. thực hiện lấy dữ liệu trong database
                    // mở chuỗi kết nối
                    connection.Open();
                    var sqlCommand = "Proc_GetScore";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StudentId", StudentId);
                    parameters.Add("@SchoolYearId", SchoolYearId);
                    parameters.Add("@SemesterId", SemesterId);
                    var score = connection.Query<object>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    // đóng chuỗi kết nối
                    connection.Close();
                    // 2. trả về dữ liệu
                    return StatusCode(200, score);
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

        // POST api/<DetailedTableScoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DetailedTableScoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetailedTableScoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
