using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
// Using System ile .NET Framework'ün System adlı namespaceinde yer alan sınıfları kullanacağımızı belirttik.
// Bu sınıflar dosya işlemleri yapmak, konsol uygulamaları oluşturmak, matematik işlemleri yapmak gibi işlemleri yapmak için kullanılır.
// Collection.Generic ile System namespaceinde yer alan Generic adlı bir alt namespaceteki sınıfların kullanılacağını belirtir.
// Bu sınıflar, örneğin liste, sıralı liste, sözlük gibi veri yapılarının kullanılmasını sağlar.
// Regular Expressions ifadesi ise metin işleme ve düzenli ifadeler kulllanımını sağlayan sınıfların bulunduğu System namespaceindeki RegularExpressions alt namespacesinin kullanılacağını belirtir.
// Bu namespace, özellikle metinleri analiz etmek ve dönüştürmek için kullanılır.


namespace TelephoneDirectory
    // Namespace, kodun okunurluğunu artırır ve gruplandırma yaptığı için isim çakışmalarının önüne geçer.
{
    internal class Program
        // References: Harici kütüphanelerin veya projelerin eklenmesi için kullanılan bir kavramdır, zaman ve iş gücü tasarrufu sağlar.
        // İnternal Class: Yalnızca aynı projede bulunan diğer sınıflar tarafından erişilebilir ve diğer projelerden erişilemez. Projenin iç yapısını gizler, kodu korur, kod karmaşıklığını azaltır.
    {
        class Directory
            // Sınıflar, OOP'nin temel yapıtaşlarından biridir.
        {
            List<Person> personList = new List<Person>();
            // Person sınfından bir liste nesnesi olan personList adlı değişkeni tanımlar ve oluşturur. List<Person> ifadesi, Person sınıfından bir liste nesnesi oluşturacağını belirtir.
            // Listeler, verileri depolamak için sıklıkla kullanılan bir c# koleksiyon tipidir. Listeler, belirli türden birden çok öğeyi saklamak için kullanılabilir.
            public void addPerson(string name, string surname, string comInfo1, string comInfo2)
                // addPerson adlı 4 parametre içeren bir public void metodu tanımlandı. Metodun amacı Person sınıfından yeni bir nesne oluşturmak ve bu nesneyi bir önceki örnekte tanımlanan personList adlı listede saklamak.
            {
                Person newPerson = new Person(name, surname, comInfo1, comInfo2);
                foreach (Person person in personList)
                {
                    if ((person.getName() == newPerson.getName()) && (person.getSurname() == newPerson.getSurname()))
                    {
                        Console.WriteLine(person.getName());
                        Console.WriteLine(newPerson.getName());
                        Console.WriteLine("Bu isim ve soy isme sahip biri zaten rehberde mevcut.");
                        Console.WriteLine("Üstüne yazmak ister misiniz?");
                        Console.WriteLine("1. 'Evet'    2. 'Hayır'");
                        if (Console.ReadLine() == "1")
                        {
                            person.setName(name);
                            person.setSurname(surname);
                            person.setComInfo1(comInfo1);
                            person.setComInfo2(comInfo2);
                        }
                        else
                        {
                            Console.WriteLine("Kişi listeye eklenmedi.");
                        }
                        return;
                        // Person sınıfından yeni bir liste oluşturdu ve bu nesneyi daha önce oluşturulan personList listesinde aradı.
                        // If yapısı ile işlemler gerçekleştirildi.
                    }
                }
                personList.Add(newPerson);
                personList.Sort((a, b) => a.getName().CompareTo(b.getName()));

            }
            public void printList()
            {
                Console.WriteLine("\n");
                Console.WriteLine("REHBER: \n");

                foreach (Person person in personList)
                {
                    Console.WriteLine($"{person.getName()} {person.getSurname()} {person.getComInfo1()} {person.getComInfo2()} \n");
                }
                Console.WriteLine("\n");
                // printList adında bir metot tanımlanıyor. Bu metot, personList isimli bir listedeki kişilerin adlarını, soyadlarını ve diğer bilgilerini konsola yazdırıyor.
                // foreach döngüsü kullanılarak, listedeki her kişi objesini person adlı bir değişkene atıyoruz ve ardından bu kişinin adını, soyadını ve diğer bilgilerini Console.WriteLine() metodu kullanarak yazdırıyoruz.
                // Metot sonunda birkaç boş satır yazdırıyoruz ki sonuçlar daha okunaklı olsun.
            }
            public void searchList(string name, string surname)
            {
                Console.WriteLine("\n");
                bool x = false;
                foreach (Person person in personList)
                {
                    if (person.getName().Contains(name) && person.getSurname().Contains(surname) || (person.getComInfo1() == name || person.getComInfo2() == name))
                    {
                        Console.WriteLine($"{person.getName()} {person.getSurname()} {person.getComInfo1()} {person.getComInfo2()} \n");
                        x = true;
                    }
                }
                if (!x)
                {
                    Console.WriteLine("Kullanıcı listede bulunamadı.");
                }
                Console.WriteLine("\n");
                // Bu bir metottur ve name - surname adında iki parametre alır. Bu metot, personList'te, verilen isim ve soyisim veya Person'ın şirket bilgileri ile eşleşen bir Person nesnesi arar.
                // Metot listedeki her bir Person için döngü oluşturur ve herhangi bir özellik açısından eşleşme arar. Eşleşme bulunursa, metot eşleşen Person nesnesinin ayrıntılarını yazar.
                // Eşlenme bulunmazsa, metot kullanıcının bulunmadığını belirtir. Son olarak, metot, çıktıyı takip edebilecek herhangi bir metinden ayırmak için iki yeni satır karakteri yazdırır.
            }

        }
        class Person
        {
            string name;
            string surname;
            string comInfo1;
            string comInfo2;
            public string getName() { return name; }
            public string getSurname() { return surname; }
            public string getComInfo1() { return comInfo1; }
            public string getComInfo2() { return comInfo2; }

            public void setName(string name) { this.name = name; }
            public void setSurname(string surname) { this.surname = surname; }
            public void setComInfo1(string comInfo1) { this.comInfo1 = comInfo1; }
            public void setComInfo2(string comInfo2) { this.comInfo2 = comInfo2; }
            // Person sınıfı. Sınıfın özellikleri: name, surname, comInfo1, comInfo2. setName: name özelliğini belirlemek için kullanırken, getName yöntemi name özelliğini almak için kullanılır.
            // Bu şekilde Person nesnesinin özelliklerine erişebilir ve bunları değiştirebilirsiniz.




            public Person(string name, string surname, string comInfo1, string comInfo2)
            {
                this.name = name;
                this.surname = surname;
                this.comInfo1 = comInfo1;
                this.comInfo2 = comInfo2;
                // Person sınıfının yapıcı yöntemidir. Yapıcı yöntem, bir sınıfın örneği oluşturulduğunda çalıştırılan bir yöntemdir.
                // Bu yapıcı yöntemi kullanarak bir Person nesnesi oluşturabilir, sonra name-surname-comInfo1-comInfo2 özelliklerine veri atayabilirsiniz.
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TELEFON REHBERİ");
            Directory directory = new Directory();
            string functionType, newName, newSurname, newComInfo1, newComInfo2, searchName, searchSurname, searchNumber, p;
            while (true)
            {
                newComInfo2 = "";
                Console.WriteLine("Lütfen yapmak istediğin işlemin numarasını yazıp Enter'a tıkla.");
                Console.WriteLine("1. Kişi ekle");
                Console.WriteLine("2. Kişileri listele");
                Console.WriteLine("3. Rehberde ara");
                Console.WriteLine("4. Rehberi kapat");
                functionType = Console.ReadLine();
                if (functionType == "4")
                    break;
                // Main yöntemi, uygulamanın başlangıcını ve çalışmasını yönetir. Directory nesnesi oluşturuldu, bu nesne telefon rehberinde telefon numaralarını saklamak için kullanılır.
                // While döngüsü oluşturulur ve kullanıcıdan yapmak istediği işlemi seçmesi istenir. functionType değişkeni kullanıcının seçtiği işlem türünü tutar.
                // Kullanıcı 4 tuşuna basana kadar döngü devam eder, bastığında döngü sonlandırılır ve uygulama kapatılır.
                // Kodun bu kısmı telefon rehberi uygulamasının temel bir çerçevesini sağlar ve kullanıcının uygulama içindeki diğer işlevlere erişmesine izin verir.
                switch (functionType)
                {
                    case "1":
                        {
                            Console.WriteLine("İsim:");
                            newName = Console.ReadLine();
                            if (!Regex.IsMatch(newName, @"^[a-zA-Z ]*$"))
                            {
                                Console.WriteLine("İsim sadece harf içermeli!");
                                Console.WriteLine("Lütfen kişiyi tekrar oluştur.");
                                break;
                            }
                            Console.WriteLine("Soy İsim:");
                            newSurname = Console.ReadLine();
                            if (!Regex.IsMatch(newSurname, @"^[a-zA-Z ]+$"))
                            {
                                Console.WriteLine("Soy İsim sadece harf içermeli!");
                                Console.WriteLine("Lütfen kişi tekrar oluştur.");
                                break;
                            }
                            Console.WriteLine("1. İletişim Bilgisi:");
                            newComInfo1 = Console.ReadLine();
                            if (!Regex.IsMatch(newComInfo1, @"^[0-9]+$"))
                            {
                                Console.WriteLine("İletişim bilgisi sadece rakam içermeli!");
                                Console.WriteLine("Lütfen kişiyi tekrar oluştur.");
                                break;
                            }
                            Console.WriteLine("2. İletişim Bilgisi: (varsa)");
                            newComInfo2 = Console.ReadLine();
                            if (!(Regex.IsMatch(newComInfo2, @"^[0-9]*$")))
                            {
                                Console.WriteLine("İletişim bilgisi sadece rakam içermeli!");
                                Console.WriteLine("Lütfen kişi tekrar oluştur.");
                                break;
                            }
                            directory.addPerson(newName, newSurname, newComInfo1, newComInfo2);
                        }
                        break;
                        // Bu kod bloğu, kullanıcının yeni bir kişi eklemek istediği durumda çalışır. İlk olarak, kullanıcıya yeni kişinin adı, soyadı ve iki adet iletişim bilgisi girmesi istenir.
                        // Girilen ad soyad sadece harf içermeli, boşluk da içerebilir. Bunun için Regex.IsMatch() metodu kulllanılır ve eğer girdi bu kriterlere uymuyorsa kullanıcı uyarılır ve kişi oluşturma işlemi iptal edilir.
                        // Eğer girilen bilgiler uygunsa, Directory sınıfından addPerson() metodu çağırılır ve yeni kişi rehbere eklenir.
                        // Break komutu, switch bloğundan çıkmayı sağlar ve kullanıcıya tekrar işlem seçenekleri sunulur.
                    case "2":
                        directory.printList();
                        break;
                    case "3":
                        Console.WriteLine("Arama yöntemini seç:");
                        Console.WriteLine("1. İsim ve soyisim ile arama");
                        // isim ve soyismin herhangi birer harfi ile de olsa kişi bulunur.
                        Console.WriteLine("2. Numara ile arama");
                        // Numaranın tamamı yazılmadığı sürece kişi bulunmaz.
                        p = Console.ReadLine();
                        if (p == "1")
                        {
                            Console.WriteLine("Aramak istediğin ismi gir:");
                            searchName = Console.ReadLine().Trim();
                            Console.WriteLine("Soyismi gir:");
                            searchSurname = Console.ReadLine().Trim();
                            directory.searchList(searchName, searchSurname);
                        }
                        else if (p == "2")
                        {
                            Console.WriteLine("Aramak istediğin numarayı gir:");
                            searchNumber = Console.ReadLine().Trim();
                            directory.searchList(searchNumber, searchNumber);
                        }
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir seçim yap!");
                        break;

                }
            }
        }
    }
}