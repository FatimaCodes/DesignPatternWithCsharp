namespace DesignPatternSample.Builder
{
    // "Director"
    class Director
    {
        IBuilder builder;
        // A series of steps-in real life, steps are complex.
        public void Construct(IBuilder builder)
        {
            this.builder = builder;
            builder.StartUpOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();

            builder.AddHeadlights();
            builder.EndOperations();
        }
    }
}
