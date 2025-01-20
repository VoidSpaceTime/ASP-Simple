using PostServiceDomain.Entity;

namespace PostWebApi.DTO
{
    public class CategoryResponse
    {
        //public long Id { get; set; }
        public required string Name { get; set; }
        public List<PostResponse> Posts { get; set; } = new List<PostResponse>();
    }
}
