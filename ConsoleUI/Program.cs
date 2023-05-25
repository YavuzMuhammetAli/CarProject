using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new EfCarDal());
            Console.WriteLine(car.GetAll().Message);
            //foreach (var item in car.GetAll().Data)
            //{
            //    Console.WriteLine("Marka: " + item.marka + " " + "Model: " + item.model + " " + "Vites tipi: " + 
            //        item.vites + " " + "Yakıt tipi: " + item.yakit + " "  + "Motor tipi: " + item.motor + " " + 
            //        "Üretim yılı: " + item.yılı.Year);
            //}
            
        }
    }
}