using System;
namespace CodeWarsSharp.Principles {
    public class SingleResponsibilityPrinciple {
        public SingleResponsibilityPrinciple() {
            var shapes = new IShape[] {
                new Circle(4),
                new Square(10),
                new Square(3)
            };
            var ac = new AreaCalculator(shapes);
            Console.WriteLine($"area sum = {ac.Sum()}");
        }

        private interface IShape {

        }

        private class Square: IShape {
            public int _length;

            public Square(int length) {
                _length = length;
            }
        }

        private class Circle: IShape {
            public int _radius;

            public Circle(int radius) {
                _radius = radius;
            }
        }

        private class AreaCalculator {
            private IShape[] _shapes;

            public AreaCalculator(IShape[] shapes) {
                _shapes = shapes;
            }

            public double Sum() {
                double ret = 0;
                foreach (var shape in _shapes) {
                    if (shape is Square) {
                        ret += Math.Pow(((Square)shape)._length, 2);
                    }
                    else if (shape is Circle) {
                        ret += Math.PI * Math.Pow(((Circle)shape)._radius, 2);
                    }
                }
                return ret;
            }
        }
    }
}
