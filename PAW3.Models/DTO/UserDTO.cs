using PAW3.Models.Entities;

namespace PAW3.Models.DTO
{
    public class UserDTO
    {
        public IEnumerable<User> Users { get; set; } = [];
        
        public List<Summary> Summaries { get; set; } = [];

    }
}
