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
    public class Student_ClasssController : ControllerBase
    {
        #region Feild
        IStudent_ClassRepository _student_ClassRepository;
        IStudent_ClassService _student_ClassService;
        #endregion

        #region Contructor
        public Student_ClasssController(IStudent_ClassRepository student_ClassRepository, IStudent_ClassService student_ClassService)
        {
            _student_ClassRepository = student_ClassRepository;
            _student_ClassService = student_ClassService;
        }
        #endregion

        #region Method

        [HttpGet("GetByClassSemesterSchoolYear")]
        public IActionResult Get(int SchoolYearId, int SemesterId, int ClassId)
        {
            try
            {
                var student_classs = _student_ClassRepository.Get(SchoolYearId, SemesterId, ClassId);
                return StatusCode(200, student_classs);
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

        [HttpGet("GetPagingStudentClassByClassSemesterSchoolYear")]
        public IActionResult GetPagingStudentClassByClassSemesterSchoolYear(int SchoolYearId, int SemesterId, int ClassId, string? ValueFilter, int PageIndex, int PageSize)
        {
            try
            {
                var students = _student_ClassRepository.GetPagingStudentClassByClassSemesterSchoolYear(SchoolYearId, SemesterId, ClassId, ValueFilter, PageIndex, PageSize);
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


        [HttpGet("GetClassByStudentSchoolYearSemester")]
        public IActionResult GetClassByStudentSchoolYearSemester(int StudentId, int SchoolYearId, int SemesterId)
        {
            try
            {
                var student_classs = _student_ClassRepository.GetClassByStudentSchoolYearSemester(StudentId, SchoolYearId, SemesterId);
                return StatusCode(200, student_classs);
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
        public IActionResult Post([FromBody] Student_Class student_Class)
        {
            try
            {
                var res = _student_ClassService.Insert(student_Class);
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

        [HttpDelete("DeleteStudent_Class")]
        public IActionResult Delete(int StudentId, int ClassId, int SemesterId, int SchoolYearId)
        {
            try
            {
                var res = _student_ClassRepository.Delete(StudentId, ClassId, SemesterId, SchoolYearId);
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
