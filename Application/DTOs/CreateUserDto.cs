namespace SmartCity.Application.DTOs;

    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
