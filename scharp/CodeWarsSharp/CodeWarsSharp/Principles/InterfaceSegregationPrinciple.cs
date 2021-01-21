using System;
namespace CodeWarsSharp.Principles {
    public class InterfaceSegregationPrinciple {
        public class ViolatePrinciple {
            interface ShapeInterface {
                public int area();

                public int volume(); // add new method
            }

            class Square : ShapeInterface {
                public int area() {
                    throw new NotImplementedException();
                }

                public int volume() {
                    // violation of ISP
                    return -1;
                }
            }

            class Cuboid : ShapeInterface {
                public int area() {
                    throw new NotImplementedException();
                }

                public int volume() {
                    throw new NotImplementedException();
                }
            }
        }

        public class FollowPrinciple {
            interface ShapeInterface {
                public int area();
            }

            interface ThreeDimensionalShapeInterface { // different interface
                public int volume();
            }

            class Cuboid : ShapeInterface, ThreeDimensionalShapeInterface {
                public int area() {
                    return 10;
                }

                public int volume() {
                    return 10;
                }
            }
        }
    }
}
