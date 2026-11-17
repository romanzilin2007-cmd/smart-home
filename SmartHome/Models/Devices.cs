using System;

namespace SmartHome.Models
{
    class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }

        public SmartLight(string name, int brightness) : base(name)
        {
            Brightness = brightness;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Яркость: {Brightness}%");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, яркость {Brightness}%";
        }

        public void SetBrightness(int level)
        {
            Brightness = Math.Max(0, Math.Min(100, level));
            Console.WriteLine($"{Name}: яркость установлена на {Brightness}%");
        }

        public void SetBrightness(string preset)
        {
            if (preset.ToLower() == "night") Brightness = 15;
            else if (preset.ToLower() == "evening") Brightness = 40;
            else if (preset.ToLower() == "day") Brightness = 100;
            else
            {
                Console.WriteLine($"{Name}: неизвестный пресет \"{preset}\"");
                return;
            }
            Console.WriteLine($"{Name}: применен пресет \"{preset}\" → {Brightness}%");
        }
    }

    class Thermostat : SmartDevice
    {
        public double TargetTemperature { get; private set; }

        public Thermostat(string name, double temperature) : base(name)
        {
            TargetTemperature = temperature;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Целевая температура: {TargetTemperature}°C");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, целевая температура {TargetTemperature}°C";
        }
    }

    class SmartSpeaker : SmartDevice
    {
        public int Volume { get; private set; }

        public SmartSpeaker(string name, int volume) : base(name)
        {
            Volume = volume;
        }

        public override string GetStatus()
        {
            string state = IsOn ? "vкл" : "выкл";
            return $"{Name} — {state}, громкость {Volume}";
        }
    }

    class SecurityCamera : SmartDevice
    {
        public bool IsRecording { get; private set; }

        public SecurityCamera(string name) : base(name)
        {
            IsRecording = false;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            IsRecording = true;
            Console.WriteLine($"  Камера начала запись видео.");
        }

        public override void TurnOff()
        {
            base.TurnOff();
            IsRecording = false;
            Console.WriteLine($"  Камера остановила запись.");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            string rec = IsRecording ? "идёт запись" : "запись выключена";
            return $"{Name} — {state}, статус камеры: {rec}";
        }
    }

    class RobotVacuum : SmartDevice
    {
        public int BatteryLevel { get; private set; }

        public RobotVacuum(string name, int batteryLevel) : base(name)
        {
            BatteryLevel = batteryLevel;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Робот-пылесос выехал на уборку. Заряд батареи: {BatteryLevel}%");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, заряд батареи: {BatteryLevel}%";
        }
    }

    class SmartKettle : SmartDevice
    {
        public int WaterTemperature { get; private set; }

        public SmartKettle(string name, int waterTemp) : base(name)
        {
            WaterTemperature = waterTemp;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"  Чайник начал нагрев воды. Текущая температура: {WaterTemperature}°C");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "вкл" : "выкл";
            return $"{Name} — {state}, температура воды: {WaterTemperature}°C";
        }
    }
}

