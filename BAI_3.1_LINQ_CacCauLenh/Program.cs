﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace BAI_3._1_LINQ_CacCauLenh
{
    class Program
    {
        private static ServiceAll sa = new ServiceAll();
        private static List<NhanVien> _lstNhanViens;
        private static List<SanPham> _lstSanPhams;
        private static List<TheLoai> _lsttTheLoais;
        public Program()
        {
            _lstNhanViens = sa.GetListNhanViens();
            _lstSanPhams = sa.GetListSanPhams();
            _lsttTheLoais = sa.GetListTheLoais();
        }
      

        #region 1. Toán tử Where để lọc theo điều kiện trả về 1 danh sách hoặc 1 giá trị sau khi thỏa mãn điều kiện

        public static void ViduWhere()
        {
            //Lọc ra 1 danh sách nhân viên sống tại HN và Quê cũng phải HN
            var lst = (from a in _lstNhanViens
                      where a.ThanhPho == "HN" && a.QueQuan == "HN"
                      select a).ToList();
            var lst1 = _lstNhanViens.Where(c => c.QueQuan == "HN" && c.ThanhPho == "HN").Select(c => c).ToList();
            foreach (var x in lst)
            {
                x.InRaManHinh();
            }
        }
        #endregion

        #region 2. Toán tử OfType để lọc theo điều kiện lọc một phần tử trong tập hợp thành một kiểu được chỉ định

        public static void ViduOfType()
        {
            ArrayList arrTemp = new ArrayList();
            arrTemp.Add(1);
            arrTemp.Add("Mot");
            arrTemp.Add("Hai");
            arrTemp.Add(2);

            var lstTemp1 = from a in arrTemp.OfType<string>()
                select a;
            var lstTemp2 = from a in arrTemp.OfType<int>()
                select a;
            Console.WriteLine("arrTemp.OfType<string>()");
            foreach (var x in lstTemp1)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
            Console.WriteLine("arrTemp.OfType<int>()");
            foreach (var x in lstTemp2)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }

        #endregion

        #region 3Order by sắp xếp danh  sách theo 1 điều kiện

        public static  void viduOrderby()
        {
            var temp = from a in _lstNhanViens
                orderby a.TenNV
                select a;
            var tem = _lstNhanViens.OrderBy(c => c.TenNV);
        }
        // thenby mở roojgn để sắp xếp thêm nhiều trường hơn
        public static void VIDUThenBy()
        {
            var tem2 = _lstNhanViens.OrderBy(c => c.TenNV).ThenBy(c=>c.ThanhPho);

        }

        #endregion

        #region Group by

        public static void ViDU_Groupby()
        {
            List<string> _lstName = new List<string>{"Trang","KIều","a","b"};
            var temgroupbya = from a in _lstName 
                group a by a into  g
                select g.Key;// nhóm những cái String
            foreach (var VARIABLE in temgroupbya)
            {
                Console.WriteLine( VARIABLE +" ");
            }

            var LstTempSP = from a in _lstSanPhams
                group a by new
                {
                    a.IdTheLoai,
                    a.GiaBan
                }
                into g
                select new SanPham()
                {
                    IdTheLoai = g.Key.IdTheLoai,
                    GiaBan = g.Key.GiaBan,
                    TenSp = null
                };
            foreach (var x in LstTempSP)
            {
                x.InRaManHinh();
            }


            var LstTempS1P = from a in _lstSanPhams
                group a by a.IdTheLoai
                into g
                select g.Key;
            foreach (var VARIABLE in LstTempSP)
            {
                Console.WriteLine(VARIABLE);
            }

        }

        #endregion
        #region 3. OrderBy sử dụng để sắp xếp danh sách theo một điều kiện cụ thể

        public static void ViDuOrderBy()
        {
            var temp = from a in _lstNhanViens
                       orderby a.TenNV  //ascending || descending
                       select a;
            var temp2 = _lstNhanViens.OrderBy(c => c.TenNV);//Cách viết lambda
            //In ra màn hình để kiểm tra
            foreach (var x in temp)
            {
                x.InRaManHinh();
            }
        }
        //ThenBy và ThenByDescending đi với Orderby và nó là mở rộng để sắp xếp thêm nhiều trường hơn
        public static void ViDuThenBy()
        {
            var temp2 = _lstNhanViens.OrderBy(c => c.TenNV).ThenBy(c => c.ThanhPho);
            var temp3 = _lstNhanViens.OrderBy(c => c.TenNV).ThenByDescending(c => c.ThanhPho);
            foreach (var x in temp2)
            {
                x.InRaManHinh();
            }
        }


        #endregion

        #region 4. GroupBy nhóm các thành phần giống nhau
        public static void ViduGroupBy()
        {
            List<string> lstName = new List<string> { "Trang", "Trang", "Kiều", "Kiều", "A", "B", "C" };
            var tempGroup = from a in lstName
                            group a by a into g
                            select g.Key;//Nhóm các String giống nhau lại

            var lstTemp = from a in _lstSanPhams
                          group a by a.IdTheLoai
                into g
                          select g.Key;

            var lstTemp1 = from a in _lstSanPhams
                           group a by new
                           {
                               a.IdTheLoai,
                               a.GiaNhap
                           }
                into g
                           select new SanPham()
                           {
                               IdTheLoai = g.Key.IdTheLoai,
                               GiaNhap = g.Key.GiaNhap,
                               TenSp = Convert.ToString(g.Sum(c => c.GiaNhap))

                           };
            var lstTemp2 = _lstSanPhams.GroupBy(a => new { a.IdTheLoai, a.GiaNhap })
                .Select(g => new SanPham()
                {
                    IdTheLoai = g.Key.IdTheLoai,
                    GiaNhap = g.Key.GiaNhap,
                    TenSp = Convert.ToString(g.Sum(c => c.GiaNhap))
                });//Sử dụng lambda với câu trên

            //Khi sử dụng Groupby khi cần nhóm các cột dữ liệu giống nhau tạo thành các bản ghi mới và thường đi với các hàm tổng hợp

            //Buổi sau code lại câu đếm số lượng nhân viên sống tại HN sử dụng Groupby
            //Tính tổng giá bán của các sản phẩm có cùng thể loại
        }
        #endregion

        #region 5. Join

        public static void ViduJoin()
        {
            //Hiển thị thông tin sản phẩm bao gồm (Mã, Tên, Mầu sắc, Tên Nhân Viên, Mã Nhân Viên)
            var temp =
                       from a in _lstSanPhams //Truy vấn vào bảng....
                       join b in _lstNhanViens //Inner Join với bảng ...
                       on a.IdNhanVien equals b.Id //Key khóa phụ so sánh với khóa chính
                       join c in _lsttTheLoais
                       on a.IdTheLoai equals c.Id
                       where a.TrangThai == true //Đưa thêm điều kiện vào nếu cần
                       select new
                       {
                           //Select ra kết quả là các cột mới không phải là các cột có sẵn
                           MaSP = a.MaSp,//a là của bảng sản phẩm
                           TenTheLoai = c.TenTheLoai, //c là của bảng thể loại
                           TenSP = a.TenSp,
                           Color = a.MauSac,
                           TenNVTao = b.TenNV,//b là của bảng nhân viên
                           MaNVTao = b.MaNV,
                           TrangThai = a.TrangThai
                       };

            //Cách 2 tự Viết lambada với join
            var temp2 = _lstSanPhams.Join(_lstNhanViens, c => c.IdNhanVien, d => d.Id, (c, d) => new
            {
                //Select ra kết quả là các cột mới không phải là các cột có sẵn
                MaSP = c.MaSp, //a là của bảng sản phẩm
                TenSP = c.TenSp,
                Color = c.MauSac,
                TenNVTao = d.TenNV, //b là của bảng nhân viên
                MaNVTao = d.MaNV,
                TrangThai = c.TrangThai
            });//Tự viết Lambda nếu muốn

            foreach (var x in temp)
            {
                Console.WriteLine($"{x.MaSP} + {x.TenSP} + {x.TenNVTao} + {x.TenTheLoai}");
            }

            //có thể kết hợp với Group by
        }
        #endregion

        #region  Câu lệnh Select trả về tập hợp chứa các phần tử

        public static void ViduSelect()
        {
            var temp = from a in _lstNhanViens
                select a; // trả về đối tượng nhân viên
            var temp2 = from a in _lstNhanViens
                select a.TenNV; //trả về 1 tập giá trị có kiểu String

            foreach (var VARIABLE in temp)
            {
                VARIABLE.InRaManHinh();
            }

            Console.WriteLine(" ");
            foreach (var VARIABLE in temp2)
            {
                Console.WriteLine(VARIABLE+" ");
            }

            foreach (var VARIABLE in _lstSanPhams.GroupBy(a=>a.MauSac))
            {
                Console.Write(VARIABLE.Key+" * ");
            }

            Console.WriteLine("\n");
            foreach (var VARIABLE in _lstSanPhams.SelectMany(a => a.MauSac))
            {
                Console.Write(VARIABLE+ " *" );
            }

            var temp4 = from a in _lstNhanViens
                select new
                {
                    name = a.TenNV,
                    addr = a.DiaChi

                };
            foreach (var VARIABLE in temp4.SelectMany(a => a.addr))
            {
                Console.Write(VARIABLE +" "/*+VARIABLE.addr*/);
            }
        }

        #endregion

        #region All && Any

        public static void viDuANY()
        {
            //All: Kiểm tra xem tất cả các phần tử trong dãy thỏa mán thì trả ra true
            //Any: Kiểm tra xem tất cả các phần tử trong dãy chỉ cần có thỏa mán thì trả ra true
            var temp = _lsttTheLoais.All(c => c.TrangThai == true);
            var temp2 = _lsttTheLoais.Any(c => c.TrangThai == true);
            Console.WriteLine(temp);
            Console.WriteLine(temp2);
            TheLoai theLoainew = new TheLoai {Id = -1, MaTheLoai = "TL1", TenTheLoai = "Small", TrangThai = true};
            var temp3 = _lsttTheLoais.Contains(theLoainew,new TheLoai());
            Console.WriteLine("contains : "+temp3);
        }


        #endregion

        #region Arrgreation  - SUM- MIN-MAx CUONT-AVERAGE
        
        public static void ARRGREATION()
        {
            // tính tổng số lượng máy màu đen mà cửa hàng đang có
            // var temp_mayden= from a in _lstSanPhams
            //           where a.MauSac=="Đen"
            //           select 

        }

        #endregion
        static void Main(string[] args)
        {
            //Gọi các ví dụ về lý thuyết lên để chạy
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            Program program = new Program();
            viDuANY();
        }
    }
}
