using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrinhDuyTung._1621050544.Controllers
{
    public class BaiVeNhaController : Controller
    {
        Xuly xl = new XuLy();
        public ActionResult bai1(string HeSoa, string HeSob, string HeSoc)
        {
            double a, b, c;
            a = Convert.ToDouble(HeSoa);
            b = Convert.ToDouble(HeSob);
            c = Convert.ToDouble(HeSoc);
            double delta = b * b - 4 * a * c;
            double X1, X2;
            if (delta > 0)
            {
                //Có hai nghiệm phân biệt
                X1 = (-b + Math.Sqrt(delta)) / (2 * a);
                X2 = (-b - Math.Sqrt(delta)) / (2 * a);
                ViewBag.Ketqua = "Phương trình có hai nghiệm phân biệt:";
                ViewBag.Value = "x1 = " + X1 + ", x2 = " + X2;
            }
            else if (delta == 0)
            {
                //Có nghiệm kép
                X1 = X2 = -b / (2 * a);
                ViewBag.Ketqua = "Phương trình có nghiệm kép:";
                ViewBag.Value = "x1 = x2 = " + X2;
            }
            else
            {
                ViewBag.Ketqua = "Phương trình vô nghiệm";
            }
            return View();

        }
        public ActionResult bai2(string son)
        {
            int n;
            double s = 0;
            n = Convert.ToInt32(son);
            for (double i = 1; i <= n; i++)
            {
                s = s + 1 / i;
            }
            ViewBag.Ketqua = "Tổng là :" + s;
            return View();
        }
        [HttpPost]
        public ActionResult bai3(string sox)
        {
            double n;
            int tong = 0;
            n = Convert.ToDouble(sox);
            List<int> soNguyenTo = new List<int>(); //Tao 1 danh sach de lấy các số nguyên tố nhỏ hơn số nhập vào
            for (int i = 1; i < n; i++) //Chạy vòng lặp từ 1 đến n để lấy ra các số NT nhỏ hơn n
            {
                if (kiemtrasonguyento(i)) // Kiểm tra nếu số đó là số nguyên tố
                {
                    soNguyenTo.Add(i); // Thêm vào danh sách số nguyên tố nến số đó là số nguyên tố
                }
            }

            foreach (int z in soNguyenTo) // Lấy từng số nguyên tố trong danh sách số nguyên tố
            {
                //cộng từng phần tử vào biến tổng
                int check = tong + z;
                if (check <= 100)
                {
                    tong += z;
                }
            }

            ViewBag.Tong = tong;
            return View();
        }

        bool kiemtrasonguyento(int number)
        {
            int bien_dem = 0;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    bien_dem++;
                }
            }
            if (bien_dem == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public ActionResult bai4(string sox)
        {
            int n;
            int tong = 0;
            n = Convert.ToInt32(sox);
            List<int> soNguyenTo = new List<int>();

            if (xl.kiemtraSNT(n))
            {
                ViewBag.snt = n + " là số nguyên tố";
            }
            for (int i = 1; i < n; i++)
            {
                if (xl.kiemtraSNT(i))
                {
                    soNguyenTo.Add(i);
                }
            }

            foreach (int z in soNguyenTo)
            {
                int check = tong + z;
                if (check <= 100)
                {
                    tong += z;
                }
            }

            ViewBag.Tong = "Tổng các số nguyên tố nhỏ hơn " + n + " là: " + tong;
            return View();
        }
    }
}
