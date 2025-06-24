namespace Application.DTOs {
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApproved { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}