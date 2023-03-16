/*
Nhóm 21, chủ đề 16:
Thành viên nhóm :
	Lê Minh Kha - mssv 21110890
	Trần Quý Thương - mssv 21110672
	Nguyễn Diệu Hương - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;

namespace Detai16_QuanLyHocPhiSinhVien
{
	// Class nay chua nhung phuong thuc tinh xu li cac input tu nguoi dung nhap khong hop le
	public static class XuLi
	{
		public static int laySoNguyenKhongAm()
		{
			Console.Write("Nhập vào: ");
			HieuUng.cachDongDau++;
			while (true)
			{
				string input = Console.ReadLine();
				int ans;
				try
				{
					ans = Int32.Parse(input);
				}
				catch
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Vui lòng nhập lại: ");
					HieuUng.cachDongDau++;
					Console.ResetColor();
					continue;
				}
				if (ans >= 0) return ans;
				else
				{ 
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Vui lòng nhập lại : ");
					HieuUng.cachDongDau++;
					Console.ResetColor();
				} 
			}
		}

		public static double LaySoThucKhongAm()
		{
			Console.Write("Nhập vào: ");
			HieuUng.cachDongDau++;
			while (true)
			{
				string input = Console.ReadLine();
				double ans;
				try
				{
					ans = Double.Parse(input);
				}
				catch
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Vui lòng nhập lại: ");
					HieuUng.cachDongDau++;
					Console.ResetColor();
					continue;
				}
				if (ans >= 0) return ans;
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Vui lòng nhập lại: ");
					HieuUng.cachDongDau++;
					Console.ResetColor();
				}
			}
		}

		public static DateTime layNgayHopLe()
		{
			DateTime myDay;
			while (true)
			{
				string input = Console.ReadLine();
				try
				{
					myDay = DateTime.ParseExact(input, "dd/MM/yyyy", null); 
				}
				catch
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Không hợp lệ, vui lòng nhập lại!\n");
					Console.ResetColor();
					Console.Write("Ngày sinh (dd/MM/yyyy): ");
					HieuUng.cachDongDau += 3;

					continue;
				}

				if (DateTime.Compare(myDay, DateTime.Now) >= 0)
				{
					Console.WriteLine("Ngày sinh phải trước ngày hiện tại, vui lòng nhập lại!");
					continue;
				}

				break;
			}
			return myDay;
		}
		public static string chuyenTiengVietKhongDau(string tiengVietCoDau)
		{
			Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
			string temp = tiengVietCoDau.Normalize(NormalizationForm.FormD);
			return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
		}
	}
}
