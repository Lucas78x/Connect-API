using System.ComponentModel.DataAnnotations;

namespace Connect.Auth.Models
{
    public class ChangePasswordModel
    {
        public long Id { get; set; }

        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }

}
