namespace BlazorServerWebsite.Pages.FileReading
{
    /* Page to Demo File Read/Write
     * GOALS
     * Read/output text file
     * Save text file to local directory
     * Update text file
     * 
     * Read JSON file
     * Save JSON file to local directory
     * Update JSON file
     * 
     * Open IMG File
     * Save Img file to local directory
     * 
     * 
     */
    public partial class FileReading
    {
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
            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
        }

    }
}
