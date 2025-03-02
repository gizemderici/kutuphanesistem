namespace kutup
{
    internal static class Program
    {
        // Filename isimli bir deðiþken tanýmlayýn
        public static string Filename { get; private set; } = "default.txt"; // Varsayýlan bir dosya adý

        /// <summary>  
        /// The main entry point for the application.  
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Uygulamayý baþlatýrken Filename'i kullanýn
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(Filename)); // Doðru bir eriþim olmalý
        }
    }
}

