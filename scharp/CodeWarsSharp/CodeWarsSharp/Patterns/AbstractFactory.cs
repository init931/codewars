using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.AbstractFactory {
    /// <summary>
    /// https://www.codeproject.com/Articles/1137307/Factory-Patterns-Abstract-Factory-Pattern
    /// </summary>
    class AbstractFactory {
        public AbstractFactory() {
            IElectricalFactory electricalFactory = new IndianElectricalFactory();
            IFan fan = electricalFactory.GetFan();
            fan.SwithOn();


            IElectricalFactory electricalFactoryUs = new USElectricalFactory();
            IFan fanUs = electricalFactoryUs.GetFan();
            fanUs.SwithOn();
        }
    }

    interface IFan {
        void SwithOn();
    }

    interface ITubelight { }

    class IndianFan: IFan {
        public void SwithOn() { }
    }

    class IndianTubelight: ITubelight { }

    class USFan: IFan {
        public void SwithOn() { }
    }

    class USTubelight: ITubelight { }

    interface IElectricalFactory {
        IFan GetFan();
        ITubelight GetTubeLight();
    }

    class IndianElectricalFactory: IElectricalFactory {
        public IFan GetFan() {
            return new IndianFan();
        }

        public ITubelight GetTubeLight() {
            return new IndianTubelight();
        }
    }

    class USElectricalFactory: IElectricalFactory {
        public IFan GetFan() {
            return new USFan();
        }

        public ITubelight GetTubeLight() {
            return new USTubelight();
        }
    }
}
