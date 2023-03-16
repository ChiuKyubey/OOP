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
	class SinhVienCaoDang : SinhVien, IYeuCau
	{
		//field:
		public static int demSinhVienCaoDang = 0;
		private int soTinChilyThuyet;
		private double donGiaMonLyThuyet;
		private int soTinChiMonThucHanh;
		private double donGiaMonThucHanh;

		//Properties:
		public int SoTinChilyThuyet { get => soTinChilyThuyet; set => soTinChilyThuyet = value; }
		public double DonGiaMonLyThuyet { get => donGiaMonLyThuyet; set => donGiaMonLyThuyet = value; }
		public int SoTinChiMonThucHanh { get => soTinChiMonThucHanh; set => soTinChiMonThucHanh = value; }
		public double DonGiaMonThucHanh { get => donGiaMonThucHanh; set => donGiaMonThucHanh = value; }

		//Constructor:
		public SinhVienCaoDang() : base()
		{
			
			demSinhVienCaoDang++;
		}
		public SinhVienCaoDang(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu,
			int soTinChilyThuyet, double donGiaMonLyThuyet, int soTinChiMonThucHanh, double donGiaMonThucHanh)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan, maSoSinhVien, khoaHoc, tienBaoHiem, phuThu)
		{
			demSinhVienCaoDang++;
			this.soTinChilyThuyet = soTinChilyThuyet;
			this.donGiaMonLyThuyet = donGiaMonLyThuyet;
			this.soTinChiMonThucHanh = soTinChiMonThucHanh;
			this.donGiaMonThucHanh = donGiaMonThucHanh;
		}

		//Method:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Nhập số tín chỉ lý thuyết: "); this.soTinChilyThuyet = XuLi.laySoNguyenKhongAm();
			Console.Write("Nhập đơn giá môn lý thuyết: "); this.donGiaMonLyThuyet = XuLi.LaySoThucKhongAm();
			Console.Write("Nhập số tín chỉ thực hành: "); this.soTinChiMonThucHanh = XuLi.laySoNguyenKhongAm();
			Console.Write("Nhập đơn giá môn thực hành: "); this.donGiaMonThucHanh = XuLi.LaySoThucKhongAm();

		}

		public double tinhTienHocPhi()
		{
			return SoTinChilyThuyet * DonGiaMonLyThuyet + SoTinChiMonThucHanh * DonGiaMonThucHanh + PhuThu + TienBaoHiem;
		}

		public override string xuatThongTinDayDu()
		{
			string ans = base.xuatThongTinDayDu() + "\nLoại SV:".PadRight(15) + "Cao đẳng" + "\nSố TCLT:".PadRight(15) + SoTinChilyThuyet.ToString() + "\nSố TCTH:".PadRight(15) + SoTinChiMonThucHanh
				+ "\nĐơn giá LT:".PadRight(15) + String.Format("{0:n0}", DonGiaMonLyThuyet) + " VNĐ" + "\nĐơn giá TH:".PadRight(15) + String.Format("{0:n0}", DonGiaMonThucHanh) + " VNĐ"
				+ "\nTổng học phí:".PadRight(15) + String.Format("{0:n0}", tinhTienHocPhi()) + " VNĐ";
			return ans;
		}

		public override string xuatThongTinNganGon()
		{
			string ans = base.xuatThongTinNganGon() + "\nSố TCLT:".PadRight(15) + SoTinChilyThuyet.ToString()
				+ "\nSố TCTH:".PadRight(15) + SoTinChiMonThucHanh.ToString()
				+ "\nTổng học phí:".PadRight(15) + String.Format("{0:n0}", tinhTienHocPhi()) + " VNĐ";
			return ans;
		}
	}
}
