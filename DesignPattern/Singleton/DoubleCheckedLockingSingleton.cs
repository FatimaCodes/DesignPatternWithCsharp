using System;

namespace DesignPatternSample
{
        //Double checked locking
        public sealed class DoubleCheckedLockingSingleton
        {
            //We are using volatile to ensure that
            //assignment to the instance variable finishes before it’s 
            //access.
            private static volatile DoubleCheckedLockingSingleton instance;
            private static object lockObject = new Object();
            private DoubleCheckedLockingSingleton() { }

            public static DoubleCheckedLockingSingleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockObject)
                        {
                            if (instance == null)
                                instance = new DoubleCheckedLockingSingleton();
                        }
                    }
                    return instance;
                }
            }
    }
}
