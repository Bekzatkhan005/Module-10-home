Homework 10 2;
using System.Collections.Generic;

// Общий интерфейс для файлов и папок
interface IFileSystemComponent
{
    void Display();
    int GetSize();
}

// Класс, представляющий файл
class File : IFileSystemComponent
{
    private string _name;
    private int _size;

    public File(string name, int size)
    {
        _name = name;
        _size = size;
    }

    public void Display()
    {
        Console.WriteLine($"Файл: {_name}, Размер: {_size} КБ");
    }

    public int GetSize()
    {
        return _size;
    }
}

// Класс, представляющий папку
class Directory : IFileSystemComponent
{
    private string _name;
    private List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

    public Directory(string name)
    {
        _name = name;
    }

    // Добавление компонента в папку
    public void Add(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    // Удаление компонента из папки
    public void Remove(IFileSystemComponent component)
    {
        _components.Remove(component);
    }

    public void Display()
    {
        Console.WriteLine($"Папка: {_name}");
        foreach (var component in _components)
        {
            component.Display();
        }
    }

    public int GetSize()
    {
        int totalSize = 0;
        foreach (var component in _components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }
}

// Пример использования паттерна Компоновщик
class Program
{
    static void Main(string[] args)
    {
        // Создание файлов
        var file1 = new File("file1.txt", 500);
        var file2 = new File("file2.txt", 300);
        var file3 = new File("file3.txt", 700);

        // Создание папок
        var folder1 = new Directory("Folder1");
        var folder2 = new Directory("Folder2");

        // Добавление файлов в папки
        folder1.Add(file1);
        folder1.Add(file2);
        folder2.Add(file3);

        // Создание главной папки
        var mainFolder = new Directory("MainFolder");

        // Добавление папок в главную папку
        mainFolder.Add(folder1);
        mainFolder.Add(folder2);

        // Отображение содержимого главной папки
        mainFolder.Display();

        // Печать общего размера главной папки
        Console.WriteLine($"Размер главной папки: {mainFolder.GetSize()} КБ");
    }
}
