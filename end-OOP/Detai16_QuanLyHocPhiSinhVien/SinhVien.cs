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
	abstract class SinhVien : Nguoi
	{
		//Fields:
		public static int demSinhVien = 0;
		private string maSoSinhVien;
		private KhoaHoc khoaHoc;
		private double tienBaoHiem;
		private double phuThu;

		//Properties:
		public string MaSoSinhVien { get => maSoSinhVien; set => maSoSinhVien = value; }
		public double TienBaoHiem { get => tienBaoHiem; set => tienBaoHiem = value; }
		public double PhuThu { get => phuThu; set => phuThu = value; }
		public KhoaHoc KhoaHoc { get => khoaHoc; set => khoaHoc = value; }

		//Constructors:
		public SinhVien() : base()
		{
			demSinhVien++;
			this.maSoSinhVien = "";
			this.khoaHoc = new KhoaHoc("", 0, 0);
			this.tienBaoHiem = 0;
			this.phuThu = 0;
		}

		public SinhVien(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan)
		{
			demSinhVien++;
			this.maSoSinhVien = maSoSinhVien;
			this.khoaHoc = khoaHoc;
			this.tienBaoHiem = tienBaoHiem;
			this.phuThu = phuThu;
		}

		//Methods:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Nhập MSSV: ");
			this.MaSoSinhVien = Console.ReadLine();
			Console.WriteLine("Nhập Khoá học: ");
			Console.Write("\tNhập tên niên khoá: ");
			this.khoaHoc.TenNienKhoa = Console.ReadLine();
			Console.Write("\tNhập năm bắt đầu khoá học: ");
			this.KhoaHoc.NamBatDau = XuLi.laySoNguyenKhongAm();
			Console.Write("\tNhập năm kết thúc khoá học: ");
			this.KhoaHoc.NamKetThuc = XuLi.laySoNguyenKhongAm();
			while (this.KhoaHoc.NamKetThuc <= this.KhoaHoc.NamBatDau)
			{
				Console.WriteLine("Năm kết thúc phải lớn hơn năm bắt đầu, vui lòng nhập lại!");
				Console.Write("\tNhập năm kết thúc khoá học: ");
				this.KhoaHoc.NamKetThuc = XuLi.laySoNguyenKhongAm();
			}
			Console.Write("Nhập tiền bảo hiểm: ");
			this.TienBaoHiem = XuLi.LaySoThucKhongAm();
			Console.Write("Nhập tiền phụ thu: ");
			this.PhuThu = XuLi.LaySoThucKhongAm();
		}

		public virtual string xuatThongTinNganGon()
		{
			string ans = "Họ và tên:".PadRight(14) + Ten + "\nMSSV:".PadRight(15) + maSoSinhVien
				+ "\nKhoá học:".PadRight(15) + KhoaHoc.TenNienKhoa + "\nTiền BH:".PadRight(15) + String.Format("{0:n0}", TienBaoHiem) + " VNĐ"
				+ "\nPhụ thu:".PadRight(15) + String.Format("{0:n0}", PhuThu) + " VNĐ";
			return ans;
		}

		public virtual string xuatThongTinDayDu()
		{
			string ans = base.toString() + "\nMSSV:".PadRight(15) + maSoSinhVien
				+ "\nKhoá hoc:".PadRight(15) + KhoaHoc.TenNienKhoa + "\nTiền BH:".PadRight(15) + String.Format("{0:n0}", TienBaoHiem) + " VNĐ"
				+ "\nPhụ thu:".PadRight(15) + String.Format("{0:n0}", PhuThu) + " VNĐ";
			return ans;
		}
	}
}
