using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    static class SachBUS
    {
        public static async Task<List<SachDTO>> TraCuuSach()
        {
            var responseMessage = await Globals.httpClient.GetAsync("https://apilibmanagement.ml/Books");
            var result = JsonConvert.DeserializeObject<List<SachDTO>>(await responseMessage.Content.ReadAsStringAsync());
            return result;
        }
        public static async Task<List<SachDTO>> TraCuuSach(string keyword)
        {
            var responseMessage = await Globals.httpClient.GetAsync($"https://apilibmanagement.ml/Books/Search?keyword={keyword}");
            var result = JsonConvert.DeserializeObject<List<SachDTO>>(await responseMessage.Content.ReadAsStringAsync());
            return result;
        }
        public static async Task<bool> ThemSach(SachDTO sach)
        {
            var JsonSach = JObject.FromObject(sach);
            using (var content = new StringContent(JsonSach.ToString(), Encoding.UTF8, "application/json"))
            {
                var responseMessage = await Globals.httpClient.PostAsync("https://apilibmanagement.ml/Books", content);
                if (responseMessage.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }
        public static async Task<bool> XoaSach(SachDTO sach)
        {
                var responseMessage = await Globals.httpClient.DeleteAsync($"https://apilibmanagement.ml/Books/{sach.BookID}");
                if (responseMessage.IsSuccessStatusCode)
                    return true;
                else
                    return false;
        }
        public static async Task<bool> SuaSach(SachDTO sach)
        {
            var JsonSach = JObject.FromObject(sach);
            using (var content = new StringContent(JsonSach.ToString(), Encoding.UTF8, "application/json"))
            {
                var responseMessage = await Globals.httpClient.PutAsync($"https://apilibmanagement.ml/Books/{sach.BookID}", content);
                if (responseMessage.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }

    }
}
