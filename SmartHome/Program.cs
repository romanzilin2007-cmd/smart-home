using System;
using SmartHome.Models;

class Program
{
    static void Main()
    {
        SmartDevice[] devices =
        {
            new SmartLight("Лампа в гостиной", 80),
            new Thermostat("Термостат", 22.5),
            new SmartSpeaker("Колонка Алиса", 30),
            new SecurityCamera("Камера у входа"),
            new RobotVacuum("Пылесос Xiaomi", 85),
            new SmartKettle("Умный чайник", 45)
        };

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== УМНЫЙ ДОМ ===");
            Console.WriteLine("1. Показать все устройства и их статус");
            Console.WriteLine("2. Включить все устройства");
            Console.WriteLine("3. Выключить все устройства");
            Console.WriteLine("4. Включить устройство по имени");
            Console.WriteLine("5. Выключить устройство по имени");
            Console.WriteLine("6. Статистика (сколько включено / выключено)");
            Console.WriteLine("7. Проверить перегрузку методов (на примере лампы)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("--- Список устройств ---");
                    foreach (var device in devices)
                    {
                        Console.WriteLine(device.GetStatus());
                    }
                    break;

                case "2":
                    foreach (var device in devices)
                    {
                        device.TurnOn();
                    }
                    break;

                case "3":
                    foreach (var device in devices)
                    {
                        device.TurnOff();
                    }
                    break;

                case "4":
                    Console.Write("Введите точное имя устройства для включения: ");
                    string nameOn = Console.ReadLine();
                    var targetOn = Array.Find(devices, d => d.Name.Equals(nameOn, StringComparison.OrdinalIgnoreCase));
                    if (targetOn != null)
                    {
                        targetOn.TurnOn();
                    }
                    else
                    {
                        Console.WriteLine("Устройство с таким именем не найдено.");
                    }
                    break;

                case "5":
                    Console.Write("Введите точное имя устройства для выключения: ");
                    string nameOff = Console.ReadLine();
                    var targetOff = Array.Find(devices, d => d.Name.Equals(nameOff, StringComparison.OrdinalIgnoreCase));
                    if (targetOff != null)
                    {
                        targetOff.TurnOff();
                    }
                    else
                    {
                        Console.WriteLine("Устройство с таким именем не найдено.");
                    }
                    break;

                case "6":
                    int onCount = 0;
                    int offCount = 0;
                    foreach (var device in devices)
                    {
                        if (device.IsOn) onCount++;
                        else offCount++;
                    }
                    Console.WriteLine($"Статистика системы:\n- Включено: {onCount}\n- Выключено: {offCount}");
                    break;

                case "7":
                    var lamp = Array.Find(devices, d => d is SmartLight) as SmartLight;
                    if (lamp != null)
                    {
                        Console.WriteLine($"Текущая лампа: {lamp.Name}");
                        lamp.SetBrightness(50);
                        lamp.SetBrightness("night");
                    }
                    else
                    {
                        Console.WriteLine("Лампа не найдена в системе.");
                    }
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Выход из программы. До свидания!");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 0 до 7.");
                    break;
            }
        }
    }
}
