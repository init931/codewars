using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsSharp.OOP.LawOfDemeter {
    class Employee {

        public void GoToBuyCoffee(bool isItWinter) {
            if (isItWinter) {
                wearWarmCloses();
            }
            goToCoffeeDealer();
            buyCoffee();
            takeCoffeeBack();
        }

        public void takeCoffeeBack() {
            throw new NotImplementedException();
        }

        public void buyCoffee() {
            throw new NotImplementedException();
        }

        public void goToCoffeeDealer() {
            throw new NotImplementedException();
        }

        public void wearWarmCloses() {
            throw new NotImplementedException();
        }

        public List<string> CreatedReports => new List<string>();

        public string GetLastCreatedReport() {
            return CreatedReports.Last();
        }
    }

    class Boss {
        public void DrinkCoffee() {
            //правильным вариантом будет вызвать метод так
            var empl = new Employee();
            empl.GoToBuyCoffee(true);

            //нарушение закона Диметры будет если этот класс будет сам управлять объектом, на примере ниже
            var unhappyEmpl = new Employee();
            unhappyEmpl.goToCoffeeDealer();
            unhappyEmpl.buyCoffee();
            unhappyEmpl.takeCoffeeBack();
        }

        public void GetLastReportOfEmployee(Employee empl) {
            //то же самое будет при обращении в объектам которыми управляет сам объект
            var lastReport = empl.GetLastCreatedReport();

            //нарушением будет лезть в дочерний объект и копаться в нем самому
            var unhappyLastReport = empl.CreatedReports.Last();
        }
    }
}
