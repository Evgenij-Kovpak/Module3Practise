using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3Practise3
{
    public class MessageBox
    {
        public MessageBox()
        {
            MessageEvent = (Enums.State state) => Console.WriteLine("Событие при закрытии окна");
        }

        public event Action<Enums.State> MessageEvent;

        public Enums.State State { get; set; }

        public async void Open()
        {
            Console.WriteLine("Окно открыто");
            Thread.Sleep(3000);
            Console.WriteLine("Окно закрыто пользователем");
            MessageEvent.Invoke(RandomEnum());
            await Task.Run(() => Console.WriteLine("Строка для ожидающего метода..."));
        }

        public void Check()
        {
            if (State == Enums.State.Ok)
            {
                Console.WriteLine("Операция подтверждена");
            }
            else if (State == Enums.State.Cancel)
            {
                Console.WriteLine("Операция отклонена");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }

        private Enums.State RandomEnum()
        {
            Array values = Enum.GetValues(typeof(Enums.State));
            Random random = new Random();
            Enums.State randomState = (Enums.State)values.GetValue(random.Next(values.Length));
            State = randomState;
            return randomState;
        }
    }
}
