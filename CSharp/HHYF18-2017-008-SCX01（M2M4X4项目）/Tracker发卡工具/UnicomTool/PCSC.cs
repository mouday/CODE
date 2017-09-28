using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace UnicomTool
{
	internal class PCSC
	{
		public static string ReaderType;
		public static long MWicdev;
		public static long PortSpeed;
		public static string Port;
		public static int ReaderN;
		[DllImport("Crwicc.dll")]
		public static extern long TripleDESVB(long DESType, string TripleDESKey, int SourDataLen, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern long PCSCListReader(StringBuilder Readers);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_Connect(int NofReaders);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_CardReset(byte[] ATR, ref short ATRlen);
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_SendCommand(byte[] Comm, int Lens, byte[] Resp, ref int Lenr);
		[DllImport("PCSCReader.dll")]
		public static extern long PCSC_Close();
		[DllImport("PCSCReader.dll")]
		public static extern int PCSC_CardReset_Ex(uint hhCard, byte[] ATR, ref short ATRlen, string hhcardname);
		[DllImport("PCSCReader.dll")]
		public static extern int BinToHexStr(string HexStr, string BinData, int BinLen);
		[DllImport("PCSCReader.dll")]
		public static extern int HexStrToBin(string BinData, string HexStr, int HexStrLen);
		[DllImport("PCSCReader.dll")]
		public static extern int SingleDESECB(int DESType, string SingleDESKey, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int TriDESECB(int DESType, string TriDESKey, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int SingleMACCBC(int MACKey, string InitData, int SourDataType, string SourData, string DestData);
		[DllImport("PCSCReader.dll")]
		public static extern int TriMACCBC(int MACKey, string InitData, int SourDataType, string SourData, string DestData);
		[DllImport("MCS_SR")]
		public static extern int CPU_OpenCard(string bATR, int wATRLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_CloseCard();
		[DllImport("MCS_SR")]
		public static extern int CPU_Reset(string bATR, int wATRLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_IsoAPDU(string bCommand, int wCmdLength, string bResponse, int wRespLength);
		[DllImport("MCS_SR")]
		public static extern int CPU_GetProtocol(byte bProtocol);
		[DllImport("MCS_SR")]
		public static extern int MCS_InitComm(byte bPort, long dwCommBaudRate);
		[DllImport("MCS_SR")]
		public static extern int MCS_ExitComm();
		[DllImport("MCS_SR")]
		public static extern int MCS_GetVersion(string bVersion);
		[DllImport("MCS_SR")]
		public static extern int MCS_TestDevice();
		[DllImport("MCS_SR")]
		public static extern int MCS_TestDoor();
		[DllImport("MCS_SR")]
		public static extern int MCS_LED(byte bOnOff);
		[DllImport("MCS_SR")]
		public static extern int MCS_Buzzer(byte bOnOff);
		[DllImport("MCS_SR")]
		public static extern int MCS_SetStringMode(byte bStringMode);
		[DllImport("kernel32")]
		public static extern long GetTickCount();
		[DllImport("WibAlgrithm.dll")]
		public static extern long GetSupperAdmin(string strSourceData, byte[] strOutData);
		public long Reader_OpenPort()
		{
			PCSC.PortSpeed = 115200L;
			int num = PCSC.PCSC_Connect(PCSC.ReaderN);
			long result;
			if (num != 0)
			{
				result = -1L;
			}
			else
			{
				result = 0L;
			}
			return result;
		}
		public long PCSCListOfReader(StringBuilder Readers)
		{
			return PCSC.PCSCListReader(Readers);
		}
		public long Reader_CardReset(uint hhcard, ref short intReslen, ref string strRes, string hhcardname)
		{
			byte[] array = new byte[600];
			strRes = "";
			int num = PCSC.PCSC_CardReset_Ex(hhcard, array, ref intReslen, hhcardname);
			strRes = Encoding.ASCII.GetString(array);
			long result;
			if (num != 0)
			{
				result = 1L;
			}
			else
			{
				result = (long)num;
			}
			return result;
		}
		public int Reader_CardReset(ref short intReslen, ref string strRes)
		{
			byte[] array = new byte[600];
			int num = PCSC.PCSC_Connect(PCSC.ReaderN);
			strRes = "";
			int result;
			if (num != 0)
			{
				result = -1;
			}
			else
			{
				try
				{
					num = PCSC.PCSC_CardReset(array, ref intReslen);
				}
				catch (Exception var_3_3A)
				{
					result = 0;
					return result;
				}
				if (num != 0)
				{
					result = -3;
				}
				else
				{
					strRes = Encoding.ASCII.GetString(array, 0, (int)(intReslen * 2));
					result = 0;
				}
			}
			return result;
		}
		public int Reader_SendCommand(ref string strCmd, ref string strRes, ref string strSW)
		{
			byte[] array = new byte[600];
			int num = 0;
			byte[] bytes = Encoding.Default.GetBytes(strCmd);
			int lens = int.Parse((strCmd.Length / 2).ToString());
			int num2 = PCSC.PCSC_SendCommand(bytes, lens, array, ref num);
			int num3 = num;
			short num4 = 0;
			while ((int)num4 < num3 * 2)
			{
				strRes += (char)array[(int)num4];
				num4 += 1;
			}
			strSW = num2.ToString("X");
			strSW = strSW.ToUpper();
			int result;
			if (num2 < 0)
			{
				result = num2;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		public void Reader_ClosePort()
		{
			PCSC.PCSC_Close();
		}
		public void TimeD(long lngTD)
		{
			long tickCount = PCSC.GetTickCount();
			long num;
			do
			{
				Application.DoEvents();
				if (PCSC.GetTickCount() - tickCount < 0L)
				{
					tickCount = PCSC.GetTickCount();
				}
				num = PCSC.GetTickCount() - tickCount;
			}
			while (num >= lngTD);
		}
		public long HexToDec(string strS)
		{
			int length = strS.Length;
			long num = 0L;
			long num2 = 0L;
			byte[] array = new byte[1];
			int i = 1;
			while (i < length + 1)
			{
				string text = strS.Substring(i, 1);
				string text2 = text;
				switch (text2)
				{
				case "0":
					num = 0L;
					break;
				case "1":
					num = 1L;
					break;
				case "2":
					num = 2L;
					break;
				case "3":
					num = 3L;
					break;
				case "4":
					num = 4L;
					break;
				case "5":
					num = 5L;
					break;
				case "6":
					num = 6L;
					break;
				case "7":
					num = 7L;
					break;
				case "8":
					num = 8L;
					break;
				case "9":
					num = 9L;
					break;
				case "a":
					num = 10L;
					break;
				case "A":
					num = 10L;
					break;
				case "b":
					num = 11L;
					break;
				case "B":
					num = 11L;
					break;
				case "c":
					num = 12L;
					break;
				case "C":
					num = 12L;
					break;
				case "d":
					num = 13L;
					break;
				case "D":
					num = 13L;
					break;
				case "e":
					num = 14L;
					break;
				case "E":
					num = 14L;
					break;
				case "f":
					num = 15L;
					break;
				case "F":
					num = 15L;
					break;
				}
				IL_25B:
				array = Encoding.ASCII.GetBytes(text);
				int num4 = (int)array[0];
				if ((num4 <= 57 && num4 >= 48) || (num4 <= 65 && num4 >= 70) || (num4 <= 102 && num4 >= 97))
				{
					if (text != "0")
					{
						if (i < length)
						{
							for (int j = 1; j <= length - 1; j++)
							{
								num *= 16L;
							}
							num2 += num;
						}
						if (i == length)
						{
							num2 += num;
						}
					}
				}
				i++;
				continue;
				goto IL_25B;
			}
			return num2;
		}
	}
}
