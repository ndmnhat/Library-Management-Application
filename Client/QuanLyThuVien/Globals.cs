using QuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    internal static class Globals
    {
        static Globals()
        {
            httpClient = new HttpClient();
        }
        public static readonly HttpClient httpClient;
        public static string access_token;
        public static NguoiDungDTO UserInfo;
    }
}
