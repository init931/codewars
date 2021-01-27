using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.FactoryMethod {
    /// <summary>
    /// https://www.codeproject.com/Articles/1135918/Factory-Patterns-Factory-Method-Pattern
    /// </summary>
    class FactoryMethod {
        public FactoryMethod() {
            var fanFactory = new Fan2Factory();
            var fan2 = fanFactory.CreateFan();
            fan2.SwitchOn();
        }
    }

    interface IFan {
        void SwitchOn();
        void SwitchOff();
    }

    class Fan1 : IFan {
        public void SwitchOff() {
        }

        public void SwitchOn() {
        }
    }

    class Fan2 : IFan {
        public void SwitchOff() {
        }

        public void SwitchOn() {
        }
    }

    interface IFanFactory {
        IFan CreateFan();
    }

    class Fan1Factory : IFanFactory {
        public IFan CreateFan() {
            return new Fan1();
        }
    }

    class Fan2Factory : IFanFactory {
        public IFan CreateFan() {
            return new Fan2();
        }
    }
}