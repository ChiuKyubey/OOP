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
	class SinhVienTrungCap : SinhVien, IYeuCau
	{
		//fields:
		public static int demSinhVienTrungCap = 0;
		private double hocPhiHocKi;

		//Properties:
		public double HocPhiHocKi { get => hocPhiHocKi; set => hocPhiHocKi = value; }

		//Constructor:
		public SinhVienTrungCap() : base()
		{
			demSinhVienTrungCap++;
		}
		public SinhVienTrungCap(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan, string maSoSinhVien, KhoaHoc khoaHoc, double tienBaoHiem, double phuThu, double hocPhiHocKi)
			: base(ten, ngaySinh, gioiTinh, quocTich, queQuan, diaChiThuongTru, soCanCuocCongDan, maSoSinhVien, khoaHoc, tienBaoHiem, phuThu)
		{
			demSinhVienTrungCap++;
			this.hocPhiHocKi = hocPhiHocKi;
		}

		//Method:
		public override void nhapThongTin()
		{
			base.nhapThongTin();
			Console.Write("Nhập học phí học kì: ");
			this.HocPhiHocKi = XuLi.LaySoThucKhongAm();
		}


		public double tinhTienHocPhi()
		{
			return HocPhiHocKi + TienBaoHiem + PhuThu;
		}

		public override string xuatThongTinDayDu()
		{
			string ans = base.xuatThongTinDayDu() + "\nLoại SV:".PadRight(15) + "Trung cấp" + "\nHọc phí HK:".PadRight(15) + String.Format("{0:n0}", HocPhiHocKi) + " VNĐ"
				 + "\nTổng học phí:".PadRight(15) + String.Format("{0:n0}", tinhTienHocPhi()) + " VNĐ";
			return ans;
		}
		public override string xuatThongTinNganGon()
		{
			string ans = base.xuatThongTinNganGon() + "\nHọc phí HK:".PadRight(15) + String.Format("{0:n0}", HocPhiHocKi) + " VNĐ"
				+ "\nTổng học phí:".PadRight(15) + String.Format("{0:n0}", tinhTienHocPhi()) + " VNĐ";
			return ans;
		}
	}
}
