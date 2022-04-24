using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Controllers
{
    public static class OperationController
    {
        //Giriş menüsünü yazdıran metodumuz.
        public static void StartPrint()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("*******************************************");
            Console.WriteLine("Çıkmak İçin 1-5 Dışında Her Hangi Bir Şey Girmeniz Yeterlidir.");
        }
        public static void StartMethots()
        {
            StartPrint();
            int select = int.Parse(Console.ReadLine());
            while (CheckNumber(select))
            {
                if (select == 1)
                {
                    SaveNumber();
                }
                else if (select == 2)
                {
                    DeleteNumber();
                }
                else if (select == 3)
                {
                    UpdateNumber();
                }
                else if (select == 4)
                {
                    PrintNumberList();
                }
                else if (select == 5)
                {
                    SearchNumber();
                }
                else
                {
                    Console.WriteLine("1-5 Aralığı Dışında Bir Sayı Girildi, Çıkılıyor...");
                    break;
                }
                StartPrint();
                select = int.Parse(Console.ReadLine());
            }

        }
        //Girilmiş numaranın 1 ile 5 arasında olduğunun kontrolü yapılır.
        public static bool CheckNumber(int number)
        {
            if(number >= 1 && number <= 5)
                return true;
            else
                return false;
        }
            
        //Rehberi Listeleyen metodumuz.
        public static void PrintNumberList()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("****************************");
            for(int i = 0; i<PhoneBookListModel.phoneBookNumberList.Count; i++)
            {
                Console.WriteLine("isim: {0}", PhoneBookListModel.phoneBookNumberList[i].Name);
                Console.WriteLine("Soyisim: {0}", PhoneBookListModel.phoneBookNumberList[i].Surname);
                Console.WriteLine("Telefon Numarası: {0}", PhoneBookListModel.phoneBookNumberList[i].Number);
                Console.WriteLine("-");
            }
        }

        //Rehbere yeni kullanıcı kaydeden metodumuz.
        public static void SaveNumber()
        {
            Console.WriteLine(" Lütfen isim giriniz             : ");
            string name= Console.ReadLine();
            Console.WriteLine(" Lütfen soyisim giriniz          : ");
            string surname = Console.ReadLine();
            Console.WriteLine(" Lütfen telefon numarası giriniz : ");
            string number = Console.ReadLine();
            PhoneBookListModel.phoneBookNumberList.Add(new PhoneBookNumberModel(name,surname,number));

        }

        //Rehberden kullanıcı silen metodumuz.
        public static void DeleteNumber()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string nameOrSurname = Console.ReadLine();
            PhoneBookNumberModel phoneNumber = Search(nameOrSurname);

            if(phoneNumber != null)
            {
                Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", nameOrSurname);
                string s = Console.ReadLine();
                if (s.ToLower() == "y")
                {
                    PhoneBookListModel.phoneBookNumberList.Remove(phoneNumber);
                    Console.WriteLine("Kayıt rehberden başarıyla silindi!");
                }
                else if (s.ToLower() == "n")
                {
                    Console.WriteLine("Kayıt silme onaylanmadı!");
                    DeleteNumber();
                }
                else
                {
                    Console.WriteLine("Yanlış bir giriş yaptınız!");
                    DeleteNumber();
                }
                
                
            }
            else
            {
                NotSearchDelete();
            }

            
            
        }
        public static PhoneBookNumberModel Search(string s)
        {
            bool isExist = false;
            foreach (var item in PhoneBookListModel.phoneBookNumberList)
            {
                if (item.Name == s || item.Surname == s)
                {
                    isExist = true;
                    if (isExist)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public static void NotSearchDelete()
        {
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için    : (1)");
            Console.WriteLine(" * Yeniden denemek için              : (2)");
            string number = Console.ReadLine();
            if(number=="1")
            {
                Console.WriteLine("Silme işlemi sonlandırılıyor!");
                StartMethots();
            }
            else
            { 
                DeleteNumber();
            }
        }

        public static void NotSearchUpdate()
        {
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
            Console.WriteLine(" * Yeniden denemek için              : (2)");
            string number = Console.ReadLine();
            if (number == "1")
            {
                Console.WriteLine("Güncelleme sonlandırılıyor!");
                StartMethots();
            }
            else
            {
                UpdateNumber();
            }
        }
        
        public static void UpdateNumber()
        {
            Console.WriteLine("Lütfen güncellemek istediğiniz kişinin adını veya soyadını giriniz : ");
            PhoneBookNumberModel phoneNumber = Search(Console.ReadLine());
            string[] items =
            {
                "Lütfen İsim Giriniz        : ",
                "Lütfen Soy İsim Giriniz    : ",
                "Lütfen Numara Giriniz      : "
            };
            int itemsLength = items.Length;
            string[] updatePhoneNumberModel = new string[itemsLength];
            if (phoneNumber != null)
            {
                Console.WriteLine("{0} isimli kişi güncellenmek üzere, onaylıyor musunuz ?(y/n)", phoneNumber.Name);
                string s = Console.ReadLine();
                if (s.ToLower() == "y")
                {
                    for (int i = 0; i < itemsLength; i++)
                    {
                        Console.WriteLine(items[i]);
                        items[i] = Console.ReadLine();
                    }

                    phoneNumber.Name = items[0];
                    phoneNumber.Surname = items[1];
                    phoneNumber.Number = items[2];
                    printRecord(phoneNumber);
                    Console.WriteLine("Kayıt güncelleme başarıyla tamamlandı!");

                }
                else if(s.ToLower() == "n")
                {
                    Console.WriteLine("Kayıt güncelleme onaylanmadı!");
                    UpdateNumber();
                }
                else
                {
                    Console.WriteLine("Yanlış bir giriş yaptınız!");
                    UpdateNumber();
                }
            }
            else
            {
                NotSearchUpdate();
            }
        }

        
        public static void printRecord(PhoneBookNumberModel phoneNumbers)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("İsim         :   {{{0}}}", phoneNumbers.Name);
            Console.WriteLine("Soyisim      :   {{{0}}}", phoneNumbers.Surname);
            Console.WriteLine("Numara       :   {{{0}}}", phoneNumbers.Number);
            Console.WriteLine("****************************************");
        }

        public static void SearchNumber()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("***********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin adını ya da soyadını giriniz:");
                string name = Console.ReadLine();
                foreach (var item in PhoneBookListModel.phoneBookNumberList)
                {
                    if (item.Name.ToLower() == name.ToLower() || item.Surname.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("isim: {0}", item.Name);
                        Console.WriteLine("Soyisim: {0}", item.Surname);
                        Console.WriteLine("Telefon Numarası: {0}", item.Number);
                        Console.WriteLine("-");
                    }
                }
                Console.WriteLine("Arama İşlemi Bitti, Çıkılıyor...");
            }
            else if (select == 2)
            {
                Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin telefon numarasını giriniz:");
                string no = Console.ReadLine();
                foreach (var item in PhoneBookListModel.phoneBookNumberList)
                {
                    if (item.Number == no)
                    {
                        Console.WriteLine("isim: {0}", item.Name);
                        Console.WriteLine("Soyisim: {0}", item.Surname);
                        Console.WriteLine("Telefon Numarası: {0}", item.Number);
                        Console.WriteLine("-");
                    }
                }
                Console.WriteLine("Arama İşlemi Bitti, Çıkılıyor...");
            }
            else
            {
                Console.WriteLine("Hatalı Seçim, Çıkılıyor...");
            }


        }
    }



    }

