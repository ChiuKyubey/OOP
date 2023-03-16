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
	class DiaChi
	{
		//Fields:
		private static int demDiaChi = 0;
		private string tinh;
		private string huyen;
		private string xa;

		//Properties:
		public static int DemDiaChi { get => demDiaChi; set => demDiaChi = value; }
		public string Tinh { get => tinh; set => tinh = value; }
		public string Huyen { get => huyen; set => huyen = value; }
		public string Xa { get => xa; set => xa = value; }

		//Constructor:
		public DiaChi(string tinh, string huyen, string xa)
		{
			DemDiaChi++;
			this.Tinh = tinh;
			this.Huyen = huyen;
			this.Xa = xa;
		}

		public string toString()
		{
			return $"{xa}, {huyen}, {tinh}";
		}

		public void ThayDoiDiaChi()
		{
			Console.Write("\tTỉnh: ");
			this.Tinh = Console.ReadLine();
			Console.Write("\tHuyện: ");
			this.Huyen = Console.ReadLine();
			Console.Write("\tXã: ");
			this.Xa = Console.ReadLine();
		}
	}
}
