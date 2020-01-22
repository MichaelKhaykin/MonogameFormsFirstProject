namespace MonogameFormsFirstProject
{
    public class CurrentMovingImageInfo
    {
        public (int, int) GridIndex { get; set; }
        public Sprite Sprite { get; set; }

        public bool isReadyToSet { get; set; } = false;
    }
}
