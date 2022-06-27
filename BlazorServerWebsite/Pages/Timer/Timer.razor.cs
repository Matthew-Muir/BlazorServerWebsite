namespace BlazorServerWebsite.Pages.Timer
{
    public partial class Timer
    {
        [Inject]
        public ILogger<Timer>? Logger { get; set; }
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        private static System.Timers.Timer aTimer;
        private int counter = 5;
        public void StartTimer()
        {
            counter = 5;
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += CountDownTimer;
            aTimer.Enabled = true;
        }

        public void CountDownTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter -= 1;
            }
            else
            {
                aTimer.Enabled = false;
                Logger.LogWarning("timer completed");
                aTimer.Dispose();
            }
            InvokeAsync(StateHasChanged);
        }

        public async Task JsTimer()
        {
            await JSRuntime.InvokeVoidAsync("jsTimer", 5);
        }

    }
}
