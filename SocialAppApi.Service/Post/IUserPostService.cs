using SocialAppApi.Entities.Common;
using SocialAppApi.Entities.ConvertJson;
using SocialAppApi.Entities.Entities;
using SocialAppApi.Entities.Enums;
using SocialAppApi.Entities.VM.Filter;
using SocialAppApi.Repository.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Service.Post
{
    public interface IUserPostService
    {
        Task<ResponseMessage> SaveUserPost(RequestMessage requestMessage);
        Task<ResponseMessage> GetUserPost(RequestMessage requestMessage);
        Task<ResponseMessage> GetUserPostWithPaging(RequestMessage requestMessage);
        Task<ResponseMessage> GetUserPostById(RequestMessage requestMessage);
        Task<ResponseMessage> UpdateUserPost(RequestMessage requestMessage);
        Task<ResponseMessage> DeleteUserPost(RequestMessage requestMessage);
        Task<ResponseMessage> UpdateUserPostStatus(RequestMessage requestMessage);
    }

    public class UserPostService : IUserPostService
    {
        private readonly IUserPostRepository _userPostRepository;

        public UserPostService(IUserPostRepository userPostRepository)
        {
            _userPostRepository = userPostRepository;
        }
        public async Task<ResponseMessage> DeleteUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                int userPostId = 0;

                UserPostFilterByID userPostFilterByID = SiteUtils.ConvertJsonToObject<UserPostFilterByID>(requestMessage.RequestObj);
                if (userPostFilterByID != null)
                {
                    userPostId = userPostFilterByID.UserPostId;
                }

                responseMessage.ResponseObj = await _userPostRepository.DeleteUserPost(userPostId);
                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.Message = "Deleted successfully";
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {
                throw ex;
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.InternalServerError;
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> GetUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                UserPostFilter userPostFilter = SiteUtils.ConvertJsonToObject<UserPostFilter>(requestMessage.RequestObj);

                responseMessage.ResponseObj = await _userPostRepository.GetUserPost(x => (string.IsNullOrEmpty(userPostFilter.Message) ? true : (x.Message.Contains(userPostFilter.Message))));

                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.Message = "Data Fetched successfully";
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {
                throw ex;
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.InternalServerError;
                responseMessage.Message = "Data Fetched failed";
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> GetUserPostById(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                int userPostId = 0;

                UserPostFilterByID userPostFilterByID = SiteUtils.ConvertJsonToObject<UserPostFilterByID>(requestMessage.RequestObj);
                if (userPostFilterByID != null)
                {
                    userPostId = userPostFilterByID.UserPostId;
                }

                responseMessage.ResponseObj = await _userPostRepository.GetUserPostById(userPostId);
                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.Message = "Data Fetched successfully";
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {
                throw ex;
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.InternalServerError;
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> GetUserPostWithPaging(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                UserPostFilter userPostFilter = SiteUtils.ConvertJsonToObject<UserPostFilter>(requestMessage.RequestObj);

                responseMessage = await _userPostRepository.GetUserPostWithPaging(x => (string.IsNullOrEmpty(userPostFilter.Message) ? true :
                (x.Message.Contains(userPostFilter.Message))), requestMessage.CurrentPage, requestMessage.ItemPerPage);

                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.Message = "Data Fetched successfully";
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {
                throw ex;
                responseMessage.ResponseObj = null;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.InternalServerError;
                responseMessage.Message = "Data Fetched failed successfully";
                responseMessage.IsUserMessage = false;
            }

            return responseMessage;
        }

        public async Task<ResponseMessage> SaveUserPost(RequestMessage requestMessage)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                UserPost userPost = SiteUtils.ConvertJsonToObject<UserPost>(requestMessage.RequestObj);
                if (userPost != null)
                {
                    userPost = await _userPostRepository.SaveUserPost(userPost);

                    responseMessage.Message = "User Post Successfully";
                }
                else
                {
                    responseMessage.Message = "User Post not done Successfully";
                }

                responseMessage.ResponseObj = userPost;
                responseMessage.ResponseCode = (int)Enums.ResponseCode.Success;
                responseMessage.IsUserMessage = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return responseMessage;
        }

        public Task<ResponseMessage> UpdateUserPost(RequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> UpdateUserPostStatus(RequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }
    }
}
