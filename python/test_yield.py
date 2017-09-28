def getnum():
    for i in range(10):
        yield i

def main():
    f=getnum()
    for i in range(10):        
        print f.__next__()
