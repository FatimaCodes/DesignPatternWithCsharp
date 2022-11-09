namespace DesignPatternSample
{

        //This approach can work in a single-threaded environment.
        public class SimpleSingleton
        {
            private static SimpleSingleton instance;
            private SimpleSingleton() { }

            public static SimpleSingleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SimpleSingleton();
                    }
                    return instance;
                }
            }
        }
}
