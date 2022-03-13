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
    public class SchoolYearsController : ControllerBase
    {
        #region Feild
        ISchoolYearRepository _schoolYearRepository;
        ISchoolYearService _schoolYearService;
        #endregion

        #region Contructor
        public SchoolYearsController(ISchoolYearRepository schoolYearRepository, ISchoolYearService schoolYearService)
        {
            _schoolYearRepository = schoolYearRepository;
            _schoolYearService = schoolYearService;
        }
        #endregion

        #region Method
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var schoolYears = _schoolYearRepository.Get();
                return StatusCode(200, schoolYears);
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

        [HttpGet("{SchoolYearId}")]
        public IActionResult GetById(int SchoolYearId)
        {
            try
            {
                var subject = _schoolYearRepository.GetById(SchoolYearId);
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
        public IActionResult Post([FromBody] SchoolYear schoolYear)
        {
            try
            {
                var res = _schoolYearService.Insert(schoolYear);
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

        [HttpPut("{SchoolYearId}")]
        public IActionResult Put(int SchoolYearId, [FromBody] SchoolYear schoolYear)
        {
            try
            {
                var res = _schoolYearService.Update(schoolYear, SchoolYearId);
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

        [HttpDelete("{SchoolYearId}")]
        public IActionResult Delete(int SchoolYearId)
        {
            try
            {
                var res = _schoolYearService.Delete(SchoolYearId);
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
