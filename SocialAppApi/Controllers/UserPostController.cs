using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialAppApi.Entities.Common;
using SocialAppApi.Service.Post;

namespace SocialAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : ControllerBase
    {
        private readonly IUserPostService _userPostService;

        public UserPostController(IUserPostService userPostService)
        {
            _userPostService = userPostService;

        }

        [HttpPost]
        [Route("SaveUserPost")]
        public async Task<ResponseMessage> SaveUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                responseMessage = await _userPostService.SaveUserPost(requestMessage);
                return responseMessage;
            }
            catch (Exception ex)
            {
                responseMessage.IsUserMessage = false;
                responseMessage.Message = ex.Message;
            }
            return responseMessage;
        }

    
        [HttpPost]
        [Route("DeleteUserPost")]
        public async Task<ResponseMessage> DeleteUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                responseMessage = await _userPostService.DeleteUserPost(requestMessage);
                return responseMessage;
            }
            catch (Exception ex)
            {
                responseMessage.IsUserMessage = false;
                responseMessage.Message = ex.Message;
            }
            return responseMessage;
        }

        
        [HttpPost]
        [Route("GetUserPostById")]
        public async Task<ResponseMessage> GetUserPostById(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                responseMessage = await _userPostService.GetUserPostById(requestMessage);
                return responseMessage;
            }
            catch (Exception ex)
            {
                responseMessage.IsUserMessage = false;
                responseMessage.Message = ex.Message;
            }
            return responseMessage;
        }

        
        [HttpPost]
        [Route("GetUserPost")]
        public async Task<ResponseMessage> GetUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                responseMessage = await _userPostService.GetUserPost(requestMessage);
                return responseMessage;
            }
            catch (Exception ex)
            {
                responseMessage.IsUserMessage = false;
                responseMessage.Message = ex.Message;
            }
            return responseMessage;
        }


        [HttpPost]
        [Route("GetUserPostWithPaging")]
        public async Task<ResponseMessage> GetUserPostWithPaging(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                responseMessage = await _userPostService.GetUserPostWithPaging(requestMessage);
                return responseMessage;
            }
            catch (Exception ex)
            {
                responseMessage.IsUserMessage = false;
                responseMessage.Message = ex.Message;
            }
            return responseMessage;
        }
    }
}
