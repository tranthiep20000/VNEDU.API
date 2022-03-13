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
    public class UsedsController : ControllerBase
    {
        #region Feild
        IUserRepository _userRepository;
        IUserService _userService;
        #endregion

        #region Contructor
        public UsedsController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        #endregion

        #region Method
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userRepository.Get();
                return StatusCode(200, users);
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

        [HttpGet("{UserId}")]
        public IActionResult GetById(int UserId)
        {
            try
            {
                var user = _userRepository.GetById(UserId);
                return StatusCode(200, user);
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

        [HttpGet("GetPagingUser")]
        public IActionResult GetPagingUser(string? ValueFilter, int PageIndex, int PageSize)
        {
            try
            {
                var students = _userRepository.GetPagingUser(ValueFilter, PageIndex, PageSize);
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

        [HttpGet("GetByPhoneNumberPassword")]
        public IActionResult GetByPhoneNumberPassword(string PhoneNumber, string Password)
        {
            try
            {
                var user = _userRepository.GetUserByPhoneNumberPassword(PhoneNumber, Password);
                return StatusCode(200, user);
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
        public IActionResult Post([FromBody] Used used)
        {
            try
            {
                var res = _userService.Insert(used);
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

        [HttpPut("{UserId}")]
        public IActionResult Put(int UserId, [FromBody] Used used)
        {
            try
            {
                var res = _userService.Update(used, UserId);
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

        [HttpPut("UpdatePassword")]
        public IActionResult Put(int UserId, string Password)
        {
            try
            {
                var res = _userService.UpdatePassword(UserId, Password);
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

        [HttpDelete("{UserId}")]
        public IActionResult Delete(int UserId)
        {
            try
            {
                var res = _userService.Delete(UserId);
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
