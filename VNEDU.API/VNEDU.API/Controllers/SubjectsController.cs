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
    public class SubjectsController : ControllerBase
    {
        #region Feild
        ISubjectRepository _subjectRepository;
        ISubjectService _subjectService;
        #endregion

        #region Contructor
        public SubjectsController(ISubjectRepository subjectRepository, ISubjectService subjectService)
        {
            _subjectRepository = subjectRepository;
            _subjectService = subjectService;
        }
        #endregion

        #region Method
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var subjects = _subjectRepository.Get();
                return StatusCode(200, subjects);
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

        [HttpGet("{SubjectId}")]
        public IActionResult GetById(int SubjectId)
        {
            try
            {
                var subject = _subjectRepository.GetById(SubjectId);
                return StatusCode(200, subject);
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
        public IActionResult Post([FromBody] Subject subject)
        {
            try
            {
                var res = _subjectService.Insert(subject);
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

        [HttpPut("{SubjectId}")]
        public IActionResult Put(int SubjectId, [FromBody] Subject subject)
        {
            try
            {
                var res = _subjectService.Update(subject, SubjectId);
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

        [HttpDelete("{SubjectId}")]
        public IActionResult Delete(int SubjectId)
        {
            try
            {
                var res = _subjectService.Delete(SubjectId);
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
