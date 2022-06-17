namespace BlazorServerWebsite.Pages.Logging
{
    partial class Logging
    {
        public string ClassString { get; set; } = "btn";
        // builder.Services.AddLogging(); must be in 'Program.cs'. I don't remember if it's their by default.
        [Inject]
        public ILogger<Logging>? Logger { get; set; }
        [Inject] public IJSRuntime? JSRuntime { get; set; }

        public void LogToVsOutput()
        {
            Logger.LogError($"Error logged at {DateTime.Now.ToShortDateString()}");
            Logger.LogWarning($"Warning logged at {DateTime.Now.ToShortDateString()}");
        }

        public async Task JsAlert()
        {
            if(JSRuntime is not null)
            {
                await JSRuntime.InvokeVoidAsync("func01");
            }
        }

        public async Task JsConsoleLog()
        {
            await JSRuntime.InvokeVoidAsync("func06");
        }

    }
}
