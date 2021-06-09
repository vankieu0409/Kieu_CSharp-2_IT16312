using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_3._1_LINQ_CacCauLenh
{
    class SanPham
    {
        public int Id { get; set; }
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MauSac { get; set; }
        public double TrongLuong { get; set; }
        public int KickThuoc { get; set; }
        public double GiaNhap { get; set; }
        public double GiaBan { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public string MoTa { get; set; }
        public int IdTheLoai { get; set; }
        public int IdNhanVien { get; set; }
        
        public void InRaManHinh()
        {
            Console.WriteLine($"{Id} | {MaSp} | {TenSp} | {MauSac} | {TrongLuong} | {KickThuoc} | {GiaNhap} | {GiaBan} | {NgayTao} | {TrangThai} | {MoTa} | {IdTheLoai} | {IdNhanVien}");
        }
    }
}
