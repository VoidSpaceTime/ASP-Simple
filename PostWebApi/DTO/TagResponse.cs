using PostServiceDomain.Entity;

namespace PostWebApi.DTO
{
    public class TagResponse
    {
        //public long Id { get; set; }
        public required string Name { get; set; }
        public List<PostResponse> PostsId { get; set; } = new List<PostResponse>();
    }
}
