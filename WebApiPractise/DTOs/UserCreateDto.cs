using System.ComponentModel.DataAnnotations;

namespace WebApiPractise.DTOs
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
