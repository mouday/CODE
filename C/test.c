#include"stdio.h"

void f2_b()
{
	char *str="test string";
	int i;
	for(i=0;i<4;i++,str++)
	{
	*str='a';
	}
	printf("%c\n",*str);
}

void main()
{
	f2_b();
	int k,n,sum=0;
	printf("enter an integer:");
	scanf("%d",&n);
	for(k=1;k<=n;k++)
		sum+=k*k;
	printf("sum=%d\n",sum);
	
}

void test_f2()
{
	char str[]="test string";
	int i;
	for(i=0;i<4;i++)
	{
	*str='a';
	}
}


