using NAudio.Wave;
using Timer = System.Windows.Forms.Timer;

namespace MuteMic.Services
{
    public class Vumetro
    {
        private PictureBox pictureBox1;
        // Variables de Vumetro
        private WaveIn waveIn;
        private BufferedWaveProvider bufferedWaveProvider;
        private Timer timer;
        private float amplitude;
        private int device;


        public Vumetro(PictureBox pb, int DeviceID) {
            pictureBox1 = pb;
            device = DeviceID;
            InitVumetro();
        }

        private void InitVumetro()
        {
            // Configurar el medidor VU
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);

            // Configurar la grabación de audio
            waveIn = new WaveIn();
            waveIn.DeviceNumber = device; // Utilizar el dispositivo de audio predeterminado
            waveIn.WaveFormat = new WaveFormat(44100, 16, 1); // Formato de audio: 44.1 kHz, 16 bits, mono
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;

            // Configurar el temporizador para actualizar el medidor VU
            timer = new Timer();
            timer.Interval = 100; // Actualizar cada 100 milisegundos
            timer.Tick += new EventHandler(timer_Tick);
        }


        public void ChangeDeviceID(int device)
        {
            waveIn.StopRecording();
            waveIn.DeviceNumber = device;
            waveIn.StartRecording();
        }


        public void Start() {
            // Iniciar la grabación de audio
            waveIn.StartRecording();
            // Inicia el temporizador
            timer.Start();
        }


        public void Close()
        {
            // Detener la grabación de audio y el temporizador
            waveIn.StopRecording();
            timer.Stop();
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Leer los datos de audio del búfer
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;

            // Agregar los datos de audio al búfer interno
            bufferedWaveProvider.AddSamples(buffer, 0, bytesRecorded);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Calcular el nivel de amplitud de la señal de audio
            byte[] buffer = new byte[bufferedWaveProvider.BufferLength];
            int bytesRead = bufferedWaveProvider.Read(buffer, 0, bufferedWaveProvider.BufferLength);
            float sum = 0;
            for (int i = 0; i < bytesRead; i += 2)
            {
                short sample = (short)((buffer[i + 1] << 8) | buffer[i]);
                float sample32 = sample / 32768f;
                sum += sample32 * sample32;
            }
            float rms = (float)Math.Sqrt(sum / (bytesRead / 2));
            amplitude = Math.Min(rms * 50, 1); // Limitar el nivel máximo a 1

            // Redibujar el medidor VU
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar el medidor VU
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int barWidth = (int)(width * amplitude);
            int barHeight = (int)(height);
            int barX = 0;
            int barY = height - barHeight;
            Rectangle barRect = new Rectangle(barX, barY, barWidth, barHeight);
            e.Graphics.FillRectangle(Brushes.Green, barRect);
        }

    }
}
