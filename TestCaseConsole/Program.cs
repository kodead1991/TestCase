using System;


namespace TestCaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Professional\Documents\GitHub\TestCase\testKdr.kdr";
            Kadr k = new Kadr();
            k.openKadr(path);
        }
    }
}
