using NAudio.CoreAudioApi;

namespace MuteMic
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MuteMic());

            // =============================================================================================
            //var enumerator = new MMDeviceEnumerator();
            //enumerator = new MMDeviceEnumerator();
            //MMDevice device1 = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
            //AudioSessionManager audioSessionManager = device1.AudioSessionManager;
            //SessionCollection session1 = audioSessionManager.Sessions;
            //for (int i1 = 0; i1 < session1.Count; i1++)
            //{
            //    string[] title = GetProcessName(session1[i1].GetProcessID);
            //    Console.WriteLine(title[0]);
            //}
            // =============================================================================================
        }
        // =============================================================================================
        //private static string[] GetProcessName(uint processId)
        //{
        //    try
        //    {
        //        System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById((int)processId);
        //        return [process.ProcessName, process.MainWindowTitle];
        //    }
        //    catch (Exception ex)
        //    {
        //        return [$"Proceso desconocido (Error: {ex.Message})"];
        //    }
        //}
        // =============================================================================================
    }
}