using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.Strategy {
    class Strategy {
        public Strategy() {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }

    interface IMovable {
        void Move();
    }

    class PetrolMove: IMovable {
        public void Move() {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove: IMovable {
        public void Move() {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
    class Car {
        /// <summary>
        /// кол-во пассажиров
        /// </summary>
        protected int passengers;
        /// <summary>
        /// модель автомобиля
        /// </summary>
        protected string model;

        public Car(int num, string model, IMovable mov) {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move() {
            Movable.Move();
        }
    }
}
