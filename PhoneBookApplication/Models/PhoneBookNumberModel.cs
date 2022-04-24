using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Models
{
    //Bu bölümde Telefon Rehberi Uygulamamızda sabit olan her bir kişi için isim, soyisim ve numara değişkenlerinin modeli oluşturularak kullanılabilir hale getirildi.

    //Propertyler oluşturuldu.
    public class PhoneBookNumberModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        //Constructer oluşturulup değişken ataması gerçekleştirildi.
        public PhoneBookNumberModel(string name, string surname, string number)
        {
            this.Name = name;
            this.Surname = surname;
            this.Number = number;
        }
        
    }
}
