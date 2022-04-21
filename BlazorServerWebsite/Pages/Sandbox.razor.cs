using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text;

namespace BlazorServerWebsite.Pages
{
    public partial class Sandbox
    {
        private IBrowserFile? _file;
        private string _txt = "";
        [Inject]
        public IJSRuntime JSRuntime { get; set; }



        private async Task OnInputFileChanged(InputFileChangeEventArgs e)
        {
            var file = e.File;
            long maxsize = 512000;

            var buffer = new byte[file.Size];
            await file.OpenReadStream(maxsize).ReadAsync(buffer);
            _txt = System.Text.Encoding.UTF8.GetString(buffer);
        }

        public void UpdatePage()
        {
            _txt = "TEST TEXT";
            StateHasChanged();
            
        }

       





    }
}
