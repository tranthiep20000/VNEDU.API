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
    public class DetailedTableScoresController : ControllerBase
    {
        #region Feild
        IDetailedTableScoreRepository _detailedTableScoreRepository;
        IDetailedTableScoreService _detailedTableScoreService;
        #endregion

        #region Contructor
        public DetailedTableScoresController(IDetailedTableScoreRepository detailedTableScoreRepository, IDetailedTableScoreService detailedTableScoreService)
        {
            _detailedTableScoreRepository = detailedTableScoreRepository;
            _detailedTableScoreService = detailedTableScoreService;
        }
        #endregion

        #region Method
        [HttpGet("{DetailedTableScoreId}")]
        public IActionResult GetById(int DetailedTableScoreId)
        {
            try
            {
                var Class = _detailedTableScoreRepository.GetById(DetailedTableScoreId);
                return StatusCode(200, Class);
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

        [HttpPut("{DetailedTableScoreId}")]
        public IActionResult Put(int DetailedTableScoreId, [FromBody] DetailedTableScore detailedTableScore)
        {
            try
            {
                var res = _detailedTableScoreService.Update(detailedTableScore, DetailedTableScoreId);
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
        #endregion
    }
}
