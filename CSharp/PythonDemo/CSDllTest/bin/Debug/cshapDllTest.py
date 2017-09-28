import clr
clr.AddReferenceByPartialName("System.Windows.Forms")
clr.AddReferenceByPartialName("System.Drawing")
from System.Windows.Forms import *
from System.Drawing import *
clr.AddReferenceToFile("CSDllTest.dll")
from CSDllTest import *
a=12
b=6
#静态方法可以直接调用
c=TestDll.Add(a,b)
MessageBox.Show(c.ToString())

#普通方法需要先定义类
td=TestDll1()
td.AAA=100
td.ShowAAA()

