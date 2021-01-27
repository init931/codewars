using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.SimpleFactory {
    /// <summary>
    /// https://www.codeproject.com/Articles/1131770/Factory-Patterns-Simple-Factory-Pattern
    /// </summary>
    class SimpleFactory {
        public SimpleFactory() {
            IFanFactory simpleFactory = new FanFactory();
            IFan fan = simpleFactory.CreateFan(FanType.CeilingFan);
            fan.SwitchOn();
        }
    }

    enum FanType {
        TableFan,
        CeilingFan,
        ExhaustFan
    }

    interface IFan {
        void SwitchOn();
        void SwitchOff();
    }

    class TableFan: IFan {
        public void SwitchOff() {

        }

        public void SwitchOn() {

        }
    }

    class CeilingFan: IFan {
        public void SwitchOff() {

        }

        public void SwitchOn() {

        }
    }

    class ExhaustFan: IFan {
        public void SwitchOff() {

        }

        public void SwitchOn() {

        }
    }

    interface IFanFactory {
        IFan CreateFan(FanType type);
    }

    class FanFactory: IFanFactory {
        public IFan CreateFan(FanType type) {
            return type switch {
                FanType.TableFan => new TableFan(),
                FanType.CeilingFan => new CeilingFan(),
                FanType.ExhaustFan => new ExhaustFan(),
                _ => new TableFan(),
            };
        }
    }
}
