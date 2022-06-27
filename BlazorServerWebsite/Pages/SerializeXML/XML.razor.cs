namespace BlazorServerWebsite.Pages.SerializeXML
{
    public partial class XML
    {

        [Inject]
        public ILogger<XML>? Logger { get; set; }

        public class Book
        {
            public String title;
        }

        public void WriteXML()
        {
            var overview = new List<Book>();
            overview.Add(new Book() { title = "dance" });
            overview.Add(new Book() { title = "sing" });
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }

        public void CheckFile()
        {
            var file = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//SerializationOverview.xml");
            Logger.LogWarning(file.FullName);
            Logger.LogWarning(file.CreationTime.ToString());
        }

    }

   

}

