namespace BlazorServerWebsite.Pages.FileReading
{
    /* Page to Demo File Read/Write
     * GOALS
     * Read/output text file
     * Save text file to local directory
     * Update text file
     * 
     * Read JSON file

     * Update JSON file
     * 
     * Open IMG File

     * 
     * 
     */
    public partial class FileReading
    {
        [Inject]
        public ILogger<FileReading> Logger { get; set; }
        public class Card
        {
            public string Title { get; set; }
            public string Text { get; set; }
        }

        public string Txt { get; set; } = default!;

        public async Task ReadText(InputFileChangeEventArgs e)
        {
            var file = e.File;
            byte[] result;
            using (var stream = file.OpenReadStream())
            {
                result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);
            }
            Txt = Encoding.UTF8.GetString(result);
        }

        public async Task SaveFile(InputFileChangeEventArgs e)
        {
            var path = @"C:\Users\coded\Documents\GitHub\BlazorServerWebsite\BlazorServerWebsite\Uploads\";
            var file = e.File;
            path += e.File.Name;
            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
        }

        public Card MyCard { get; set; }
        public async Task ReadJson(InputFileChangeEventArgs e)
        {
            var file = e.File;
            byte[] result;
            using (var stream = file.OpenReadStream())
            {
                result = new byte[stream.Length];
                await stream.ReadAsync(result,0,(int)stream.Length);
            }
            //converts json file into text format then converts to JSON obj
            var text = Encoding.UTF8.GetString(result);
            Card? card = JsonSerializer.Deserialize<Card>(text);
            MyCard = new Card();
            MyCard.Title = card.Title;
            MyCard.Text = card.Text;

            //This version directly converts JSON file into JSON object.
            //But it throws an exception and StateHasChanged() must be called.
            //using (var stream = file.OpenReadStream())
            //{
            //    Card? card = await JsonSerializer.DeserializeAsync<Card>(stream);
            //}
            //CardTitle = card.Title;
            //CardText = card.Text;
            //StateHasChanged();


        }

    }
}
