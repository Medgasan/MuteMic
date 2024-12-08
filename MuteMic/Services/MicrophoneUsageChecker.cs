using System.Diagnostics;
using NAudio.CoreAudioApi;

public class MicrophoneUsageChecker
{
    public static List<string> GetApplicationsUsingMicrophone()
    {
        {
            List<string> applications = new List<string>();

            using (var enumerator = new MMDeviceEnumerator())
            {
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
                foreach (var device in devices)
                {
                    Console.WriteLine(device.AudioSessionManager.AudioSessionControl.GetProcessID);
                    if (device.DataFlow == DataFlow.Capture)
                    {
                        var sessionManager2 = device.AudioSessionManager;
                        var sessionEnumerator = sessionManager2.Sessions;

                        for (int x = 0; x > sessionEnumerator.Count; x++)
                        {
                            string applicationName = Process.GetProcessById((int)sessionEnumerator[x].GetProcessID).ProcessName;

                            if (!string.IsNullOrEmpty(applicationName))
                            {
                                applications.Add(applicationName);
                            }
                        }
                    }
                }
            }
            return applications;
        }
    }
}