#include <stdio.h>
#define N 10 

/*题目要求：在一个长度为10的整型数组里面，
保存了班级10个学生的考试成绩。
要求编写5个函数，
分别实现计算考试的总分，最高分，最低分，
平均分和考试成绩降序排序*/ 

//打印数组
void printNum(int score[])
{
	int i;//C语言中不能在for()中定义 
	for(i=0;i<N;i++)
	{	
		if(i<N-1)
		{
			printf("%d ",score[i]);
		}
		else		
		{
			printf("%d\n",score[i]);
		}		
	}
} 
//计算考试的总分 
int getSum(int score[])
{
    int i;
    int sum=0; 
    for(i=0;i<N;i++)
    {
        sum+=score[i];
    }
    return sum;
}
//最高分，
int getMax(int arr[])
{
	int max=arr[0];
	int  i;
	for(i=1;i<N;i++)
	{
		if(arr[i]>max)
		{
			max=arr[i];
		}	
	}
	return max;
}

//最低分，
int getMin(int arr[])
{
	int min=arr[0];
	int  i;
	for(i=1;i<N;i++)
	{
		if(arr[i]<min)
		{
			min=arr[i];
		}	
	}
	return min;
}
//平均分
int getAverage(int arr[])
{
	int sum=getSum(arr);
	return sum/N;
} 
//考试成绩降序排序
void sortArr(int arr[])
{
	//冒泡排序
	 int i,j;
	 for(i=N-1;i>=0;i--)
	 {
		for(j=0;j<i;j++)
		{
			if(arr[j]<arr[j+1])
			{
				int temp=arr[j];
				arr[j]=arr[j+1];
				arr[j+1]=temp;
			}
		}
	 }
	
} 

int main()
{
    int score[N]={67,98,75,63,82,79,81,91,66,84};
    printf("考试成绩：");
	printNum(score);
    printf("总分：%d\n",getSum(score));
    printf("最高分：%d\n",getMax(score));
    printf("最低分：%d\n",getMin(score));
    printf("平均分：%d\n",getAverage(score));
    printf("降序排列："); 
    sortArr(score);
    printNum(score);
    return 0;
}

