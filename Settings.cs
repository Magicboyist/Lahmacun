namespace LahmacunGame
{
    public static class Settings
    {
        public static int SoundVolume { get; set; } = 50;
        public static int MusicVolume { get; set; } = 50;
        public static string Language { get; set; } = "Türkçe";
        // Oyun dosyalarından yüklemek için varsayılan müzik dosyası yolu (Music klasörüne ekleyin)
        public static string MusicFilePath { get; set; } = "Music/complete.wav"; 
    }
}
