import os
#打印
def printList(L):
	n=0
	print("新增数量： ",len(L))
	for l in L:
		n+=1	
		print(n,l)
#写入		
def writeFile(L):
	with open("list.txt","a") as f:
		for l in L:
			f.write(l+"\n")
#读取
def readFile():
	file="list.txt"
	if not os.path.exists(file):
		with open(file,"w") as f:
			pass
	with open(file,"r") as f:
		return f.readlines()
#获取文件列表
filepath=r"\\192.168.2.55\合同执行传单\2017年合同执行传单\华虹\9月份"
files=[x for x in os.listdir(filepath)]
fileNames=map(lambda x:os.path.splitext(x)[0],files)
#printList(fileNames)
oldFiles=map(lambda x:x.strip(),readFile())
tempset=set(oldFiles)
#print("tempset")
#print(tempset)
newFiles=[]
for fileName in fileNames :
	if fileName in tempset:
		pass
	else:
		newFiles.append(fileName)
print("newFiles:")
printList(newFiles)
writeFile(newFiles)
input()