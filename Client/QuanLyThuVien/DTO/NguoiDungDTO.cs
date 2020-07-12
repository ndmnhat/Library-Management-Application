using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class NguoiDungDTO
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public NguoiDungDTO()
        {
        }
        public NguoiDungDTO(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public NguoiDungDTO(string UserID, string Username, string Password, string Name, string Email, string Role)
        {
            this.UserID = "";
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            this.Role = Role;
        }
        public NguoiDungDTO(string Username, string Password, string Name, string Email, string Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            this.Role = Role;
        }
    }
}
