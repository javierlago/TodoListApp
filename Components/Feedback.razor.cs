using Microsoft.AspNetCore.Components;
using System.Threading;

namespace TodoListApp.Components
{
    public partial class Feedback : ComponentBase
    {
        [Parameter]
        public string? Text { get; set; }

        /// <summary>Tipos: "success", "info", "warning", "danger"</summary>
        [Parameter]
        public string Type { get; set; } = "info";

        /// <summary>Tiempo en milisegundos para autodesaparecer. 0 = nunca</summary>
        [Parameter]
        public int AutoHideMs { get; set; } = 4000;

        [Parameter]
        public EventCallback OnClosed { get; set; }

        private CancellationTokenSource? _cts;

        protected override async Task OnParametersSetAsync()
        {
            _cts?.Cancel();
            _cts = null;

            if (!string.IsNullOrWhiteSpace(Text) && AutoHideMs > 0)
            {
                _cts = new CancellationTokenSource();
                try
                {
                    await Task.Delay(AutoHideMs, _cts.Token);
                    await Close();
                }
                catch (TaskCanceledException)
                {
                    // Ignorar si fue cancelado manualmente
                }
            }
        }

        public async Task Close()
        {
            Text = null;
            await OnClosed.InvokeAsync();
            StateHasChanged();
        }
    }
}
