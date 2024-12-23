//// See https://aka.ms/new-console-template for more information


using System.Globalization;
using System.Linq;
#region  pattern method
/*int rows;
Console.WriteLine("Enter the Number");
rows=Convert.ToInt32(Console.ReadLine());
int i = 1;
while (i <= rows)
{
    int j = 1;
    while (j <= i)
    {
        Console.Write("*");
        j++;
    }
    Console.WriteLine();
    i++;
}*/
#endregion

#region Reverse String Problem
/*string input;
char[] Let;
Console.Write("Enter the Character : ");
input = Console.ReadLine();
Let = input.ToCharArray();
Array.Reverse(Let);
Console.WriteLine(Let);*/
#endregion
 
#region find a table 
int num;
Console.Write("Ener the a num to find it's talbe : ");
num = int.Parse(Console.ReadLine());
for (int table=1; table<=20;table++)
{
    Console.WriteLine($"{table} * {num}  = {num*table}");
}
Console.ReadLine();

#endregion


