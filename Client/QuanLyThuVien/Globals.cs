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
            UserInfo = new NguoiDungDTO();
        }
        public static readonly HttpClient httpClient;
        public static string access_Token;
        public static NguoiDungDTO UserInfo;
    }
}
