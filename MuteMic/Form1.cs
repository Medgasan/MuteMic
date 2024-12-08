using Microsoft.VisualBasic.Devices;
using MuteMic.Properties;
using MuteMic.Services;
using NAudio.CoreAudioApi;
using NAudio.Wave;


namespace MuteMic
{
    public partial class MuteMic : Form
    {
        // Elemento micrófono
        // TODO: Seleccionar micrófono según el dsipositivo
        MMDevice microphone = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);


        // variables del Botón
        Color activo = Color.Green;
        Color muteado = Color.Red;

        // Variables de Drag&Drop Form (se hace el en botón)
        private bool isClicked;
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        // Vumetro
        private Vumetro vumetro;

        public MuteMic()
        {
            InitializeComponent();
            button_muted(); // establecemos estado inicial del botón según estado actual del mute del micro
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            
            showStripMenuItem2.Text = Resources.ocultar;

            if (Settings.Default.WindowLocation != null)
                Location = Settings.Default.WindowLocation;


            // Inicializamos el vumetro
            vumetro = new(pictureBox1, 0);
            vumetro.Start();

        }


        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            microphone.AudioEndpointVolume.Mute = false;
            Settings.Default.WindowLocation = this.Location;
            Settings.Default.Save();
            vumetro.Close();
        }


        public void ActionMute()
        {
            if (microphone.AudioEndpointVolume.Mute)
            {
                microphone.AudioEndpointVolume.Mute = false;
                button_muted();
                return;
            }

            microphone.AudioEndpointVolume.Mute = true;
            button_muted();

        }


        public void button_muted()
        {
            bool muteStatus = microphone.AudioEndpointVolume.Mute;

            muteToolStripMenuItem.Text = muteStatus ? Resources.desmutear : Resources.mutear;
            button1.BackColor = muteStatus ? muteado : activo;
            notifyIcon1.Icon = muteStatus ? Resources.ico_m_conv: Resources.ico_conv;

            button1.Text = muteToolStripMenuItem.Text;
            Icon = notifyIcon1.Icon;

        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Cursor.Position; // Obtenemos la posición del cursor
            double x = Math.Abs(CalculateDisplacement(point, lastCursor)); // Calcula el 

            if (isClicked && x > 3)
            {
                isDragging = true;
                Point diff = Point.Subtract(Cursor.Position, new Size(lastCursor));
                this.Location = Point.Add(lastForm, new Size(diff));
            }
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            isDragging = false;
        }


        private void button1_mouse_click(object sender, MouseEventArgs e)
        {
            if (isDragging) { return; }
            ActionMute();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionMute();
        }


        private void showStripMenuItem2_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
            showStripMenuItem2.Text = Visible ? Resources.ocultar : Resources.mostrar;
        }


        public double CalculateDisplacement(Point point1, Point point2)
        {
            int deltaX = point2.X - point1.X;
            int deltaY = point2.Y - point1.Y;

            double displacement = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return displacement;
        }


        private void MicUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void check_mic_status(object sender, EventArgs e)
        {
            button_muted();
        }


        private void Center2Screen()
        {
            // Calcular posición para centrar el formulario
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = Width;
            int formHeight = Height;
            int posX = (screenWidth - formWidth) / 2;
            int posY = (screenHeight - formHeight) / 2;

            // Establecer posición del formulario
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(posX, posY);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Center2Screen();
        }
    }
}