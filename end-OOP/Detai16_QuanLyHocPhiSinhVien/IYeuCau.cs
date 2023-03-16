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
	interface IYeuCau
	{
		double tinhTienHocPhi();
		void nhapThongTin();
		string xuatThongTinNganGon();
		string xuatThongTinDayDu();

		string Ten { get; set; }
		DiaChi QueQuan { get; set; }
		string MaSoSinhVien { get; set; }
		string SoCanCuocCongDan { get; set; }
		string GioiTinh { get; set; }
		DateTime NgaySinh { get; set; }
		KhoaHoc KhoaHoc { get; set; }
	}
}
