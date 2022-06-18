using System;

namespace LabDay5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            while (true)
            {
                Console.WriteLine("Melumatlari daxil edin:");
                Person person1 = new Person(GetCommand("Name"),
                                            GetCommand("Surname"),
                                            new DateTime(2002,11,11),
                                            GetCommand("Username"),
                                            GetCommand("Password"));
                //goto TryAgain; -> yazdığım yerə çatdığı anda bura qayıdır.
                TryAgain:
                Console.WriteLine("1. Short Info \n 2. Info \n 3. Login");
                int command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        Console.WriteLine(person1.ShortInfo());
                        //goto -> əgər bura gələrsə TryAgain adını harda daxil etmişəmsə (19-ci sətr) ora qayıdır.
                        //TryAgain yerinə əlösət'də ola bilərdi amma düzgün adlandırma önəmlidir.
                        goto TryAgain;
                    case 2:
                        Console.WriteLine(person1.Info());
                        goto TryAgain;
                    case 3:
                        Console.WriteLine(person1.Login(GetCommand("Username"), GetCommand("Password")));
                        goto TryAgain;
                    default:
                        break;
                }
            }
        }
        //Hər dəyər üçün Console.Write birdə Console.Realine lazım olduğu üçün
        //ayrıca bir methoda çıxartmaq kod təkrarının qarşısını alır
        public static string GetCommand(string text)
        {
            Console.Write($"{text}:");
            return Console.ReadLine();
        }

    }
    public class Person
    {
        public string _name;
        public string _surname;
        public DateTime _birthday;
        public string _username;
        public string _password;
        public bool _isLogin;
        public Person(string name, string surname, DateTime birthday)
        {
            _isLogin = false;
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }
        public Person(string name, string surname, DateTime birthday, string username, string password) : this(name, surname, birthday)
        {
            _username = username;
            _password = password;
        }
        public string ShortInfo()
        {
            // \n bir növbəti sətirə atır. 
            return $"Name:{_name}\n Surname:{_surname}\n Age: {GetAge()}";
        }
        public int GetAge()
        {
            return DateTime.Now.Year - _birthday.Year;
        }
        public string Info()
        {
            if (_isLogin)
            {
                return $"Name:{_name}\n Surname:{_surname}\n Age: {GetAge()}\n Username:{_username}\n Password:{_password}";
            }
            return "Ay kisi get login ol";
        }

        public bool Login(string username, string password)
        {
            if (username == _username && password == _password)
            {
                _isLogin = true;
                return _isLogin;
            }
            return _isLogin;
        }

    }
}
