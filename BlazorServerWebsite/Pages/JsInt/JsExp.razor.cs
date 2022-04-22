
namespace BlazorServerWebsite.Pages.JsInt
{
    public partial class JsExp
    {
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        //[Inject]
        //public ILogger? Logger { get; set; }

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

        public async Task Func04()
        {
            if(JSRuntime is not null)
            await JSRuntime.InvokeVoidAsync("test", new int[]{ 1,2,3});
        }

        public string JSON { get; set; } = default!;

        public class Dog
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public async Task Func05()
        {
            //if (JSRuntime is not null)
            //     Dog? lola = J await JSRuntime.InvokeAsync<string>("rjson");
           
            
            Dog? Lola = JsonSerializer.Deserialize<Dog>(await JSRuntime.InvokeAsync<string>("rjson"));
            
            if (JS is not null)
                JS.LogError($"{Lola.Name} + {Lola.State}");

            //LEFT OFF HERE... Trying to Deserialize JSON return.Bookmarked a stack article.
        }
    }
}
