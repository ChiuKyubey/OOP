/*
Nhóm 21, chủ đề 16:
Thành viên nhóm :
	Lê Minh Kha - mssv 21110890
	Trần Quý Thương - mssv 21110672
	Nguyễn Diệu Hương - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detai16_QuanLyHocPhiSinhVien
{
	class KhoaHoc
	{
		//Fields:
		public static int demKhoaHoc = 0;
		private string tenNienKhoa;
		private int namBatDau;
		private int namKetThuc;

		//Properties:
		public string TenNienKhoa { get => tenNienKhoa; set => tenNienKhoa = value; }
		public int NamBatDau { get => namBatDau; set => namBatDau = value; }
		public int NamKetThuc { get => namKetThuc; set => namKetThuc = value; }

		//Constructor:
		public KhoaHoc(string tenNienKhoa, int namBatDau, int namKetThuc)
		{
			demKhoaHoc++;
			this.tenNienKhoa = tenNienKhoa;
			this.namBatDau = namBatDau;
			this.namKetThuc = namKetThuc;
		}

		//Method:
		public void ThayDoiKhoaHoc()
		{
			Console.WriteLine("\tTên niên khóa mới: ");
			this.TenNienKhoa = Console.ReadLine();
			Console.WriteLine("\tNăm bắt đầu mới: ");
			this.NamBatDau = XuLi.laySoNguyenKhongAm();
			Console.WriteLine("\tNăm kết thúc mới: ");
			this.NamKetThuc = XuLi.laySoNguyenKhongAm();
			while (this.NamKetThuc <= this.NamBatDau)
			{
				Console.WriteLine("Năm kết thúc phải lớn hơn năm bắt đầu, vui lòng nhập lại!");
				Console.WriteLine("\tNăm kết thúc mới: ");
				this.NamKetThuc = XuLi.laySoNguyenKhongAm();
			}
		}

		public string toString()
		{
			return "\tTên niên học:".PadRight(15) + tenNienKhoa + "\n\tnăm bắt đầu:".PadRight(15) + namBatDau + "\n\tNăm kết thúc:".PadRight(15) + namKetThuc; 
		}
	}
}
