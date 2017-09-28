#邮件发送测试.py
import sendEmail
count=1
for i in range(count):
	email=sendEmail.sendEmail("smtp.163.com","pengshiyuyx@163.com","","彭世瑜")
	ret=email.send("pengsy@byzxt.com.cn","dear","测试邮件名称","测试邮件内容")

	if ret==0:
		print("发送成功",i+1)
	else:
		print("发送失败",i+1)


