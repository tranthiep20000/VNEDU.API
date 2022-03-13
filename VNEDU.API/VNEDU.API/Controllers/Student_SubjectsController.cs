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
    public class Student_SubjectsController : ControllerBase
    {
        #region Feild
        IStudent_SubjectRepository _student_SubjectRepository;
        IStudent_SubjectService _student_SubjectService;
        #endregion

        #region Contructor
        public Student_SubjectsController(IStudent_SubjectRepository student_SubjectRepository, IStudent_SubjectService student_SubjectService)
        {
            _student_SubjectRepository = student_SubjectRepository;
            _student_SubjectService = student_SubjectService;
        }
        #endregion

        #region Method

        [HttpGet("GetBySubjectSemesterSchoolYearClass")]
        public IActionResult Get(int StudentId, int SemesterId, int SchoolYearId)
        {
            try
            {
                var student_classs = _student_SubjectRepository.Get(StudentId, SemesterId, SchoolYearId);
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

        [HttpGet("GetScoreByStudent")]
        public IActionResult GetScoreByStudent(int SchoolYearId, int SemesterId, int StudentId, int ClassId)
        {
            try
            {
                var student_classs = _student_SubjectRepository.GetScoreByStudent(SchoolYearId, SemesterId, StudentId, ClassId);
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

        [HttpGet("GetScoreBySubject")]
        public IActionResult GetScoreBySubject(int SchoolYearId, int SemesterId, int SubjectId, int ClassId)
        {
            try
            {
                var student_classs = _student_SubjectRepository.GetScoreBySubject(SchoolYearId, SemesterId, SubjectId, ClassId);
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

        [HttpGet("GetPagingStudentClassBySchoolYearSemesterSubjectClass")]
        public IActionResult GetPagingStudentClassBySchoolYearSemesterSubjectClass(int SchoolYearId, int SemesterId, int SubjectId, int ClassId, string? ValueFilter, int PageIndex, int PageSize)
        {
            try
            {
                var students = _student_SubjectRepository.GetPagingStudentSubjectBySchoolYearSemesterSubjectClass(SchoolYearId, SemesterId, SubjectId, ClassId, ValueFilter, PageIndex, PageSize);
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
        public IActionResult Post([FromBody] Student_Subject student_Subject)
        {
            try
            {
                var res = _student_SubjectService.Insert(student_Subject);
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

        [HttpDelete("DeleteStudent_Subject")]
        public IActionResult Delete(int StudentId, int SubjectId, int SemesterId, int SchoolYearId)
        {
            try
            {
                var res = _student_SubjectService.Delete(StudentId, SubjectId, SemesterId, SchoolYearId);
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
