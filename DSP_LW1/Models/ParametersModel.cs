namespace DSP_LW1.Models
{
    public class ParametersModel
    {
        public double[] A { get; set; } = new double[4];
        public double[] F { get; set; } = new double[4];
        public double[] P { get; set; } = new double[4];
        public double[] WellRate { get; set; } = new double [4];
        public int N { get; set; }
    }
}
