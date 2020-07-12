using Newtonsoft.Json;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    static class SachBUS
    {
        public static async Task<List<SachDTO>> TraCuuSach()
        {
            var responseMessage = await Globals.httpClient.GetAsync("https://apilibmanagement.ml/Books");
            var result = JsonConvert.DeserializeObject<SachListDTO>(await responseMessage.Content.ReadAsStringAsync());
            return result.SachList;
        }
    }
}
