using System;

namespace SmartHome.Models
{
    abstract class SmartDevice
    {
        public string Name { get; private set; }
        public bool IsOn { get; protected set; }

        protected SmartDevice(string name)
        {
            Name = name;
        }

        public virtual void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name}: включён.");
        }

        public virtual void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name}: выключен.");
        }

        public abstract string GetStatus();
    }
}
