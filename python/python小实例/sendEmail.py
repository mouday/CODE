#sendEmail.py
'''
参考：https://www.liaoxuefeng.com/wiki/0014316089557264a6b348958f449949df42a6d3a2e542c000/001432005226355aadb8d4b2f3f42f6b1d6f2c5bd8d5263000

封装成简单邮件发送模块
'''
from email import encoders
from email.header import Header
from email.mime.text import MIMEText
from email.utils import parseaddr, formataddr
import smtplib

def _format_addr(s):
		name,addr = parseaddr(s)
		return formataddr((Header(name, 'utf-8').encode(), addr))

class sendEmail(object):
	'邮件发送端初始化类'

	def __init__(self,smtp_server,from_addr,password="123456",from_name="admin"):
		'提示'
		self._smtp_server = smtp_server
		self._from_addr = from_addr
		self._password = password
		self._from_name = from_name

	def send(self,to_addr,to_name, title, text):
		'参数说明'
		try:
			msg = MIMEText(text, 'plain', 'utf-8')
			msg['From'] = _format_addr('%s<%s>' % (self._from_name,self._from_addr))
			msg['To'] = _format_addr('%s <%s>' % (to_name,to_addr))
			msg['Subject'] = Header(title, 'utf-8').encode()

			server = smtplib.SMTP(self._smtp_server, 25)
			#server.set_debuglevel(1)
			server.login(self._from_addr, self._password)
			server.sendmail(self._from_addr, to_addr, msg.as_string())
			server.quit()
			return 0
		except:
			return -1