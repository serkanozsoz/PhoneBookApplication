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
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Mert", "Akçay", "456"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Ahmet", "Sayar", "789"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Büşra", "Kızıl", "123"));
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel("Aslı", "Çakmak", "852"));

            
            OperationController.StartMethots();
            Console.WriteLine("Çıkmak İçin Herhangi Bir Tuşa Basınız...");
            Console.ReadKey();

        }
    }
}