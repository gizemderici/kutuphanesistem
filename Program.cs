namespace kutup
{
    internal static class Program
    {
        // Filename isimli bir de�i�ken tan�mlay�n
        public static string Filename { get; private set; } = "default.txt"; // Varsay�lan bir dosya ad�

        /// <summary>  
        /// The main entry point for the application.  
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Uygulamay� ba�lat�rken Filename'i kullan�n
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(Filename)); // Do�ru bir eri�im olmal�
        }
    }
}

