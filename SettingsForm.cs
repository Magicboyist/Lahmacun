using System;
using System.Drawing;
using System.Windows.Forms;

namespace LahmacunGame
{
    public class SettingsForm : Form
    {
        private Label lblSound;
        private TrackBar tbSound;
        private Label lblMusic;
        private TrackBar tbMusic;
        private Label lblLanguage;
        private ComboBox cbLanguage;
        private Button btnSave;

        public SettingsForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Ayarlar";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblSound = new Label { Text = "Ses Seviyesi:", Location = new Point(20, 20), AutoSize = true };
            tbSound = new TrackBar
            {
                Minimum = 0, Maximum = 100, Value = Settings.SoundVolume,
                TickFrequency = 10, Location = new Point(150, 15), Width = 200
            };

            lblMusic = new Label { Text = "Müzik Seviyesi:", Location = new Point(20, 70), AutoSize = true };
            tbMusic = new TrackBar
            {
                Minimum = 0, Maximum = 100, Value = Settings.MusicVolume,
                TickFrequency = 10, Location = new Point(150, 65), Width = 200
            };

            tbMusic.ValueChanged += (s, e) =>
            {
                BackgroundMusic.SetVolume(tbMusic.Value);
            };

            lblLanguage = new Label { Text = "Dil:", Location = new Point(20, 120), AutoSize = true };
            cbLanguage = new ComboBox { Location = new Point(150, 115), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbLanguage.Items.AddRange(new string[] { "Türkçe", "English" });
            cbLanguage.SelectedItem = Settings.Language;

            btnSave = new Button
            {
                Text = "Kaydet",
                Location = new Point(150, 170),
                Size = new Size(150, 40)
            };
            btnSave.Click += BtnSave_Click;

            // Müzik yükleme butonunu kaldırdık; müzik dosyasını oyun dosyalarından ayarlıyoruz.
            this.Controls.Add(lblSound);
            this.Controls.Add(tbSound);
            this.Controls.Add(lblMusic);
            this.Controls.Add(tbMusic);
            this.Controls.Add(lblLanguage);
            this.Controls.Add(cbLanguage);
            this.Controls.Add(btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Settings.SoundVolume = tbSound.Value;
            Settings.MusicVolume = tbMusic.Value;
            Settings.Language = cbLanguage.SelectedItem.ToString();
            
            // Ayarların uygulamaya yansıması için ek kod ekleyebilirsiniz.
            MessageBox.Show("Ayarlar kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
