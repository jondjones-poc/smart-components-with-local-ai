using SmartComponents.StaticAssets.Inference;
using System.Text;

class CustomSmartPastePrompt : IInferenceBackend
{
    public Task<string> GetChatResponseAsync(ChatParameters options)
    {
        var messages = new StringBuilder();
        return Task.FromResult(messages.ToString());
    }
}