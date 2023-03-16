using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Dto
{
    public class LoginDto
    {
        required public string User {get; set; }

        required public string Password { get; set; }
    }
}
