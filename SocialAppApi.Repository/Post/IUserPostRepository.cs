using Microsoft.EntityFrameworkCore;
using SocialAppApi.Database.SocialAppContext;
using SocialAppApi.Entities.Common;
using SocialAppApi.Entities.Entities;
using SocialAppApi.Entities.StaticClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Repository.Post
{
    public interface IUserPostRepository
    {
        Task<UserPost> SaveUserPost(UserPost userPost);
        Task<List<UserPost>> GetUserPost(Expression<Func<UserPost, bool>> expression);
        Task<ResponseMessage> GetUserPostWithPaging(Expression<Func<UserPost, bool>> expression, int currentPage, int itemPerPage);
        Task<UserPost> GetUserPostById(int postId);
        Task<UserPost> UpdateUserPost(UserPost userPost);
        Task<UserPost> DeleteUserPost(int postId);
        Task<UserPost> UpdateUserPostStatus(UserPost userPost);
    }

    public class UserPostRepository : IUserPostRepository
    {
        private readonly SocialAppContext _socialAppContext;
        public UserPostRepository(SocialAppContext socialAppContext)
        {
            _socialAppContext = socialAppContext;
        }
        public async Task<UserPost> DeleteUserPost(int postId)
        {
            try
            {
                var response = await _socialAppContext.UserPosts.FindAsync(postId);
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<UserPost>> GetUserPost(Expression<Func<UserPost, bool>> expression)
        {
            try
            {
                var lstUserPost = await _socialAppContext.Set<UserPost>().Where(expression).Take(10).OrderByDescending(x=> x.UserPostId).ToListAsync();
                return lstUserPost;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserPost> GetUserPostById(int postId)
        {
            try
            {
                var response = await _socialAppContext.Set<UserPost>().Where(x => x.UserPostId == postId).AsNoTracking().FirstOrDefaultAsync();
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseMessage> GetUserPostWithPaging(Expression<Func<UserPost, bool>> expression, int currentPage, int itemPerPage)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                currentPage = currentPage <= 0 ? AppConstant.InitialPage : currentPage;
                itemPerPage = itemPerPage <= 0 ? AppConstant.ItemPerPage : itemPerPage;

                int skip = (currentPage - 1) * itemPerPage;

                responseMessage.ResponseObj = await _socialAppContext.Set<UserPost>().Where(expression).OrderByDescending(x => x.UserPostId).Skip(skip).Take(itemPerPage).ToListAsync();

                //count TotalItems by the search criteria
                responseMessage.Pagination.TotalItems = await _socialAppContext.Set<UserPost>().Where(expression).CountAsync();
                responseMessage.Pagination.TotalPages = (int)Math.Ceiling(responseMessage.Pagination.TotalItems / (double)itemPerPage);

                return responseMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserPost> SaveUserPost(UserPost userPost)
        {
            try
            {
                if (userPost.UserPostId > 0)
                {
                    _socialAppContext.UserPosts.Update(userPost);
                    await _socialAppContext.SaveChangesAsync();
                }
                else {
                    await _socialAppContext.UserPosts.AddAsync(userPost);
                    await _socialAppContext.SaveChangesAsync();
                }
                return userPost;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<UserPost> UpdateUserPost(UserPost userPost)
        {
            throw new NotImplementedException();
        }

        public Task<UserPost> UpdateUserPostStatus(UserPost userPost)
        {
            throw new NotImplementedException();
        }
    }
}
