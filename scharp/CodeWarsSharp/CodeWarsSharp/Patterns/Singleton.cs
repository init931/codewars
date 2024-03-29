﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.Singleton {
    class Singleton {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton GetInstance() {
            if (_instance == null) {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
