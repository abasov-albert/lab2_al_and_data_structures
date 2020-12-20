namespace ConsoleApp1.Model
{
    public class Grades
    {
        public int MathMark { get; set; }
        public string GeographyMark { get; set; }
        public int PhysicsMark { get; set; }

        public Grades(int mathMark, string GeographyMark, int physicsMark)
        {
            this.MathMark = mathMark;
            this.GeographyMark = GeographyMark;
            this.PhysicsMark = physicsMark;
        }
        
        public override string ToString()
        {
            return $"{nameof(MathMark)}: {MathMark}, " +
                   $"{nameof(GeographyMark)}: {GeographyMark}, " +
                   $"{nameof(PhysicsMark)}: {PhysicsMark}";
        }
    }
}