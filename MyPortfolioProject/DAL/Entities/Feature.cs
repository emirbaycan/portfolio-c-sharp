namespace MyPortfolioProject.DAL.Entities
{
    public class Feature // One cikan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ImageId { get; set; } // Gorsel yukleme islemi bos da gecilebilir
        public Image Image { get; set; }
    }
}
