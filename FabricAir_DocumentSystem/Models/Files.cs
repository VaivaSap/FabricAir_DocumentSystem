namespace FabricAir_DocumentSystem.Models
{
    public class Files
    {

        public int Id { get; set; }
        public string FileName { get; set; }

        public string FilePath { get; set; }
        public int FileTypeId { get; set; }
        public int UserId { get; set; }


    }
}
