using System;
using System.Threading.Tasks;

public class MessageBox
{
    public enum State
    {
        Хорошо,
        Отмена
    }

    public event Action<State> WindowClosed;

    public async void Open()
    {
        Console.WriteLine("Окно открыто.");
        await Task.Delay(3000); // Подождем 3 секунды
        Console.WriteLine("Окно было закрыто пользователем.");
        // Генерируем случайное состояние
        Random random = new Random();
        State randomState = (random.Next(2) == 0) ? State.Хорошо : State.Отмена;
        WindowClosed?.Invoke(randomState); // Вызываем событие закрытия окна
    }
}

class Program
{
    static void Main(string[] args)
    {
        MessageBox messageBox = new MessageBox();
        messageBox.WindowClosed += OnWindowClosed;
        messageBox.Open();
    }

    static void OnWindowClosed(MessageBox.State state)
    {
        if (state == MessageBox.State.Хорошо)
        {
            Console.WriteLine("Операция подтверждена.");
        }
        else
        {
            Console.WriteLine("Операция отклонена.");
        }
    }
}
