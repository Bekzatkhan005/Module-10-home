homework 10 1.1;

namespace HomeTheaterFacadePattern
{
    // Класс для управления телевизором
    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("Телевизор включен");
        }

        public void TurnOff()
        {
            Console.WriteLine("Телевизор выключен");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"Канал установлен на {channel}");
        }
    }

    // Класс для управления аудиосистемой
    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Аудиосистема включена");
        }

        public void TurnOff()
        {
            Console.WriteLine("Аудиосистема выключена");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Громкость установлена на {volume}");
        }
    }

    // Класс для управления DVD-проигрывателем
    public class DVDPlayer
    {
        public void Play()
        {
            Console.WriteLine("DVD проигрыватель начал воспроизведение");
        }

        public void Pause()
        {
            Console.WriteLine("DVD проигрыватель поставлен на паузу");
        }

        public void Stop()
        {
            Console.WriteLine("DVD проигрыватель остановлен");
        }
    }

    // Класс для управления игровой консолью
    public class GameConsole
    {
        public void TurnOn()
        {
            Console.WriteLine("Игровая консоль включена");
        }

        public void StartGame(string gameName)
        {
            Console.WriteLine($"Игра {gameName} запущена");
        }
    }

    // Фасад для управления мультимедийной системой
    public class HomeTheaterFacade
    {
        private TV _tv;
        private AudioSystem _audioSystem;
        private DVDPlayer _dvdPlayer;
        private GameConsole _gameConsole;

        public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdPlayer, GameConsole gameConsole)
        {
            _tv = tv;
            _audioSystem = audioSystem;
            _dvdPlayer = dvdPlayer;
            _gameConsole = gameConsole;
        }

        // Метод для просмотра фильма
        public void WatchMovie()
        {
            Console.WriteLine("Подготовка к просмотру фильма...");
            _tv.TurnOn();
            _audioSystem.TurnOn();
            _audioSystem.SetVolume(10);
            _dvdPlayer.Play();
        }

        // Метод для игры
        public void PlayGame(string gameName)
        {
            Console.WriteLine("Подготовка к игре...");
            _tv.TurnOn();
            _audioSystem.TurnOn();
            _audioSystem.SetVolume(5);
            _gameConsole.TurnOn();
            _gameConsole.StartGame(gameName);
        }

        // Метод для выключения системы
        public void TurnOffSystem()
        {
            Console.WriteLine("Выключение системы...");
            _tv.TurnOff();
            _audioSystem.TurnOff();
            _dvdPlayer.Stop();
            _gameConsole.TurnOn();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объекты для каждой подсистемы
            var tv = new TV();
            var audioSystem = new AudioSystem();
            var dvdPlayer = new DVDPlayer();
            var gameConsole = new GameConsole();

            // Создаем фасад, который управляет всей системой
            var homeTheater = new HomeTheaterFacade(tv, audioSystem, dvdPlayer, gameConsole);

            // Используем фасад для разных сценариев
            homeTheater.WatchMovie();
            homeTheater.TurnOffSystem();

            homeTheater.PlayGame("The Witcher 3");
            homeTheater.TurnOffSystem();
        }
    }
}
