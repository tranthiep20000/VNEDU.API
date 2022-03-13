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
    public class DecentralizationsController : ControllerBase
    {
        #region Feild
        IDecentralizationRepository _decentralizationRepository;
        IDecentralizationService _decentralizationService;
        #endregion

        #region Contructor
        public DecentralizationsController(IDecentralizationRepository decentralizationRepository, IDecentralizationService decentralizationService)
        {
            _decentralizationRepository = decentralizationRepository;
            _decentralizationService = decentralizationService;
        }
        #endregion

        #region Method
        // GET: api/<DecentralizationsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var decentralizations = _decentralizationRepository.Get();
                return StatusCode(200, decentralizations);
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

        // GET api/<DecentralizationsController>/5
        [HttpGet("{DecentralizationId}")]
        public IActionResult GetById(int DecentralizationId)
        {
            try
            {
                var decentralization = _decentralizationRepository.GetById(DecentralizationId);
                return StatusCode(200, decentralization);
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

        // POST api/<DecentralizationsController>/5
        [HttpPost]
        public IActionResult Post([FromBody] Decentralization decentralization)
        {
            try
            {
                var res = _decentralizationService.Insert(decentralization);
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

        // PUT api/<DecentralizationsController>/5
        [HttpPut("{DecentralizationId}")]
        public IActionResult Put(int DecentralizationId, [FromBody] Decentralization decentralization)
        {
            try
            {
                var res = _decentralizationService.Update(decentralization, DecentralizationId);
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

        // DELETE api/<DecentralizationsController>/5
        [HttpDelete("{DecentralizationId}")]
        public IActionResult Delete(int DecentralizationId)
        {
            try
            {
                var res = _decentralizationService.Delete(DecentralizationId);
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
