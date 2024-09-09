using System.Globalization;
using System.Runtime.InteropServices;

namespace FunctionalDemo
{
    //custom deletegate
    internal class Program
    {
        static void Main()
        {
            //store address of a function-- delegate
            Func<int, int, string> f =  GetAddress ;
            Console.WriteLine(f(3, 4));//get address is called
            f = delegate (int a,int b) { return "something"; }; //anonymous function
            f(5, 55);
            f = (x, y) => "actalent";//anonymous function
            f(5, 5);
            Action<int,string> ff = (x,y) => { Console.WriteLine(x + y); }; 
            ff(4,"dfdf"); //
            Predicate<int> pd = (x) => { return false; };
            Slot.Create(GetAddress);
            Slot.Create((x,y) => { Console.WriteLine(); return "madhusailit"; });
        }
        static string GetAddress(int x, int y)
        {
            return "address";
        }
    }
    internal class Slot 
    {
        public static void Create(Func<int,int,string> a)
        {
            a(3,4);
        } 
    }
}
