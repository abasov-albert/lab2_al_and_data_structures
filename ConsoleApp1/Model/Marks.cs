namespace ConsoleApp1.Model
{
    public class Marks
    {
        public int MathMark { get; set; }
        public string GeographyMark { get; set; }
        public int PhysicsMark { get; set; }

        public Marks(int mathMark, string GeographyMark, int physicsMark)
        {
            this.MathMark = mathMark;
            this.GeographyMark = GeographyMark;
            this.PhysicsMark = physicsMark;
        }
        
        public override int GetHashCode()
        {
            int hash = 11;
            hash = 3 * hash + MathMark;
            hash = 3 * hash + GeographyMark == null ? 0 : GeographyMark.GetHashCode();
            hash = 3 * hash * PhysicsMark;
            return hash;
        }
        
        
    }
}