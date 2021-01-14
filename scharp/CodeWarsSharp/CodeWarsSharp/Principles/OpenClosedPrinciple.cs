using System;
namespace CodeWarsSharp.Principles {
    public class OpenClosedPrinciple {
        public OpenClosedPrinciple() {
        }

        private interface IShape {
            double Area();
        }

        private class Square : IShape {
            public int _length;

            public Square(int length) {
                _length = length;
            }

            public double Area() {
                return _length * _length;
            }
        }

        private class Circle : IShape {
            public int _radius;

            public Circle(int radius) {
                _radius = radius;
            }

            public double Area() {
                return Math.PI * (_radius * _radius);
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
                    ret += shape.Area();
                }
                return ret;
            }
        }
    }
}
