using PhoneBookApplication.Controllers;
using PhoneBookApplication.Models;
using System;

namespace PhoneBookApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Serkan", "Özsöz", "123"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Leyla", "Aydın", "456"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Ayaz", "Demirci", "789"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Selim", "Kızıl", "345"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Eylül", "Çakmak", "852"));

            
            OperationController.StartMethots();
            Console.WriteLine("Çıkmak İçin Herhangi Bir Tuşa Basınız...");
            Console.ReadKey();

        }
    }
}