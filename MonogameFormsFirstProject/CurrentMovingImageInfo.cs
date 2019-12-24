namespace MonogameFormsFirstProject
{
    public class CurrentMovingImageInfo
    {
        public int Width { get; set; }

        public int Height { get; set; }
        public Sprite currentImageToMove { get; set; }
        public Microsoft.Xna.Framework.Color[] DataToSet { get; set; }
        public (int, int) GridIndex { get; set; }
    }
}
