
namespace BlazorServerWebsite.Pages.JsInt
{
    public partial class JsExp
    {
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        [Inject]
        public ILogger<JsExp> Logger { get; set; }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            Titus = new Dog();
            Lola = new Dog();
            return base.SetParametersAsync(parameters);
        }

        public async Task Func01()
        {
            if(JSRuntime is not null)
            await JSRuntime.InvokeVoidAsync("func01");
        }

        public async Task Func02(string str = "default")
        {
            if(JSRuntime is not null)
            await JSRuntime.InvokeVoidAsync("func02", str);
        }

        public string F3String { get; set; } = default!;
        public async Task<string> Func03()
        {
            if(JSRuntime is not null)
            return await JSRuntime.InvokeAsync<string>("func03");

            return "default";
        }

        public class Dog
        {
            public string Name { get; set; } = default!;
            public int Age { get; set; } = default!;
        }
        public Dog Lola { get; set; } = default!;
        public async Task Func04()
        {
            if (JSRuntime is not null)
                Lola = await JSRuntime.InvokeAsync<Dog>("func04");
        }

        public Dog Titus { get; set; } = default!;
        public async Task Func05()
        {
            if (JSRuntime is not null)
                Titus = await JSRuntime.InvokeAsync<Dog>("func05", "Titus", 4);
        }

        public void Exp()
        {
            Logger.LogError("Panda icecream");
        }
    }
}
