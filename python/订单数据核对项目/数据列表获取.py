#获取数据列表.py
import os,xlwt
path=r"\\192.168.2.55\ftp数据\模块机"
savePath="list.xls"
if os.path.isfile(savePath):
        os.remove(savePath)
workbook=xlwt.Workbook()
sheet=workbook.add_sheet("sheet1", cell_overwrite_ok=True)
#设置字体
style=xlwt.XFStyle()
font=xlwt.Font()
#font.name="微软雅黑"
#font.height=12*20
style.font=font
i=0
print("start...")
files=os.listdir(path)

for name in files:
    if os.path.splitext(name)[1]==".rar" or  os.path.splitext(name)[1]==".zip":
        i+=1
        sheet.write(i,0,name,style)
        print(name)

workbook.save(savePath)
#查找
a="2016-028-33"
result=[x for x in files if x.find(a)==0]
print(result)
print("ok")
