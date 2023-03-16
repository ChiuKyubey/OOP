/*
Nhóm 21, chủ đề 16:
Thành viên nhóm :
	Lê Minh Kha - mssv 21110890
	Trần Quý Thương - mssv 21110672
	Nguyễn Diệu Hương - mssv 21110489
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Detai16_QuanLyHocPhiSinhVien
{
	internal class Program
	{
		public static void ThemSinhVien_1(ref List<IYeuCau> DS_SinhVien)
		{
			Console.ResetColor();
			int soLuongSVthemvao = 0;
			Console.Write("Nhập số lượng sinh viên cần thêm: "); soLuongSVthemvao = XuLi.laySoNguyenKhongAm();
			while (soLuongSVthemvao != 0)
			{

				IYeuCau SinhVien_Tam;
				string loaiSinhVien;
				Console.WriteLine("---");
				Console.Write("Chọn loại sinh viên(1.Sinh viên trung cấp, 2.Sinh viên cao đẳng): "); loaiSinhVien = Console.ReadLine();
				loaiSinhVien = loaiSinhVien.Trim();
				if (loaiSinhVien == "1")
				{
					SinhVien_Tam = new SinhVienTrungCap();
					SinhVien_Tam.nhapThongTin();
				}
				else if (loaiSinhVien == "2")
				{
					SinhVien_Tam = new SinhVienCaoDang();
					SinhVien_Tam.nhapThongTin();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.Write("Chọn không hợp lệ, vui lòng chọn lại!");
					Console.ResetColor();
					Console.ReadKey();
					Console.WriteLine();
					continue;
				}
				DS_SinhVien.Add(SinhVien_Tam);
				soLuongSVthemvao--;
			}
		}

		public static void XoaSinhVienKhoiDanhSach_2(ref List<IYeuCau> DS_SinhVien)
		{
			HieuUng.cachDongDau = 0;

			if (DS_SinhVien.Count == 0)
			{
				Console.Write("Không có sinh viên nào trong danh sách!\nẤn nút bất kì để về MENU chính! ");
				Console.ReadKey();
				return;
			}
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(" Bạn muốn xoá sinh viên theo lựa chọn nào: ");
			Console.WriteLine(" 1. Xoá sinh viên theo tên");
			Console.WriteLine(" 2. Xoá sinh viên theo mã số sinh viên");
			Console.WriteLine(" 3. Xoá sinh viên theo số căn cước công dân");
			Console.WriteLine(" 4. Xoá sinh viên theo số thứ tự trong danh sách (stt bắt đầu từ 1)");
			Console.ResetColor();
			string luaChon;

			while (true)
			{
				Console.Write("Lựa chọn : ");
				luaChon = Console.ReadLine();
				HieuUng.cachDongDau = 6;

				if (luaChon == "1")
				{
					Console.Write("Nhập tên của sinh viên muốn xoá: ");
					string ten = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].Ten == ten)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau+1, 100, ConsoleColor.Green);
					Console.WriteLine($"\nĐã xóa {dem} sinh viên có tên {ten}");
					Console.ReadKey();
				}
				else if (luaChon == "2")
				{
					Console.Write("Nhập mã số sinh viên của sinh viên muốn xoá: ");
					string mssv = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].MaSoSinhVien == mssv)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau+1, 100, ConsoleColor.Green);
					Console.WriteLine($"\nĐã xóa {dem} sinh viên có mã số sinh viên {mssv}");
					Console.ReadKey();
				}
				else if(luaChon == "3")
				{
					Console.Write("Nhập số căn cước công dân của sinh viên muốn xoá: ");
					string cccd = Console.ReadLine();

					int dem = 0;
					int i = 0;

					while (i < DS_SinhVien.Count)
					{
						if (DS_SinhVien[i].SoCanCuocCongDan == cccd)
						{
							DS_SinhVien.RemoveAt(i);
							dem++;
						}
						else
						{
							i++;
						}
					}
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau+1, 100, ConsoleColor.Green);
					Console.WriteLine($"\nĐã xoá {dem} sinh viên có số căn cước công dân {cccd}");
					Console.ReadKey();
				}
				else if (luaChon == "4")
				{
					int index;

					while (true)
					{
						Console.WriteLine("Nhập vào STT của sinh viên muốn xoá trong danh sách: ");
						index = XuLi.laySoNguyenKhongAm();

						if (index == 0 || index > DS_SinhVien.Count)
						{
							Console.ForegroundColor = ConsoleColor.DarkRed;
							Console.WriteLine($"STT phải nằm trong khoảng (1 -> {DS_SinhVien.Count})!");
							HieuUng.cachDongDau += 3;

							Console.ResetColor();
						}
						else
						{
							break;
						}
					}
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);
					DS_SinhVien.RemoveAt(index - 1);
					Console.WriteLine($"\nĐã xóa sinh viên có STT {index} khỏi danh sách!");
					Console.ReadKey();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Nhập sai, vui lòng nhập lại!");
					Console.ResetColor();
					continue;
				}
				break;
			}
		}

		public static void ChinhSuaThongTinSinhVien_3(ref List<IYeuCau> DS_SinhVien)
		{
			HieuUng.cachDongDau = 0;
			Console.Clear();
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Không có sinh viên nào trong danh sách!");
				Console.Write("Nhấn nút bất kì để về MENU chính: ");
				Console.ReadKey();
				return;
			}
			int index;
		
			while (true)
			{
				Console.WriteLine("Nhập vào STT của sinh viên muốn chỉnh sửa thông tin trong danh sách: ");
				index = XuLi.laySoNguyenKhongAm();

				if (index == 0 || index > DS_SinhVien.Count)
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine($"STT phải nằm trong khoảng (1 -> {DS_SinhVien.Count})!");
					Console.ResetColor();
				}
				else
				{
					break;
				}
			}

			bool laSinhVienTrungCap = true;
			if (DS_SinhVien[index- 1] is SinhVienTrungCap) 
			{
				Console.WriteLine("Chỉnh sửa thông tin cho sinh viên trung cấp: ");
			}
			else
			{
				Console.WriteLine("Chỉnh sửa thông tin cho sinh viên cao đẳng: ");
				laSinhVienTrungCap = false;
			}
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("\t1. Tên");
			Console.WriteLine("\t2. Ngày sinh");
			Console.WriteLine("\t3. Giới tính");
			Console.WriteLine("\t4. Quốc tịch");
			Console.WriteLine("\t5. Quê quán");
			Console.WriteLine("\t6. Địa chỉ thường trú");
			Console.WriteLine("\t7. Số căn cước công dân");
			Console.WriteLine("\t8. Mã số sinh viên");
			Console.WriteLine("\t9. Khoá học");
			Console.WriteLine("\t10. Tiền bảo hiểm");
			Console.WriteLine("\t11. Phụ thu");
			// Tuy chinh menu cho 2 loai sinh vien
			if (laSinhVienTrungCap == true)
			{
				Console.WriteLine("\t12. Học phí học kì");
			}
			else
			{
				Console.WriteLine("\t12. Số tín chỉ môn lý thuyết");
				Console.WriteLine("\t13. Đơn giá môn lý thuyết");
				Console.WriteLine("\t14. Số tín chỉ thực hành");
				Console.WriteLine("\t15. Đơn giá môn thực hành");
			}
			Console.ResetColor();

			//Thuc hien chinh sua
			int luaChon;
			while (true)
			{
				Console.Write("\n\tMời chọn => ");
				luaChon = XuLi.laySoNguyenKhongAm();

				if (laSinhVienTrungCap == true)
				{
					if (luaChon == 0 || luaChon > 12)
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.WriteLine("\tLựa chọn phải nằm trong khoảng (1->12) !");
						Console.ResetColor();
						continue;
					}
					else
					{
						break;
					}
				}
				// La sinh vien cao dang
				else
				{
					if (luaChon == 0 || luaChon > 15)
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.WriteLine("\tLựa chọn phải nằm trong khoảng (1->15) ! ");
						Console.ResetColor();
						continue;
					}
					else
					{
						break;
					}
				}
			}

			// ca hai th deu co the lua chon 12
			if (luaChon == 12)
			{
				if (laSinhVienTrungCap == true)
				{
					SinhVienTrungCap sinhVien = (SinhVienTrungCap)DS_SinhVien[index - 1];
					Console.Write("Học phí học kì mới: ");
					sinhVien.HocPhiHocKi = XuLi.LaySoThucKhongAm();
				}
				else
				{
					SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];
					Console.WriteLine();
					Console.Write("Số tín chỉ lý thuyết mới: ");
					sinhVien.SoTinChilyThuyet = XuLi.laySoNguyenKhongAm();
				}
				// hiệu ứng tiến độ
				Console.WriteLine("\nĐã thay đổi thông tin sinh viên!");
				Console.ReadKey();
				return;
			}

			// Danh cho rieng sinh vien cao dang
			if (luaChon > 12)
			{
				SinhVienCaoDang sinhVien = (SinhVienCaoDang)DS_SinhVien[index - 1];

				if (luaChon == 13)
				{
					Console.WriteLine("Đơn giá môn lý thuyết mới : ");
					sinhVien.DonGiaMonLyThuyet = XuLi.LaySoThucKhongAm();
				}
				else if (luaChon == 14)
				{
					Console.WriteLine("Số tín chỉ thực hành mới : ");
					sinhVien.SoTinChiMonThucHanh = XuLi.laySoNguyenKhongAm();
				}
				else if (luaChon == 15)
				{
					Console.WriteLine("Đơn giá môn lý thuyết mới: ");
					sinhVien.DonGiaMonThucHanh = XuLi.LaySoThucKhongAm();
				}
				// hiệu ứng tiến độ
				Console.WriteLine("\nĐã thay đổi thông tin sinh viên!");
				return;
			}

			//Co the gop ca 2 lai su li cac truong hop chon tu 1-11
			SinhVien sv = (SinhVien)DS_SinhVien[index-1];

			if (luaChon == 1)
			{
				Console.Write("Nhập tên mới: ");
				sv.Ten = Console.ReadLine();
			}
			else if (luaChon == 2)
			{
				Console.Write("Nhập ngày sinh mới(dd/MM/yyyy): ");
				sv.NgaySinh = XuLi.layNgayHopLe();
			}
			else if (luaChon == 3)
			{
				Console.Write("Nhập giới tính mới : ");
				sv.GioiTinh = Console.ReadLine();

			}
			else if (luaChon == 4)
			{
				Console.Write("Nhập quốc tịch mới: ");
				sv.QuocTich = Console.ReadLine();

			}
			else if (luaChon == 5)
			{
				Console.WriteLine("Nhập vào quê quán mới: ");
				sv.QueQuan.ThayDoiDiaChi();

			}
			else if (luaChon == 6)
			{
				Console.WriteLine("Nhập địa chỉ thường trú mới: ");
				sv.DiaChiThuongTru.ThayDoiDiaChi();
			}
			else if (luaChon == 7)
			{
				Console.Write("Nhập số căn cước công dân mới: ");
				sv.SoCanCuocCongDan = Console.ReadLine();
			}
			else if (luaChon == 8)
			{
				Console.Write("Nhập mã số sinh viên mới: ");
				sv.MaSoSinhVien = Console.ReadLine();
			}
			else if (luaChon == 9)
			{
				Console.WriteLine("Nhập thông tin khóa học mới: ");
				sv.KhoaHoc.ThayDoiKhoaHoc();
			}
			else if (luaChon == 10)
			{
				Console.Write("Nhập tiền bảo hiểm mới: ");
				sv.TienBaoHiem = XuLi.LaySoThucKhongAm();
			}
			else if (luaChon == 11)
			{
				Console.Write("Nhập phụ thu mới: ");
				sv.PhuThu = XuLi.LaySoThucKhongAm();
			}
			// hiệu ứng tiến độ
			Console.WriteLine("\nĐã thay đổi thông tin sinh viên!");
			Console.ReadKey();
		}

		public static void SapXepDanhSachSinhVien_4(ref List<IYeuCau> DS_SinhVien)
		{
			HieuUng.cachDongDau = 0;

			Console.Clear();
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Không có sinh viên trong danh sách.");
				Console.Write("Ấn một nút bất kì để quay lại màn hình chính : ");
				Console.ReadKey();
				return;
			}

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(" Sắp xếp danh sách:\n");

			Console.WriteLine(" 1. Sắp xếp theo tên");
			Console.WriteLine(" 2. Sắp xếp theo ngày sinh");
			Console.WriteLine(" 3. Sắp xếp theo MSSV");
			Console.WriteLine(" 4. Sắp xếp theo học phí");
			HieuUng.cachDongDau += 6;
			Console.ResetColor();
			while (true)
			{
				Console.Write("Chọn: ");
				HieuUng.cachDongDau++;

				string luaChon = Console.ReadLine();

				if (luaChon == "1")
				{
					for (int i = 0; i < DS_SinhVien.Count; i++)
					{
						for (int j = i+1; j < DS_SinhVien.Count; j++)
						{
							string tenDayDuI = DS_SinhVien[i].Ten.Trim();
							string tenDayDuJ = DS_SinhVien[j].Ten.Trim();

							string tenI = tenDayDuI.Split()[tenDayDuI.Split().Length - 1].ToLower();
							string tenJ = tenDayDuJ.Split()[tenDayDuJ.Split().Length - 1].ToLower();

							if (String.Compare(tenI, tenJ) > 0)
							{
								IYeuCau temp = DS_SinhVien[i];
								DS_SinhVien[i] = DS_SinhVien[j];
								DS_SinhVien[j] = temp;
							}
						}
					}
				}
				else if (luaChon == "2")
				{
					for (int i = 0; i < DS_SinhVien.Count; i++)
					{
						for (int j = i+1; j < DS_SinhVien.Count; j++)
						{
							if (DateTime.Compare(DS_SinhVien[i].NgaySinh, DS_SinhVien[j].NgaySinh) > 0)
							{
								IYeuCau temp = DS_SinhVien[i];
								DS_SinhVien[i] = DS_SinhVien[j];
								DS_SinhVien[j] = temp;
							}
						}
					}
				}
				else if (luaChon == "3")
				{
					for (int i = 0; i < DS_SinhVien.Count-1; i++)
					{
						for (int j = i+1; j < DS_SinhVien.Count; j++)
						{
							string mssvI = DS_SinhVien[i].MaSoSinhVien.Trim();
							string mssvJ = DS_SinhVien[j].MaSoSinhVien.Trim();

							if (String.Compare(mssvI, mssvJ) > 0)
							{
								IYeuCau temp = DS_SinhVien[i];
								DS_SinhVien[i] = DS_SinhVien[j];
								DS_SinhVien[j] = temp;
							}
						}
					}
				}
				else if (luaChon == "4")
				{
					for (int i = 0; i < DS_SinhVien.Count; i++)
					{
						for (int j = i+1; j < DS_SinhVien.Count; j++)
						{
							if (DS_SinhVien[i].tinhTienHocPhi() > DS_SinhVien[j].tinhTienHocPhi())
							{
								IYeuCau temp = DS_SinhVien[i];
								DS_SinhVien[i] = DS_SinhVien[j];
								DS_SinhVien[j] = temp;
							}
						}
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Chọn sai, vui lòng chọn lại!");
					HieuUng.cachDongDau++;

					Console.ResetColor();
					continue;
				}
				// hiệu ứng tiến độ
				HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);
				Console.Write("\nĐã sắp xếp, nhấn nút bất kì để về MENU chính: ");
				Console.ReadKey();
				break;
			}
		}

		public static void XuatDanhSachSV_5(ref List<IYeuCau> DS_SinhVien)
		{
			if (DS_SinhVien.Count == 0)
			{
				Console.WriteLine("Không có sinh viên nào trong danh sách!");
				Console.Write("Ấn nút bất kì để về MENU chính : ");
				Console.ReadKey();
				return;
			}

			HieuUng.ThanhTienDo(3, 17, 100, ConsoleColor.Green);

			string First_Line = "|STT".PadRight(5) + "|Họ và tên".PadRight(20) + "|Giới tính".PadRight(11) + "|Ngày sinh".PadRight(12) + "|MSSV".PadRight(10)
				+ "|Loại sinh viên".PadRight(15) + "|Niên khoá".PadRight(10) + "|Quê quán(tỉnh)".PadRight(20) + "|Tổng học phí(VNĐ)".PadRight(20) + "|";
			string Second_Line = "+----+-------------------+----------+-----------+---------+--------------+---------+-------------------+-------------------+";
			string Record_Line;

			Console.WriteLine();
			Console.WriteLine(Second_Line);
			Console.WriteLine(First_Line);
			Console.WriteLine(Second_Line);
			bool laSV_CaoDang = true;
			int i = 1;
			foreach (IYeuCau SV in DS_SinhVien)
			{
				laSV_CaoDang = SV is SinhVienCaoDang;
				Record_Line = "|" + i.ToString().PadRight(4) + "|" + SV.Ten.PadRight(19) + "|" + SV.GioiTinh.PadRight(10) + "|"
					+ SV.NgaySinh.ToString("dd/MM/yyyy").PadRight(11) + "|" + SV.MaSoSinhVien.PadRight(9) + "|" + (laSV_CaoDang? "Cao đẳng":"Trung cấp").PadRight(14)
					+ "|" + SV.KhoaHoc.TenNienKhoa.PadRight(9) + "|" + SV.QueQuan.Tinh.PadRight(19) + "|" + String.Format("{0:n0}", SV.tinhTienHocPhi()).PadRight(19) + "|";
				Console.WriteLine(Record_Line);
				i++;
			}
			Console.WriteLine(Second_Line);
			Console.Write("\nẤn một nút bất kì để tiếp tục! ");
			Console.ReadKey();
		}

		public static void XuatFileThongTinSV_ChiTiet_sub6(IYeuCau SV)
		{
			string luaChon;
			string Line;
			SinhVien sinhVien = (SinhVien)SV;
			
			File.WriteAllText($"../../../../{SV.MaSoSinhVien}.txt", "", Encoding.UTF8);
			Console.Write("\nBạn có muốn xuất file thông tin sinh viên?(1.Có, 2.Không): "); luaChon = Console.ReadLine();
			if(luaChon == "1")
			{
				Line = "Họ và tên: " + sinhVien.Ten + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt",Line, Encoding.UTF8);
				Line = "Ngày sinh: " + sinhVien.NgaySinh.ToString("dd/mm/yyyy") + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Giới tính: " + sinhVien.GioiTinh + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Quê quán: " + sinhVien.QueQuan.toString() + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "ĐC thường trú: " + sinhVien.DiaChiThuongTru.toString() + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Số CCCD: " + sinhVien.SoCanCuocCongDan + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Mã số sinh viên: " + sinhVien.MaSoSinhVien + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Khóa học: " + sinhVien.KhoaHoc.TenNienKhoa + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Tiền BH: " + sinhVien.TienBaoHiem.ToString() + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				Line = "Phụ thu: " + sinhVien.PhuThu.ToString() + "\n";
				File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);

				if (SV is SinhVienCaoDang)
				{
					SinhVienCaoDang sv = (SinhVienCaoDang)SV;
					Line = "Loại sinh viên: Sinh viên cao đẳng\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);

					Line = "Số tín chỉ môn lý thuyết: " + sv.SoTinChilyThuyet.ToString() + "\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
					Line = "Số tín chỉ môn thực hành: " + sv.SoTinChiMonThucHanh.ToString() + "\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
					Line = "Đơn giá môn lý thuyết: " + sv.DonGiaMonLyThuyet.ToString() + "\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
					Line = "Đơn giá môn thực hành: " + sv.DonGiaMonThucHanh.ToString() + "\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
					Line = "Tổng học phí: " + sv.tinhTienHocPhi().ToString() + "\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);
				}
				else
				{
					Line = "Loại sinh viên: Sinh viên trung cấp\n";
					File.AppendAllText($"../../../../{SV.MaSoSinhVien}.txt", Line, Encoding.UTF8);

					SinhVienTrungCap sv = (SinhVienTrungCap)SV;
					Line = "Học phí học kỳ: " + sv.tinhTienHocPhi().ToString() + "\n";
				}
			}
			if(luaChon == "1")
				Console.WriteLine("Xuất file thông tin sinh viên thành công!");
			return;
		}
		public static void TimKiem_6(List<IYeuCau> DS_SinhVien)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(" Chọn điều kiện muốn tìm kiếm: ");
			Console.WriteLine("\t1. Tìm kiếm theo tên");
			Console.WriteLine("\t2. Tìm kiếm theo mã số sinh viên");
			Console.WriteLine("\t3. Tìm kiếm theo quê quán");
			Console.WriteLine("\t4. Tìm kiếm theo số căn cước công dân");
			HieuUng.cachDongDau = 7;
			Console.ResetColor();

			while (true)
			{
				Console.Write("Chọn: ");
				string input = Console.ReadLine();
				if (input == "1")
				{
					Console.Write("Nhập tên cần tìm: ");
					input = Console.ReadLine();
					// xử lý string
					input = XuLi.chuyenTiengVietKhongDau(input);
					input = input.Trim();
					input = input.ToLower();
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (XuLi.chuyenTiengVietKhongDau(SV.Ten).ToLower().Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "2")
				{
					Console.Write("Nhập MSSV cần tìm: ");
					input = Console.ReadLine();
					input.Trim();
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.MaSoSinhVien.Trim() == input)
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
							XuatFileThongTinSV_ChiTiet_sub6(SV);
						}
					}
					break;
				}
				else if (input == "3")
				{
					Console.Write("Nhập quê quán: ");
					input = Console.ReadLine();
					input = XuLi.chuyenTiengVietKhongDau(input);
					input = input.Trim();
					input = input.ToLower();
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);

					foreach (IYeuCau SV in DS_SinhVien)
					{
						if ((XuLi.chuyenTiengVietKhongDau(SV.QueQuan.toString()).ToLower()).Contains(input))
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else if (input == "4")
				{
					Console.Write("Nhập số căn cước công dân cần tìm: ");
					input = Console.ReadLine();
					input.Trim();
					// hiệu ứng tiến độ
					HieuUng.ThanhTienDo(3, HieuUng.cachDongDau, 100, ConsoleColor.Green);
					foreach (IYeuCau SV in DS_SinhVien)
					{
						if (SV.SoCanCuocCongDan.Trim() == input)
						{
							Console.WriteLine("---");
							Console.WriteLine(SV.xuatThongTinDayDu());
						}
					}
					break;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Chọn không hợp lệ!");
					HieuUng.cachDongDau += 2;

					Console.ResetColor();
					continue;
				}
			}
			Console.Write("\nTìm kiếm hoàn tất, vui lòng nhấn phím bất kì để về MENU chính! ");
			Console.ReadKey();
		}

		public static void SoLuongCacDoiTuong_7()
		{
			Console.Clear();
			HieuUng.ThanhTienDo(3, 0, 100, ConsoleColor.Green);
			Console.WriteLine("Đếm số lượng các đối tượng cùng loại:\n");
			Console.WriteLine($"Địa Chỉ: {DiaChi.DemDiaChi}");
			Console.WriteLine($"Người: {Nguoi.demNguoi}");
			Console.WriteLine($"Khóa học: {KhoaHoc.demKhoaHoc}");
			Console.WriteLine($"Sinh viên: {SinhVien.demSinhVien}");
			Console.WriteLine($"Sinh viên trung cấp: {SinhVienTrungCap.demSinhVienTrungCap}");
			Console.WriteLine($"Sinh viên cao đẳng: {SinhVienCaoDang.demSinhVienCaoDang}");
			Console.Write("Nhấn nút bất kì để về MENU chính! ");
			Console.ReadKey();
		}

		public static void XuatFileDanhSachSV_8(List<IYeuCau> DS_SinhVien)
		{
			string First_Line = "STT" + ",Họ và tên" + ",Giới tính" + ",Ngày sinh" + ",MSSV"
				+ ",Loại sinh viên" + ",Niên khoá" + ",Quê quán(tỉnh)" + ",Tổng học phí(VNĐ)\n";
			string Record_Line;
			bool laSV_CaoDang = true;
			int i = 1;

			File.WriteAllText("../../../../DanhSachSV.csv", First_Line, Encoding.UTF8);

			foreach (IYeuCau SV in DS_SinhVien)
			{
				laSV_CaoDang = SV is SinhVienCaoDang;
				Record_Line = i.ToString() + "," + SV.Ten + "," + SV.GioiTinh + ","
					+ SV.NgaySinh.ToString("dd/MM/yyyy") + "," + SV.MaSoSinhVien + "," + (laSV_CaoDang ? "Cao đẳng" : "Trung cấp")
					+ "," + SV.KhoaHoc.TenNienKhoa + "," + SV.QueQuan.Tinh + "," + SV.tinhTienHocPhi() + "\n";
				File.AppendAllText("../../../../DanhSachSV.csv", Record_Line, Encoding.UTF8);
				i++;
			}
			// hiệu ứng tiến độ
			HieuUng.ThanhTienDo(3, 17, 100, ConsoleColor.Green);
			Console.WriteLine("\nXuất file danh sách thành công!");
			Console.ReadKey();
		}

		static void Main(string[] args)
		{
			//This is the test comment
			Console.OutputEncoding = System.Text.Encoding.Unicode;
			Console.InputEncoding = System.Text.Encoding.Unicode;
			List<IYeuCau> DS_SinhVien = new List<IYeuCau>();
			string luaChon;
			while (true)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine("\n\tCHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN CỦA TRƯỜNG ĐẠI HỌC");

				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("\n\t\t1. Thêm sinh viên vào danh sách");
				Console.WriteLine("\t\t2. Xóa sinh viên khỏi danh sách");
				Console.WriteLine("\t\t3. Chỉnh sửa thông tin sinh viên");
				Console.WriteLine("\t\t4. Sắp xếp danh sách sinh viên");
				Console.WriteLine("\t\t5. In danh sách sinh viên");
				Console.WriteLine("\t\t6. Tìm kiếm sinh viên");
				Console.WriteLine("\t\t7. Số lượng các đối tượng");
				Console.WriteLine("\t\t8. Xuất danh sách ra file");
				Console.WriteLine("\t\t9. Dừng chương trình");
				Console.WriteLine("\n Số lượng sinh viên trong danh sách: " + DS_SinhVien.Count);
				Console.ResetColor();
				Console.Write("\n Nhập lựa chọn: "); luaChon = Console.ReadLine();

				if (luaChon == "1")
					ThemSinhVien_1(ref DS_SinhVien);
				else if (luaChon == "2")	
					XoaSinhVienKhoiDanhSach_2(ref DS_SinhVien);
				else if (luaChon == "3")
					ChinhSuaThongTinSinhVien_3(ref DS_SinhVien);
				else if (luaChon == "4")
					SapXepDanhSachSinhVien_4(ref DS_SinhVien);
				else if (luaChon == "5")
					XuatDanhSachSV_5(ref DS_SinhVien);
				else if (luaChon == "6")
					TimKiem_6(DS_SinhVien);
				else if (luaChon == "7")
					SoLuongCacDoiTuong_7();
				else if (luaChon == "8")
					XuatFileDanhSachSV_8(DS_SinhVien);
				else if (luaChon == "9")
				{
					Console.WriteLine("Đã dừng chương trình.");
					return;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Vui lòng chọn 1 số trong danh sách!");
					Console.Write("Nhấn một phím bất kì để tiếp tục: ");
					Console.ResetColor();
					Console.ReadKey();
					continue;
				}
			}
		}
	}
}