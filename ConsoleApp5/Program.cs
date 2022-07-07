using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IMovable
    {
        void Move();
    }
    public interface IVehicle
    {
        int Doors
        {
            get;
            set;
        }
        int Wheels
        {
            get;
            set;
        }
        int TopSpeed
        {
            get;
            set;
        }
        int Cylinders
        {
            get;
            set;
        }
        int CurrentSpeed
        {
            get;
        }
        string DisplayTopSpeed();
        void Accelerate(int step);
    }

    public class Motorcycle : IVehicle
    {
        private int _currentSpeed = 0;
        public int Doors
        {
            get;
            set;
        }
        public int Wheels
        {
            get;
            set;
        }
        public int TopSpeed
        {
            get;
            set;
        }
        public int HorsePower
        {
            get;
            set;
        }
        public int Cylinders
        {
            get;
            set;
        }
        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }
        }
        public Motorcycle(int doors, int wheels, int topSpeed, int horsePower, int cylinders, int currentSpeed)
        {
            this.Doors = doors;
            this.Wheels = wheels;
            this.TopSpeed = topSpeed;
            this.HorsePower = horsePower;
            this.Cylinders = cylinders;
            this._currentSpeed = currentSpeed;
        }
        public string DisplayTopSpeed()
        {
            return "Top speed is: " + this.TopSpeed;
        }
        public void Accelerate(int step)
        {
            this._currentSpeed += step;
        }
    }

    class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Driving");
        }
    }

    class MyClass1
    {
        public int MyProperty1 { get; set; } = 1;

        public MyClass1()
        {

        }
        public MyClass1(int x)
        {
            MyProperty1 = x;
        }
        public int print()
        {
            return MyProperty1;
        }
    }

    class MyClass2 : MyClass1
    {
        public int MyProperty2 { get; set; } = 2;
        public int MyProperty3 { get; set; } = 3;

        public MyClass2()
        {

        }
        public MyClass2(int x, int y)
        {
            MyProperty2 = x;
            MyProperty3 = y;
        }
    }

    public interface IPrint
    {
        void Print();
    }

    public interface IShow : IPrint
    {
        void Show();
    }

    class MyClassI : IShow
    {
        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }



    interface IAction
    {
        void Move();
    }

    public abstract class ActionBase : IAction
    {
        public abstract void Move();
    }
    class BaseAction:ActionBase
    {
        public override void Move() => Console.WriteLine("Move in BaseAction");
    }
    class HeroAction : BaseAction {
        public override void Move() => Console.WriteLine("Move in BaseAction");
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    interface IMessenger<in T, out K>
    {
        void SendMessage(T message);
        K WriteMessage(string text);
    }

    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }

    class SimpleMessenger : IMessenger<Message, EmailMessage>
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
        public EmailMessage WriteMessage(string text)
        {
            return new EmailMessage($"Email: {text}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMessenger<EmailMessage, Message> messenger = new SimpleMessenger();
            Message message = messenger.WriteMessage("Hello World");
            Console.WriteLine(message.Text);
            messenger.SendMessage(new EmailMessage("Test"));

            IMessenger<EmailMessage, EmailMessage> outlook = new SimpleMessenger();
            EmailMessage emailMessage = outlook.WriteMessage("Message from Outlook");
            outlook.SendMessage(emailMessage);

            IMessenger<Message, Message> telegram = new SimpleMessenger();
            Message simpleMessage = telegram.WriteMessage("Message from Telegram");
            telegram.SendMessage(simpleMessage);

            var tom = new Person("Tom", 23);
            var bob = tom;
            bob.Name = "Bob";
            Console.WriteLine(tom.Name); // Bob

            IAction action = new HeroAction();
            action.Move();  // Move in BaseAction

            Car tesla = new Car();
            tesla.Move();   // Driving

            MyClass1 base1 = new MyClass1();
            MyClass2 child1 = new MyClass2();

            Console.WriteLine(base1.print());
            Console.WriteLine(child1.print());

            MyClass1 base2 = new MyClass2();
            base2.MyProperty1 = 2;

            Console.WriteLine(base2.print());
            Console.ReadKey();
        }
    }
}
