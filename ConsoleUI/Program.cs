using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            /*Brand ekleme*/
            //Brand brand = new Brand {Id=1,Name="BMW" };
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(brand);
            ///*Color Ekleme*/
            //Color color = new Color {Id=1,Name="Blue" };
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(color);
            /*Car Ekleme*/
            CarManager carManager = new CarManager(new EfCarDal());
            /*  Car car = new Car {Id=2,BrandId=1,ColorId=1,Name="A8 Long",
                  DailyPrice=2000,Description="Bmw Marka Mavi yeni araç",ModelYear=2019 };
              carManager.Add(car);*/

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + " / " + item.ColorName + " / " + item.BrandName);
            }
        }
    }
}
