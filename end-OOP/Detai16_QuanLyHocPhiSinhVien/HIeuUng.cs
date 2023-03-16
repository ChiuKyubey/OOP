using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Detai16_QuanLyHocPhiSinhVien
{
	public static class HieuUng
	{
		public static int cachDongDau = 0;

		public static void ThanhTienDo(int kcLeTrai, int kcLeTren, int tongSoPhanTram, ConsoleColor color)
		{
			int isaret = 2;
			char[] symbol = new char[5] { '\u25A0', '\u2592', '\u2588', '\u2551', '\u2502' };
			int maxBarSize = Console.BufferWidth - 1;
			int barSize = tongSoPhanTram;
			decimal f = 1;
			if (barSize + kcLeTrai > maxBarSize)
			{
				barSize = maxBarSize - (kcLeTrai + 5); // first 5 character "%100 "
				f = (decimal)tongSoPhanTram / (decimal)barSize;
			}
			Console.CursorVisible = false;
			Console.ForegroundColor = color;
			Console.SetCursorPosition(kcLeTrai + 5, kcLeTren);
			Random rnd_time = new Random();
			for (int i = 0; i < barSize + 1; i++)
			{
				if (i % rnd_time.Next(3, 8) == 0)
					Thread.Sleep(25);
				else
					Thread.Sleep(0);
				Console.Write(symbol[isaret]);
				Console.SetCursorPosition(kcLeTrai, kcLeTren);
				Console.Write((i * f).ToString("0,0") + "%");
				Console.SetCursorPosition(kcLeTrai + 5 + i, kcLeTren);
			}
			Console.WriteLine();
			Console.CursorVisible = true;
			Console.ResetColor();
		}
	}
}
