using System.Collections;
using System.Linq;
#region Array
int[] marks = new int[5];
marks[0] = 100;
marks[1] = 100;
marks[2] = 100;
marks[3] = 100;
marks[4] = 100;
int totalMarks = 0;
foreach (int allMark in marks)
{
    totalMarks += allMark;
}
Console.WriteLine($"Exam Marks : {totalMarks}");


Console.WriteLine("----------------------------------------------");

int[] num = { 10, 20, 30, 40, 50 };
foreach (var rec in num)
{
    Console.WriteLine($"All Marks : {rec}");

}
#endregion

#region ArrayList
ArrayList items = new ArrayList();
items.Add("Mohamed Hairsh");
items.Add(24);
items.Add('B');
items.Add("CSE");
items.Add(89.8);
//for(var i=0;i<items.Count;i++)
//{
//    Console.WriteLine(items[i]);
//}
foreach(var rec in items)
{
    Console.WriteLine(rec);
 }
#endregion

//Generic Collections
#region List 
List<int> numbers = new List<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(40);
numbers.Add(50);
foreach (var id in numbers)
{
    Console.WriteLine(id);
}
#endregion 