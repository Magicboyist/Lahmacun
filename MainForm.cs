using LahmacunGame.Audio;

namespace LahmacunGame
{
    public partial class MainForm : Form
    {
        // ...existing code...

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // İnternetten görselleri indir
            await GameResources.LoadOnlineResourcesAsync();
            
            // Arkaplan müziğini başlat
            BackgroundMusic.SetVolume(Settings.MusicVolume);
            BackgroundMusic.Play();
            
            UpdateGameState();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            BackgroundMusic.Stop();
        }
    }
}
