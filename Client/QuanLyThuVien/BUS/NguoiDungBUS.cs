using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BUS
{
    class NguoiDungBUS
    {
        public static async Task<bool> DangNhap(NguoiDungDTO User)
        {
            string jsonstring = $"{{Username:'{User.Username}',Password:'{User.Password}'}}";
            dynamic senduser = JObject.Parse(jsonstring);
            using (var content = new StringContent(senduser.ToString(), Encoding.UTF8, "application/json"))
            {
                var result = await Globals.httpClient.PostAsync("https://apilibmanagement.ml/Authentication", content);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic response = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());
                    Globals.httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", response.access_token);
                    //Sua lai userID
                    NguoiDungDTO userinfo = (NguoiDungDTO)JsonConvert.DeserializeObject(await (await Globals.httpClient.GetAsync($"https://apilibmanagement.ml/Users/{UserID}")).Content.ReadAsStringAsync());
                    Globals.UserInfo = userinfo;
                    return true;
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    return false;
                }
            }
        }
        public static async Task<bool> DangKy(NguoiDungDTO User)
        {
            string jsonstring = $"{{Username:'{User.Username}',Password:'{User.Password}',Name:'{User.Name}',Email:'{User.Email}'}}";
            dynamic senduser = JObject.Parse(jsonstring);
            using (var content = new StringContent(senduser.ToString(), Encoding.UTF8, "application/json"))
            {
                var result = await
            }    
        }
    }
}
