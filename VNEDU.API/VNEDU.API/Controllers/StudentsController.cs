using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.CORE.Exceptions;
using VNEDU.CORE.Entities;
using VNEDU.CORE.Interfaces.Repositorys;
using VNEDU.CORE.Interfaces.Services;

namespace VNEDU.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Feild
        IStudentRepository _studentRepository;
        IStudentService _studentService;
        #endregion

        #region Contructor
        public StudentsController(IStudentRepository studentRepository, IStudentService studentService)
        {
            _studentRepository = studentRepository;
            _studentService = studentService;
        }
        #endregion

        #region Method
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var students = _studentRepository.Get();
                return StatusCode(200, students);
            }

            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpGet("{StudentId}")]
        public IActionResult GetById(int StudentId)
        {
            try
            {
                var student = _studentRepository.GetById(StudentId);
                return StatusCode(200, student);
            }

            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpGet("GetInformationByPhonenumber")]
        public IActionResult GetInformationByPhonenumber(string PhoneNumber)
        {
            try
            {
                var student = _studentRepository.GetInformationStudentByPhoneNumber(PhoneNumber);
                return StatusCode(200, student);
            }

            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpGet("GetPagingStudent")]
        public IActionResult GetPagingStudent(string? ValueFilter, int PageIndex, int PageSize)
        {
            try
            {
                var students = _studentRepository.GetPagingStudent(ValueFilter, PageIndex, PageSize);
                return StatusCode(200, students);
            }

            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                var res = _studentService.Insert(student);
                if (res > 0)
                {
                    return StatusCode(201, res);
                }
                else
                {
                    return StatusCode(200, res);
                }

            }
            catch (ValidateException ex)
            {
                return StatusCode(400, ex.Data);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpPut("{StudentId}")]
        public IActionResult Put(int StudentId, [FromBody] Student student)
        {
            try
            {
                var res = _studentService.Update(student, StudentId);
                if (res > 0)
                {
                    return StatusCode(201, res);
                }
                else
                {
                    return StatusCode(200, res);
                }
            }
            catch (ValidateException ex)
            {
                return StatusCode(400, ex.Data);
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }

        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int StudentId)
        {
            try
            {
                var res = _studentService.Delete(StudentId);
                if (res > 0)
                {
                    return StatusCode(201, res);
                }
                else
                {
                    return StatusCode(200, res);
                }
            }
            catch (Exception ex)
            {
                var result = new
                {
                    devMsg = "Có lỗi anh dev ơi!",
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!",
                    error = ex.Message
                };
                return StatusCode(500, result);
            }
        }
        #endregion
    }
}
