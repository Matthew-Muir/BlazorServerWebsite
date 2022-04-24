namespace BlazorServerWebsite.Pages.CardBuilder
{
    public partial class Card
    {
        [Inject]
        public ILogger<Card>? Logger { get; set; }
        private IBrowserFile _file { get; set; } = default!;
        private async Task LoadFile(InputFileChangeEventArgs e)
        {
            _file = e.File;
            var result = new StringBuilder();

            using (var reader = new StreamReader(_file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(await reader.ReadLineAsync());
                }
            }

            Logger.LogError("Cookie");

        }

        public void LogTest()
        {
            Logger.LogError("TEsting!");
        }

    }
}
