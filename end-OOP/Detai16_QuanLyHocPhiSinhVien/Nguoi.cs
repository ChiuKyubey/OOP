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
	abstract class Nguoi
	{
		//Fields:
		public static int demNguoi = 0;
		private string ten;
		private DateTime ngaySinh;
		private string gioiTinh;
		private string quocTich;
		private DiaChi queQuan;
		private DiaChi diaChiThuongTru;
		private string soCanCuocCongDan;

		//Properties:
		public string Ten { get => ten; set => ten = value; }
		public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
		public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
		public string QuocTich { get => quocTich; set => quocTich = value; }
		public string SoCanCuocCongDan { get => soCanCuocCongDan; set => soCanCuocCongDan = value; }
		public DiaChi QueQuan { get => queQuan; set => queQuan = value; }
		public DiaChi DiaChiThuongTru { get => diaChiThuongTru; set => diaChiThuongTru = value; }

		//Constructors:
		public Nguoi(string ten, DateTime ngaySinh, string gioiTinh, string quocTich, DiaChi queQuan, DiaChi diaChiThuongTru, string soCanCuocCongDan)
		{
			demNguoi++;
			this.ten = ten;
			this.ngaySinh = ngaySinh;
			this.gioiTinh = gioiTinh;
			this.quocTich = quocTich;
			this.queQuan = queQuan;
			this.DiaChiThuongTru = diaChiThuongTru;
			this.soCanCuocCongDan = soCanCuocCongDan;
		}

		public Nguoi()
		{
			demNguoi++;
			this.ten = "";
			this.ngaySinh = new DateTime(1,1,1);
			this.gioiTinh = "Nam";
			this.quocTich = "Việt Nam";
			this.queQuan = new DiaChi("", "", "");
			this.DiaChiThuongTru = new DiaChi("", "", "");
			this.soCanCuocCongDan = "";
		}


		//Methods:
		public virtual string toString()
		{
			string ans = "Họ và tên:".PadRight(15) + Ten + "\nNgày sinh:".PadRight(15) + NgaySinh.ToString("dd/MM/yyyy")
				+ "\nGiới tính:".PadRight(15) + GioiTinh + "\nQuốc tịch:".PadRight(15) + QuocTich
				+ "\nQuê quán".PadRight(15) + queQuan.toString() + "\nĐC thường trú:".PadRight(15) + diaChiThuongTru.toString()
				+ "\nSố CCCD:".PadRight(15) + soCanCuocCongDan;
			return ans;
		}



		public virtual void nhapThongTin()
		{
			Console.Write("Nhập họ và tên: ");
			this.Ten = Console.ReadLine();
			Console.Write("Nhập ngày sinh(dd/MM/yyyy): ");
			this.NgaySinh = XuLi.layNgayHopLe();
			Console.Write("Nhập giới tính: ");
			this.GioiTinh = Console.ReadLine();
			Console.Write("Nhập quốc tịch: ");
			this.QuocTich = Console.ReadLine();
			Console.WriteLine("Nhập quê quán: ");
			string str1, str2, str3;
			Console.Write("\tTỉnh/TP: "); str1 = Console.ReadLine();
			Console.Write("\tHuyện/Quận/TP: "); str2 = Console.ReadLine();
			Console.Write("\tXã/Phường: "); str3 = Console.ReadLine();
			this.QueQuan = new DiaChi(str1, str2, str3);

			Console.WriteLine("Nhập địa chỉ thường trú: ");
			Console.Write("\tTỉnh/TP: "); str1 = Console.ReadLine();
			Console.Write("\tHuyện/Quận/TP: "); str2 = Console.ReadLine();
			Console.Write("\tXã/Phường: "); str3 = Console.ReadLine();
			this.DiaChiThuongTru = new DiaChi(str1, str2, str3);

			Console.Write("Nhập số căn cước công dân: ");
			this.SoCanCuocCongDan = Console.ReadLine();

		}
	}
}
