﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_3._1_LINQ_CacCauLenh
{
    class ServiceAll
    {
        public List<NhanVien> GetListNhanViens()
        {
            return new List<NhanVien>
            {
                new NhanVien{Id = 1,MaNV = "Dungna1",TenNV = "Dũng",Email = "dungna29@gmail.com",Sdt = "0912345678",DiaChi = null,ThanhPho = "HN",QueQuan = "HN",TrangThai = true},
                new NhanVien{Id = 2,MaNV = "MinhDq",TenNV = "Minh",Email = "minhdq@gmail.com",Sdt = "0865791529",DiaChi = null,ThanhPho = "HN",QueQuan = "HN",TrangThai = true},
                new NhanVien{Id = 3,MaNV = "Tiennh",TenNV = "Tiến",Email = "tiennh@gmail.com",Sdt = "0982666611",DiaChi = null,ThanhPho = "ST",QueQuan = "HN",TrangThai = true},
                new NhanVien{Id = 4,MaNV = "Dungna2",TenNV = "Dũng",Email = "dungna28@gmail.com",Sdt = "09811111111",DiaChi = null,ThanhPho = "HCM",QueQuan = "HN",TrangThai = true},
            };
        }
        public List<SanPham> GetListSanPhams()
        {
            return new List<SanPham>
            {
                new SanPham{Id = 1,MaSp = "SP1",TenSp = "Iphone 1",MauSac = "Đen",TrongLuong = 900.5,KickThuoc = 5,GiaNhap = 7000000,GiaBan = 14000000,NgayTao = new DateTime(2021, 12, 5),TrangThai = true,MoTa = null,IdTheLoai = 1,IdNhanVien = 1},
                new SanPham{Id = 2,MaSp = "SP2",TenSp = "Iphone 2",MauSac = "Đỏ",TrongLuong = 1000,KickThuoc = 6,GiaNhap = 8000000,GiaBan = 15000000,NgayTao = new DateTime(2021, 10, 5),TrangThai = true,MoTa = null,IdTheLoai = 1,IdNhanVien = 2},
                new SanPham{Id = 3,MaSp = "SP3",TenSp = "Iphone 3",MauSac = "Đen",TrongLuong = 700,KickThuoc = 7,GiaNhap = 9000000,GiaBan = 18000000,NgayTao = new DateTime(2021, 12, 5),TrangThai = false,MoTa = null,IdTheLoai = 1,IdNhanVien = 3},
                new SanPham{Id = 4,MaSp = "SP4",TenSp = "Iphone 4",MauSac = "Trắng",TrongLuong = 700,KickThuoc =8,GiaNhap = 10000000,GiaBan = 18000000,NgayTao = new DateTime(2021, 11, 5),TrangThai = true,MoTa = null,IdTheLoai = 1,IdNhanVien = 4},
                new SanPham{Id = 5,MaSp = "SP5",TenSp = "Iphone 5",MauSac = "Đen",TrongLuong = 600,KickThuoc = 9,GiaNhap = 11000000,GiaBan = 19000000,NgayTao = new DateTime(2021, 1, 5),TrangThai = false,MoTa = null,IdTheLoai = 1,IdNhanVien = 5},
                new SanPham{Id = 6,MaSp = "SP6",TenSp = "Iphone 6",MauSac = "Đen",TrongLuong = 500,KickThuoc = 10,GiaNhap = 12000000,GiaBan = 21000000,NgayTao = new DateTime(2021, 12, 5),TrangThai = true,MoTa = null,IdTheLoai = 1,IdNhanVien = 1},
                new SanPham{Id = 7,MaSp = "SP7",TenSp = "Iphone 7",MauSac = "Trắng",TrongLuong = 700,KickThuoc = 11,GiaNhap = 12000000,GiaBan = 22000000,NgayTao = new DateTime(2021, 11, 5),TrangThai = false,MoTa = null,IdTheLoai = 1,IdNhanVien = 2},
                new SanPham{Id = 8,MaSp = "SP8",TenSp = "Iphone 8",MauSac = "Đen",TrongLuong = 800,KickThuoc = 8,GiaNhap = 9000000,GiaBan = 18000000,NgayTao = new DateTime(2021, 10, 5),TrangThai = false,MoTa = null,IdTheLoai = 1,IdNhanVien = 3},
                new SanPham{Id = 9,MaSp = "SP9",TenSp = "Iphone 9",MauSac = "Trắng",TrongLuong = 800,KickThuoc = 9,GiaNhap = 13000000,GiaBan = 23000000,NgayTao = new DateTime(2021, 1, 5),TrangThai = true,MoTa = null,IdTheLoai = 2,IdNhanVien = 4},
                new SanPham{Id = 10,MaSp = "SP10",TenSp = "Iphone 10",MauSac = "Càng",TrongLuong = 900,KickThuoc = 12,GiaNhap = 13000000,GiaBan = 24000000,NgayTao = new DateTime(2021, 2, 5),TrangThai = true,MoTa = null,IdTheLoai = 2,IdNhanVien = 1}
            };
        }
        public List<TheLoai> GetListTheLoais()
        {
            return new List<TheLoai>
            {
                new TheLoai{Id = 1,MaTheLoai = "TL1",TenTheLoai = "Small",TrangThai = true},
                new TheLoai{Id = 2,MaTheLoai = "TL2",TenTheLoai = "Large",TrangThai = true},
                new TheLoai{Id = 3,MaTheLoai = "TL3",TenTheLoai = "Full Size",TrangThai = false},
            };
        }
    }
}
