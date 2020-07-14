using Newtonsoft.Json;
using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BUS
{
    class NguoiQuanLyBUS : NguoiDungDTO
    {
        public static async Task<List<NguoiDungDTO>> TraCuuDocGia()
        {
                var responseMessage = await Globals.httpClient.GetAsync("https://apilibmanagement.ml/Users");
                var result = JsonConvert.DeserializeObject<List<NguoiDungDTO>>(await responseMessage.Content.ReadAsStringAsync());
                return result;
        }
    }
}
