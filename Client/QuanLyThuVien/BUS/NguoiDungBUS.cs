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
    static class NguoiDungBUS
    {
        public static async Task<bool> DangNhap(NguoiDungDTO User)
        {
            dynamic senduser = JObject.FromObject(User);
            using (var content = new StringContent(senduser.ToString(), Encoding.UTF8, "application/json"))
            {
                var result = await Globals.httpClient.PostAsync("https://apilibmanagement.ml/Authentication", content);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic response = JsonConvert.DeserializeAnonymousType(await result.Content.ReadAsStringAsync(), new { access_Token = "",userID = ""});
                    Globals.httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", response.access_Token);
                    Globals.UserInfo.UserID = response.userID;
                    NguoiDungDTO userinfo = JsonConvert.DeserializeObject<NguoiDungDTO>(await (await Globals.httpClient.GetAsync($"https://apilibmanagement.ml/Users/{Globals.UserInfo.UserID}")).Content.ReadAsStringAsync());
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
            dynamic senduser = JObject.FromObject(User);
            using (var content = new StringContent(senduser.ToString(), Encoding.UTF8, "application/json"))
            {
                var isUsernameNotAvailable = await (await Globals.httpClient.GetAsync($"https://apilibmanagement.ml/Users/CheckAvail/{User.Username}")).Content.ReadAsStringAsync();
                if (bool.Parse(isUsernameNotAvailable))
                    return false;
                else
                {
                    var response = await Globals.httpClient.PostAsync("https://apilibmanagement.ml/Users", content);
                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }    
        }
        public static void DangXuat()
        {
            Globals.httpClient.DefaultRequestHeaders.Remove("Authorization");
        }
    }
}
