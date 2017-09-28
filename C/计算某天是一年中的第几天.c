#include <stdio.h>
int main() 
{ 
    /* 定义需要计算的日期 */
    int year = 2008;
    int month = 8;
    int day = 8;
    /*
     * 请使用switch语句，if...else语句完成本题
     * 如有想看小编思路的，可以点击左侧任务中的“不会了怎么办”
     * 小编还是希望大家独立完成哦~
     */
     //判断是否为闰年
     int flag=0;
     if((year%400==0)||(year%4==0 && year%100!=0))
     {
         flag=1;
     }
     int days=0;
     month-=1;//前几个月的月份 
     switch(month)
     {
         case 12:days+=31;
         case 11:days+=30;
         case 10:days+=31;
         case 9:days+=30;
         case 8:days+=31;
         case 7:days+=31;
         case 6:days+=30;
         case 5:days+=31;
         case 4:days+=30;
         case 3:days+=31;
         case 2:
         if(flag=1)
		 {
             days+=29;
         }
         else
         {days+=28;}
         case 1:days+=31;
         
     }
     days+=day;
     printf("2008年8月8日是该年的第%d天",days);
    return 0;
}
