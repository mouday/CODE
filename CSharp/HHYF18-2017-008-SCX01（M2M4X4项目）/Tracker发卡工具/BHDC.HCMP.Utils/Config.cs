using System;
using System.Xml;
namespace BHDC.HCMP.Utils
{
	public class Config
	{
		private const string VALIDFLAG = "<add";
		private const string KEY = "key";
		private const string VALUE = "value";
		private int lenOFValidFlag = "<add".Length;
		private string _fullFileName;
		private string _configFileSavePath = AppDomain.CurrentDomain.BaseDirectory.ToString();
		private XmlDocument xmlDoc = null;
		public Config(string strFileName)
		{
			this._fullFileName = strFileName;
			try
			{
				this.xmlDoc = new XmlDocument();
				this.xmlDoc.Load(this._configFileSavePath + this._fullFileName);
			}
			catch
			{
				this.xmlDoc = null;
			}
		}
		public string GetValue(string strSection, string strKey, string strDefaultValue)
		{
			string result;
			if (this.xmlDoc == null)
			{
				result = strDefaultValue;
			}
			else
			{
				string text = strDefaultValue;
				XmlNodeList elementsByTagName = this.xmlDoc.GetElementsByTagName(strSection);
				foreach (XmlNode xmlNode in elementsByTagName)
				{
					XmlNodeList childNodes = xmlNode.ChildNodes;
					foreach (XmlNode xmlNode2 in childNodes)
					{
						if (xmlNode2.OuterXml.Length > this.lenOFValidFlag)
						{
							if (xmlNode2.OuterXml.Substring(0, this.lenOFValidFlag).Equals("<add"))
							{
								XmlAttribute xmlAttribute = xmlNode2.Attributes["key"];
								if (xmlAttribute != null)
								{
									if (xmlAttribute.Value == strKey)
									{
										xmlAttribute = xmlNode2.Attributes["value"];
										if (xmlAttribute != null)
										{
											text = xmlAttribute.Value;
											result = text;
											return result;
										}
									}
								}
							}
						}
					}
				}
				result = text;
			}
			return result;
		}
		public uint GetValue(string strSection, string strKey, uint uintDefaultValue)
		{
			uint result = 0u;
			try
			{
				result = uint.Parse(this.GetValue(strSection, strKey, uintDefaultValue.ToString()));
			}
			catch
			{
				result = uintDefaultValue;
			}
			return result;
		}
		public int GetValue(string strSection, string strKey, int intDefaultValue)
		{
			int result = 0;
			try
			{
				result = int.Parse(this.GetValue(strSection, strKey, intDefaultValue.ToString()));
			}
			catch
			{
				result = intDefaultValue;
			}
			return result;
		}
		public bool GetValue(string strSection, string strKey, bool blnDefaultValue)
		{
			bool result;
			if (blnDefaultValue)
			{
				result = (this.GetValue(strSection, strKey, "true") == "true" || (!(this.GetValue(strSection, strKey, "true") == "false") && blnDefaultValue));
			}
			else
			{
				result = (this.GetValue(strSection, strKey, "false") == "true" || (!(this.GetValue(strSection, strKey, "false") == "false") && blnDefaultValue));
			}
			return result;
		}
		public bool SetValue(string strSection, string strKey, string strDefaultValue)
		{
			bool result;
			if (this.xmlDoc == null)
			{
				result = false;
			}
			else
			{
				bool flag = false;
				XmlNodeList elementsByTagName = this.xmlDoc.GetElementsByTagName(strSection);
				foreach (XmlNode xmlNode in elementsByTagName)
				{
					XmlNodeList childNodes = xmlNode.ChildNodes;
					foreach (XmlNode xmlNode2 in childNodes)
					{
						if (xmlNode2.OuterXml.Length > this.lenOFValidFlag)
						{
							if (xmlNode2.OuterXml.Substring(0, this.lenOFValidFlag).Equals("<add"))
							{
								XmlAttribute xmlAttribute = xmlNode2.Attributes["key"];
								if (xmlAttribute != null)
								{
									if (xmlAttribute.Value == strKey)
									{
										xmlAttribute = xmlNode2.Attributes["value"];
										if (xmlAttribute != null)
										{
											xmlAttribute.Value = strDefaultValue;
											this.xmlDoc.Save(this._configFileSavePath + this._fullFileName);
											result = true;
											return result;
										}
									}
								}
							}
						}
					}
				}
				result = flag;
			}
			return result;
		}
		public bool SetValue(string strSection, string strKey, int intDefaultValue)
		{
			return this.SetValue(strSection, strKey, intDefaultValue.ToString());
		}
		public bool SetValue(string strSection, string strKey, bool blnDefaultValue)
		{
			bool result;
			if (blnDefaultValue)
			{
				result = this.SetValue(strSection, strKey, "true");
			}
			else
			{
				result = this.SetValue(strSection, strKey, "false");
			}
			return result;
		}
	}
}
