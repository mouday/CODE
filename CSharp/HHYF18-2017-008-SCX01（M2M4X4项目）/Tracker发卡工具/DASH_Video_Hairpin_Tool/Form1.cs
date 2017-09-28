using BHDC.HCMP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using UnicomTool;
namespace DASH_Video_Hairpin_Tool
{
	public class Form1 : Form
	{
		private const string COMM_CONFIG_FILE_PATH = ".\\config\\comm.config";
		private IContainer components = null;
		private Label label2;
		private Button btn_flush;
		private ComboBox cmbReaders;
		private GroupBox GroupBCardReader;
		private GroupBox gpFileConfig;
		private Button BTStart;
		private Button btnPrg;
		private Button btnMCA;
		private TextBox txtPrgPath;
		private TextBox txtMCAPath;
		private OpenFileDialog OpenFileDlgMca;
		private OpenFileDialog OpenFileDlgPrg;
		private RichTextBox TextBResult;
		private CheckBox CheckBFillCard;
		private TextBox TxtBBatch;
		private Label LBBatch;
		private TextBox TxtDsn;
		private Config SetConfig = new Config(".\\config\\comm.config");
		private static PCSC pcscer = new PCSC();
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.label2 = new Label();
			this.btn_flush = new Button();
			this.cmbReaders = new ComboBox();
			this.GroupBCardReader = new GroupBox();
			this.gpFileConfig = new GroupBox();
			this.TxtDsn = new TextBox();
			this.TxtBBatch = new TextBox();
			this.LBBatch = new Label();
			this.CheckBFillCard = new CheckBox();
			this.BTStart = new Button();
			this.btnPrg = new Button();
			this.btnMCA = new Button();
			this.txtPrgPath = new TextBox();
			this.txtMCAPath = new TextBox();
			this.OpenFileDlgMca = new OpenFileDialog();
			this.OpenFileDlgPrg = new OpenFileDialog();
			this.TextBResult = new RichTextBox();
			this.GroupBCardReader.SuspendLayout();
			this.gpFileConfig.SuspendLayout();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label2.Location = new Point(8, 36);
			this.label2.Name = "label2";
			this.label2.Size = new Size(77, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "选择读卡器：";
			this.btn_flush.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.btn_flush.Location = new Point(447, 33);
			this.btn_flush.Name = "btn_flush";
			this.btn_flush.Size = new Size(90, 20);
			this.btn_flush.TabIndex = 9;
			this.btn_flush.Text = "刷新";
			this.btn_flush.UseVisualStyleBackColor = true;
			this.btn_flush.Click += new EventHandler(this.btn_flush_Click);
			this.cmbReaders.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.cmbReaders.FormattingEnabled = true;
			this.cmbReaders.Location = new Point(97, 33);
			this.cmbReaders.Name = "cmbReaders";
			this.cmbReaders.Size = new Size(344, 20);
			this.cmbReaders.TabIndex = 7;
			this.GroupBCardReader.Controls.Add(this.cmbReaders);
			this.GroupBCardReader.Controls.Add(this.label2);
			this.GroupBCardReader.Controls.Add(this.btn_flush);
			this.GroupBCardReader.Location = new Point(4, 1);
			this.GroupBCardReader.Name = "GroupBCardReader";
			this.GroupBCardReader.Size = new Size(557, 73);
			this.GroupBCardReader.TabIndex = 11;
			this.GroupBCardReader.TabStop = false;
			this.GroupBCardReader.Text = "配置读卡器";
			this.gpFileConfig.Controls.Add(this.TxtDsn);
			this.gpFileConfig.Controls.Add(this.TxtBBatch);
			this.gpFileConfig.Controls.Add(this.LBBatch);
			this.gpFileConfig.Controls.Add(this.CheckBFillCard);
			this.gpFileConfig.Controls.Add(this.BTStart);
			this.gpFileConfig.Controls.Add(this.btnPrg);
			this.gpFileConfig.Controls.Add(this.btnMCA);
			this.gpFileConfig.Controls.Add(this.txtPrgPath);
			this.gpFileConfig.Controls.Add(this.txtMCAPath);
			this.gpFileConfig.Location = new Point(4, 80);
			this.gpFileConfig.Name = "gpFileConfig";
			this.gpFileConfig.Size = new Size(557, 118);
			this.gpFileConfig.TabIndex = 12;
			this.gpFileConfig.TabStop = false;
			this.gpFileConfig.Text = "文件配置";
			this.TxtDsn.Location = new Point(347, 18);
			this.TxtDsn.Name = "TxtDsn";
			this.TxtDsn.Size = new Size(190, 21);
			this.TxtDsn.TabIndex = 18;
			this.TxtBBatch.Location = new Point(101, 18);
			this.TxtBBatch.Name = "TxtBBatch";
			this.TxtBBatch.Size = new Size(167, 21);
			this.TxtBBatch.TabIndex = 17;
			this.LBBatch.AutoSize = true;
			this.LBBatch.Location = new Point(21, 24);
			this.LBBatch.Name = "LBBatch";
			this.LBBatch.Size = new Size(53, 12);
			this.LBBatch.TabIndex = 16;
			this.LBBatch.Text = "批次号：";
			this.CheckBFillCard.AutoSize = true;
			this.CheckBFillCard.Location = new Point(293, 20);
			this.CheckBFillCard.Name = "CheckBFillCard";
			this.CheckBFillCard.Size = new Size(48, 16);
			this.CheckBFillCard.TabIndex = 15;
			this.CheckBFillCard.Text = "补卡";
			this.CheckBFillCard.UseVisualStyleBackColor = true;
			this.CheckBFillCard.CheckedChanged += new EventHandler(this.CheckBFillCard_CheckedChanged);
			this.BTStart.Location = new Point(489, 53);
			this.BTStart.Name = "BTStart";
			this.BTStart.Size = new Size(60, 56);
			this.BTStart.TabIndex = 14;
			this.BTStart.Text = "开始";
			this.BTStart.UseVisualStyleBackColor = true;
			this.BTStart.Click += new EventHandler(this.BTStart_Click);
			this.btnPrg.Location = new Point(10, 84);
			this.btnPrg.Name = "btnPrg";
			this.btnPrg.Size = new Size(79, 25);
			this.btnPrg.TabIndex = 4;
			this.btnPrg.Text = "Prg文件";
			this.btnPrg.UseVisualStyleBackColor = true;
			this.btnPrg.Click += new EventHandler(this.btnPrg_Click);
			this.btnMCA.Location = new Point(10, 53);
			this.btnMCA.Name = "btnMCA";
			this.btnMCA.Size = new Size(79, 23);
			this.btnMCA.TabIndex = 4;
			this.btnMCA.Text = "MCA数据文件";
			this.btnMCA.UseVisualStyleBackColor = true;
			this.btnMCA.Click += new EventHandler(this.btnMCA_Click);
			this.txtPrgPath.Location = new Point(101, 88);
			this.txtPrgPath.Name = "txtPrgPath";
			this.txtPrgPath.Size = new Size(370, 21);
			this.txtPrgPath.TabIndex = 3;
			this.txtMCAPath.Location = new Point(101, 53);
			this.txtMCAPath.Name = "txtMCAPath";
			this.txtMCAPath.Size = new Size(370, 21);
			this.txtMCAPath.TabIndex = 3;
			this.TextBResult.Font = new Font("宋体", 18f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.TextBResult.Location = new Point(4, 217);
			this.TextBResult.Name = "TextBResult";
			this.TextBResult.Size = new Size(557, 133);
			this.TextBResult.TabIndex = 14;
			this.TextBResult.Text = "";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(565, 357);
			base.Controls.Add(this.TextBResult);
			base.Controls.Add(this.gpFileConfig);
			base.Controls.Add(this.GroupBCardReader);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "Form1";
			this.Text = "植保无人机身份识别定位设备发卡工具170629";
			base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
			this.GroupBCardReader.ResumeLayout(false);
			this.GroupBCardReader.PerformLayout();
			this.gpFileConfig.ResumeLayout(false);
			this.gpFileConfig.PerformLayout();
			base.ResumeLayout(false);
		}
		public Form1()
		{
			this.InitializeComponent();
			this.AddMode("", true);
		}
		private void btn_flush_Click(object sender, EventArgs e)
		{
			this.cmbReaders.Items.Clear();
			this.GetListOfReaders();
		}
		private void GetListOfReaders()
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			string text = "";
			int num = 1;
			long num2 = Form1.pcscer.PCSCListOfReader(stringBuilder);
			for (int i = 0; i < stringBuilder.Length; i++)
			{
				char c = stringBuilder[i];
				if (c == ',')
				{
					if (num == 1)
					{
						publicConst.hhcardname1 = text;
						num++;
					}
					else
					{
						publicConst.hhcardname2 = text;
					}
					this.cmbReaders.Items.Add(text);
					text = "";
				}
				else
				{
					text += c.ToString();
				}
			}
			if (this.cmbReaders.Items.Count != 0)
			{
				try
				{
					this.cmbReaders.SelectedIndex = 0;
					PCSC.ReaderN = this.cmbReaders.SelectedIndex + 1;
				}
				catch
				{
					MessageBox.Show("读卡器选择错误");
				}
			}
			else
			{
				this.cmbReaders.Text = "";
			}
		}
		private void btnMCA_Click(object sender, EventArgs e)
		{
			this.OpenFileDlgMca.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			this.OpenFileDlgMca.Multiselect = true;
			this.OpenFileDlgMca.Title = "选择ICCID文件";
			this.OpenFileDlgMca.Filter = "打开MCA文件(*.mca)|*.mca|所有文件(*.*)|*.*";
			this.txtMCAPath.Text = "";
			if (this.OpenFileDlgMca.ShowDialog() == DialogResult.OK)
			{
				this.txtMCAPath.Text = this.OpenFileDlgMca.FileName;
			}
		}
		private void btnPrg_Click(object sender, EventArgs e)
		{
			this.OpenFileDlgPrg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			this.OpenFileDlgPrg.Multiselect = true;
			this.OpenFileDlgPrg.Title = "选择PRG脚本文件";
			this.OpenFileDlgPrg.Filter = "打开prg文件(*.prg)|*.prg|所有文件(*.*)|*.*";
			this.txtPrgPath.Text = "";
			if (this.OpenFileDlgPrg.ShowDialog() == DialogResult.OK)
			{
				this.txtPrgPath.Text = this.OpenFileDlgPrg.FileName;
			}
		}
		private void BTStart_Click(object sender, EventArgs e)
		{
			if (this.CheckBFillCard.Checked && this.TxtDsn.Text == "")
			{
				MessageBox.Show("请填写需要补卡DSN！！");
			}
			else
			{
				if (this.txtMCAPath.Text == "" || !File.Exists(this.txtMCAPath.Text))
				{
					MessageBox.Show("请选择MCA文件！！");
				}
				else
				{
					if (this.txtPrgPath.Text == "" || !File.Exists(this.txtPrgPath.Text))
					{
						MessageBox.Show("请选择prg脚本！！");
					}
					else
					{
						if (!(this.BTStart.Text == "停止"))
						{
							if (this.cmbReaders.Text == "")
							{
								MessageBox.Show("请选择读卡器！！");
								return;
							}
							short num = 0;
							string empty = string.Empty;
							Form1.pcscer.Reader_OpenPort();
							Form1.pcscer.Reader_CardReset(publicConst.hhcard1, ref num, ref empty, publicConst.hhcardname1);
							if (num != 0)
							{
								MessageBox.Show("读卡器复位失败！！");
								return;
							}
							string path = AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "");
							if (!Directory.Exists(path))
							{
								Directory.CreateDirectory(path);
							}
							if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt"))
							{
								StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt", false, Encoding.Default);
								streamWriter.WriteLine("发卡起始DSN为:FFFFFFFFFFFF");
								streamWriter.Close();
								DialogResult dialogResult = MessageBox.Show("确定为新数据，从第一行发卡？？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
								if (dialogResult == DialogResult.No)
								{
									return;
								}
							}
							string filePath = AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\FailLog.log";
							string filePath2 = AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\Log.log";
							string filePath3 = AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\FillLog.log";
							Application.DoEvents();
							bool flag = true;
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							string text = string.Empty;
							string empty2 = string.Empty;
							try
							{
								while (true)
								{
									long num2 = Form1.pcscer.Reader_OpenPort();
									if (num2 == 0L)
									{
										this.TextBResult.BackColor = Color.Yellow;
										this.TextBResult.Text = "------发卡中，请勿拔卡------";
										this.BTStart.Text = "停止";
										Application.DoEvents();
										Application.DoEvents();
										text = "";
										if (flag)
										{
											dictionary.Clear();
											if (this.CheckBFillCard.Checked)
											{
												dictionary = this.GetFillMcaData(this.txtMCAPath.Text, this.TxtDsn.Text.Trim());
											}
											else
											{
												dictionary = this.GetMcaData(this.txtMCAPath.Text, ref empty2);
											}
											if (dictionary == null)
											{
												break;
											}
										}
										foreach (string current in dictionary.Keys)
										{
											text = text + dictionary[current] + ",";
										}
										int num3 = this.HairpinWriteData(dictionary, this.txtPrgPath.Text);
										if (num3 != 0)
										{
											if (num3 == -5)
											{
												goto Block_22;
											}
											flag = false;
										}
										else
										{
											string str = "";
											int indexDsn = 0;
											int num4 = 0;
											foreach (string current in dictionary.Keys)
											{
												if (current.Length > 8)
												{
													if (current.Substring(0, 8) == "打印数据")
													{
														str = str + dictionary[current] + ",";
													}
												}
												if (current == "DSN")
												{
													indexDsn = num4;
												}
												num4++;
											}
											if (!this.CheckBFillCard.Checked)
											{
												this.WriteDSNFile(empty2, indexDsn);
											}
											this.TextBResult.BackColor = Color.Green;
											this.TextBResult.Text = "发卡成功：";
											this.TextBResult.Text = this.TextBResult.Text + "\n\r" + dictionary["DSN"];
											this.BTStart.Text = "开始";
											Application.DoEvents();
											int num5;
											if (!this.CheckBFillCard.Checked)
											{
												num5 = this.WriteToLog(filePath2, dictionary["DSN"] + ":发卡成功," + DateTime.Now.ToString(), true);
											}
											else
											{
												num5 = this.WriteToLog(filePath3, dictionary["DSN"] + ":补卡成功," + DateTime.Now.ToString(), true);
											}
											if (num5 != 0)
											{
												break;
											}
											if (empty2 == null)
											{
												goto Block_27;
											}
										}
										long num7;
										do
										{
											short num6 = 0;
											string text2 = "";
											num7 = (long)Form1.pcscer.Reader_CardReset(ref num6, ref text2);
										}
										while (num7 == 0L);
									}
								}
								goto IL_6F1;
								Block_22:
								this.WriteToLog(filePath, "发卡失败:" + text.Trim(new char[]
								{
									','
								}), false);
								goto IL_6F1;
								Block_27:
								MessageBox.Show("MCA文件数据使用完毕！！");
								return;
							}
							catch (Exception ex)
							{
								MessageBox.Show("发卡失败！" + ex.Message);
							}
							finally
							{
							}
						}
						IL_6F1:
						this.BTStart.Text = "开始";
						this.TextBResult.BackColor = Color.White;
						this.TextBResult.Text = "";
					}
				}
			}
		}
		public string AsynSend(Socket socket, string message)
		{
			string result;
			if (socket == null || message == string.Empty)
			{
				result = null;
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(message);
				string text = null;
				try
				{
					byte[] bytes2 = Encoding.ASCII.GetBytes(message);
					byte[] array = new byte[bytes2.Length + 2];
					array[0] = 2;
					for (int i = 0; i < bytes2.Length; i++)
					{
						array[i + 1] = bytes2[i];
					}
					array[bytes2.Length + 1] = 3;
					socket.Send(array);
					int count = socket.Receive(bytes);
					text = Encoding.ASCII.GetString(bytes, 0, count);
					MessageBox.Show("返回数据为：" + text);
				}
				catch (Exception ex)
				{
					MessageBox.Show("发送消息出现异常！", ex.Message);
					result = null;
					return result;
				}
				finally
				{
				}
				result = text;
			}
			return result;
		}
		private int AddMode(string strD, bool IfAdd)
		{
			int result = 0;
			bool flag = true;
			try
			{
				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini"))
				{
					StreamReader streamReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini", Encoding.Default);
					for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
					{
						if (text.Trim() != "")
						{
							if (text.Trim() == strD)
							{
								flag = false;
							}
						}
					}
					streamReader.Close();
				}
				if (flag && strD.Trim() != "")
				{
					StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "PrintCf.ini", true, Encoding.Default);
					streamWriter.WriteLine(strD.Trim());
					streamWriter.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("加入打印模板失败！" + ex.Message);
				result = -1;
			}
			finally
			{
			}
			return result;
		}
		public static string Ascii2Str(string strD)
		{
			if (strD.Length % 2 != 0)
			{
				throw new Exception(strD + "长度不正确");
			}
			string text = "";
			for (int i = 0; i < strD.Length / 2; i++)
			{
				int num = Convert.ToInt32(strD.Substring(i * 2, 2), 16);
				if (num < 0 || num > 255)
				{
					throw new Exception("ASCII Code is not valid.");
				}
				ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
				byte[] bytes = new byte[]
				{
					(byte)num
				};
				string @string = aSCIIEncoding.GetString(bytes);
				text += @string;
			}
			return text;
		}
		private int HairpinWriteData(Dictionary<string, string> DicData, string FilePath)
		{
			int num = 0;
			short num2 = 0;
			string text = "";
			long num3 = (long)Form1.pcscer.Reader_CardReset(ref num2, ref text);
			int result;
			if (num3 != 0L)
			{
				MessageBox.Show("复位失败！！");
				this.TextBResult.BackColor = Color.Red;
				this.TextBResult.Text = "----------卡片复位失败------------";
				this.BTStart.Text = "开始";
				Application.DoEvents();
				result = -1;
			}
			else
			{
				StreamReader streamReader = new StreamReader(FilePath);
				string text2 = streamReader.ReadLine();
				try
				{
					while (text2 != null)
					{
						text2 = text2.Replace(" ", "");
						if (text2 == "")
						{
							text2 = streamReader.ReadLine();
						}
						else
						{
							string text3 = "";
							string str = "";
							while (text2.IndexOf("<") > 0)
							{
								str = text2.Substring(0, text2.IndexOf("<"));
								text3 = text2.Substring(text2.IndexOf("<") + 1, text2.IndexOf(">") - text2.IndexOf("<") - 1);
								if (!DicData.ContainsKey(text3))
								{
									MessageBox.Show(text3 + "数据中无此变量数据！！");
									this.TextBResult.BackColor = Color.Red;
									this.TextBResult.Text = "------数据和脚本不匹配------------";
									this.BTStart.Text = "开始";
									streamReader.Close();
									Application.DoEvents();
									result = -5;
									return result;
								}
								if (text3 == "DATAN")
								{
									string str2 = (DicData[text3].Length / 2).ToString("X2");
									text2 = text2.Replace("<" + text3 + ">", str2 + DicData[text3]);
								}
								else
								{
									text2 = text2.Replace("<" + text3 + ">", DicData[text3]);
								}
							}
							string text4 = text2.Substring(0, text2.IndexOf("SW"));
							string text5 = text2.Substring(text2.IndexOf("SW") + 2);
							string b = text5;
							string text6 = "";
							if (text5.IndexOf("RESULT") > 0)
							{
								b = text5.Substring(0, text5.IndexOf("RESULT"));
								text6 = text5.Substring(text5.IndexOf("RESULT") + 6);
							}
							string empty = string.Empty;
							string empty2 = string.Empty;
							if (text4 == "0012000000")
							{
								num3 = (long)Form1.pcscer.Reader_CardReset(ref num2, ref text);
								if (num3 != 0L)
								{
									MessageBox.Show("复位失败！！");
									this.TextBResult.BackColor = Color.Red;
									this.TextBResult.Text = "-----------卡片复位失败------------";
									this.BTStart.Text = "开始";
									streamReader.Close();
									Application.DoEvents();
									result = -1;
									return result;
								}
								if (text6 != "")
								{
									if (text6 != text)
									{
										MessageBox.Show("复位失败！！" + text);
										this.TextBResult.BackColor = Color.Red;
										this.TextBResult.Text = "-----------卡片复位失败------------";
										this.BTStart.Text = "开始";
										streamReader.Close();
										Application.DoEvents();
										result = -1;
										return result;
									}
								}
							}
							else
							{
								long num4 = (long)Form1.pcscer.Reader_SendCommand(ref text4, ref empty, ref empty2);
								if (num4 < 0L)
								{
									MessageBox.Show(text4 + "发卡失败！！");
									goto IL_5A6;
								}
								if (empty2 != b)
								{
									MessageBox.Show(text4 + "发卡失败！！");
									goto IL_5A6;
								}
								if (empty != "" && text4 != "80BB000002")
								{
									if (empty != text6)
									{
										MessageBox.Show(text4 + "发卡失败！！");
										goto IL_5A6;
									}
								}
								if (text3 == "DATA0")
								{
									int num5 = 1;
									while (DicData.ContainsKey("DATA" + num5.ToString()))
									{
										text4 = str + DicData["DATA" + num5.ToString()];
										num4 = (long)Form1.pcscer.Reader_SendCommand(ref text4, ref empty, ref empty2);
										if (num4 < 0L)
										{
											MessageBox.Show(text4 + "发卡失败！！");
											goto IL_5A6;
										}
										if (empty2 != b)
										{
											MessageBox.Show(text4 + "发卡失败！！");
											goto IL_5A6;
										}
										num5++;
									}
								}
							}
							text2 = streamReader.ReadLine();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					goto IL_5A6;
				}
				finally
				{
					streamReader.Close();
				}
				result = num;
				return result;
				IL_5A6:
				streamReader.Close();
				this.TextBResult.BackColor = Color.Red;
				this.TextBResult.Text = "----------发卡失败----------";
				this.BTStart.Text = "开始";
				Application.DoEvents();
				this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\FailLog.log", "发卡失败:" + DicData["DSN"] + "--" + text2, false);
				result = -1;
			}
			return result;
		}
		private int WriteToLog(string FilePath, string strT, bool IfRepeat)
		{
			int result;
			if (!this.CheckBFillCard.Checked)
			{
				if (IfRepeat && strT != "")
				{
					if (File.Exists(FilePath))
					{
						StreamReader streamReader = new StreamReader(FilePath);
						for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
						{
							if (text.Trim() != "")
							{
								if (text.Split(new char[]
								{
									':'
								})[0] == strT.Split(new char[]
								{
									':'
								})[0])
								{
									MessageBox.Show(strT.Split(new char[]
									{
										':'
									})[0] + "重复发卡！！");
									streamReader.Close();
									this.WriteToLog(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\FailLog.log", "重复发卡:" + strT.Split(new char[]
									{
										':'
									})[0], false);
									this.WriteDSNFile(null, 0);
									result = -1;
									return result;
								}
							}
						}
						streamReader.Close();
					}
				}
			}
			StreamWriter streamWriter = new StreamWriter(FilePath, true, Encoding.Default);
			streamWriter.WriteLine(strT);
			streamWriter.Close();
			result = 0;
			return result;
		}
		private Dictionary<string, string> GetFillMcaData(string FilePath, string strDsn)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			StreamReader streamReader = new StreamReader(this.txtMCAPath.Text, Encoding.Default);
			string text = streamReader.ReadLine();
			string text2 = streamReader.ReadLine();
			Dictionary<string, string> result;
			try
			{
				if (text2.Trim() == "")
				{
					MessageBox.Show("MCA文件有空行！");
					streamReader.Close();
					result = null;
					return result;
				}
				if (text.Split(new char[]
				{
					','
				}).Length != text2.Split(new char[]
				{
					','
				}).Length)
				{
					MessageBox.Show("MCA数据表头和数据不对应！");
					streamReader.Close();
					result = null;
					return result;
				}
				int num = -1;
				int num2 = -1;
				bool flag = false;
				for (int i = 0; i < text.Split(new char[]
				{
					','
				}).Length; i++)
				{
					if (text.Split(new char[]
					{
						','
					})[i] == "DSN")
					{
						flag = true;
						num = i;
					}
				}
				if (!flag)
				{
					MessageBox.Show("MCA数据表头无DSN！");
					streamReader.Close();
					result = null;
					return result;
				}
				while (text2 != null)
				{
					if (text2.Trim() != "")
					{
						if (text2.Split(new char[]
						{
							','
						})[num] == strDsn)
						{
							for (int i = 0; i < text.Split(new char[]
							{
								','
							}).Length; i++)
							{
								if (num2 == i)
								{
									for (int j = 0; j < text2.Split(new char[]
									{
										','
									})[i].Length / 510; j++)
									{
										dictionary.Add("DATA" + j.ToString(), text2.Split(new char[]
										{
											','
										})[i].Substring(j * 510, 510));
									}
									dictionary.Add("DATAN", text2.Split(new char[]
									{
										','
									})[i].Substring(text2.Split(new char[]
									{
										','
									})[i].Length - text2.Split(new char[]
									{
										','
									})[i].Length % 510));
								}
								else
								{
									dictionary.Add(text.Split(new char[]
									{
										','
									})[i], text2.Split(new char[]
									{
										','
									})[i]);
								}
							}
							break;
						}
					}
					text2 = streamReader.ReadLine();
				}
			}
			catch (Exception var_10_324)
			{
				MessageBox.Show("MCA数据获取失败！");
				streamReader.Close();
				result = null;
				return result;
			}
			finally
			{
				streamReader.Close();
			}
			if (dictionary.Count == 0)
			{
				MessageBox.Show("获取数据失败，无对应DSN的数据！");
				result = null;
			}
			else
			{
				result = dictionary;
			}
			return result;
		}
		private Dictionary<string, string> GetMcaData(string FilePath, ref string strNextData)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			StreamReader streamReader = new StreamReader(this.txtMCAPath.Text, Encoding.Default);
			StreamReader streamReader2 = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt", Encoding.Default);
			Dictionary<string, string> result;
			try
			{
				string text = streamReader2.ReadLine();
				if (text == null)
				{
					MessageBox.Show("DSN记录文件为空！");
					streamReader.Close();
					streamReader2.Close();
					result = null;
					return result;
				}
				if (text.Trim() == "" || text.IndexOf(":") <= 0)
				{
					MessageBox.Show("DSN记录文件格式不正确！");
					streamReader.Close();
					streamReader2.Close();
					result = null;
					return result;
				}
				text = text.Trim().Split(new char[]
				{
					':'
				})[1].Trim();
				string text2 = streamReader.ReadLine();
				string text3 = streamReader.ReadLine();
				if (text3.Trim() == "")
				{
					MessageBox.Show("MCA文件有空行！");
					streamReader.Close();
					streamReader2.Close();
					result = null;
					return result;
				}
				if (text2.Split(new char[]
				{
					','
				}).Length != text3.Split(new char[]
				{
					','
				}).Length)
				{
					MessageBox.Show("MCA数据表头和数据不对应！");
					streamReader.Close();
					streamReader2.Close();
					result = null;
					return result;
				}
				int num = -1;
				int num2 = -1;
				bool flag = false;
				for (int i = 0; i < text2.Split(new char[]
				{
					','
				}).Length; i++)
				{
					if (text2.Split(new char[]
					{
						','
					})[i] == "DSN")
					{
						flag = true;
						num = i;
					}
				}
				if (!flag)
				{
					MessageBox.Show("MCA数据表头无DSN！");
					streamReader.Close();
					streamReader2.Close();
					result = null;
					return result;
				}
				if (text == "FFFFFFFFFFFF")
				{
					for (int i = 0; i < text2.Split(new char[]
					{
						','
					}).Length; i++)
					{
						if (num2 == i)
						{
							for (int j = 0; j < text3.Split(new char[]
							{
								','
							})[i].Length / 510; j++)
							{
								dictionary.Add("DATA" + j.ToString(), text3.Split(new char[]
								{
									','
								})[i].Substring(j * 510, 510));
							}
							dictionary.Add("DATAN", text3.Split(new char[]
							{
								','
							})[i].Substring(text3.Split(new char[]
							{
								','
							})[i].Length - text3.Split(new char[]
							{
								','
							})[i].Length % 510));
						}
						else
						{
							dictionary.Add(text2.Split(new char[]
							{
								','
							})[i], text3.Split(new char[]
							{
								','
							})[i]);
						}
					}
					strNextData = streamReader.ReadLine();
				}
				else
				{
					while (text3 != null)
					{
						if (text3.Trim() != "")
						{
							if (text3.Split(new char[]
							{
								','
							})[num] == text)
							{
								for (int i = 0; i < text2.Split(new char[]
								{
									','
								}).Length; i++)
								{
									if (num2 == i)
									{
										for (int j = 0; j < text3.Split(new char[]
										{
											','
										})[i].Length / 510; j++)
										{
											dictionary.Add("DATA" + j.ToString(), text3.Split(new char[]
											{
												','
											})[i].Substring(j * 510, 510));
										}
										dictionary.Add("DATAN", text3.Split(new char[]
										{
											','
										})[i].Substring(text3.Split(new char[]
										{
											','
										})[i].Length - text3.Split(new char[]
										{
											','
										})[i].Length % 510));
									}
									else
									{
										dictionary.Add(text2.Split(new char[]
										{
											','
										})[i], text3.Split(new char[]
										{
											','
										})[i]);
									}
								}
								strNextData = streamReader.ReadLine();
								break;
							}
						}
						text3 = streamReader.ReadLine();
					}
				}
			}
			catch (Exception var_12_5D2)
			{
				MessageBox.Show("MCA数据获取失败！");
				streamReader.Close();
				streamReader2.Close();
				result = null;
				return result;
			}
			finally
			{
				streamReader.Close();
				streamReader2.Close();
			}
			if (dictionary.Count == 0)
			{
				MessageBox.Show("获取数据失败，无对应DSN的数据！");
				result = null;
			}
			else
			{
				result = dictionary;
			}
			return result;
		}
		private void WriteDSNFile(string strDsn, int IndexDsn)
		{
			StreamReader streamReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt", Encoding.Default);
			if (strDsn == null)
			{
				strDsn = "FFFFFFFFFFFF";
			}
			else
			{
				if (strDsn.Trim() == "")
				{
					strDsn = "FFFFFFFFFFFF";
				}
				else
				{
					strDsn = strDsn.Trim().Split(new char[]
					{
						','
					})[IndexDsn];
				}
			}
			try
			{
				string str = streamReader.ReadLine().Trim().Split(new char[]
				{
					':'
				})[0];
				streamReader.Close();
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt");
				StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this.TxtBBatch.Text.Replace(" ", "") + "\\DSNstart.txt", false, Encoding.Default);
				streamWriter.WriteLine(str + ":" + strDsn.Trim());
				streamWriter.Close();
			}
			catch
			{
				streamReader.Close();
				throw new Exception("记录DSN值失败！！");
			}
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
		private void CheckBFillCard_CheckedChanged(object sender, EventArgs e)
		{
			if (this.CheckBFillCard.Checked)
			{
				this.TxtDsn.Visible = true;
			}
			else
			{
				this.TxtDsn.Visible = false;
				this.TxtDsn.Text = "";
			}
		}
	}
}
