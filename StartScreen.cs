using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using LahmacunGame.Utils; // ImageDownloader için

namespace LahmacunGame
{
    public class StartScreen : Form
    {
        private PictureBox backgroundPicture;
        private Button btnStart;

        public StartScreen()
        {
            InitializeComponentAsync();
        }

        private async void InitializeComponentAsync()
        {
            this.Size = new Size(800, 600);
            this.Text = "Lahmacun Zamanı - Başlangıç"; // Başlık güncellendi
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Arka plan resmi
            backgroundPicture = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = await ImageDownloader.DownloadImageAsync("https://loremflickr.com/800/600/bakery?lock=501")  // Bakery görseli
            };
            this.Controls.Add(backgroundPicture);

            // "Oyuna Başla" butonu
            btnStart = new Button
            {
                Text = "Oyuna Başla",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(200, 60),
                BackColor = Color.FromArgb(255, 112, 67),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnStart.Location = new Point((this.ClientSize.Width - btnStart.Width) / 2,
                                          (this.ClientSize.Height - btnStart.Height) / 2);
            btnStart.Anchor = AnchorStyles.None;
            btnStart.Click += BtnStart_Click;
            backgroundPicture.Controls.Add(btnStart);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
