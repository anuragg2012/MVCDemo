using MVCDemo.Interface;
using MVCDemo.Models;

namespace MVCDemo.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetPostByIdAsync(id);
        }

        public async Task AddPostAsync(Post post)
        {
            // Additional business logic before adding the post
            post.CreatedAt = DateTime.Now;
            await _postRepository.AddPostAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            // Business logic for updating the post if needed
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeletePostAsync(id);
        }
    }
}