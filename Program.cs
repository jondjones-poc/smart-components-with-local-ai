using SmartComponents.Inference.OpenAI;

// Smart Combobox only
using SmartComponents.LocalEmbeddings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Smart Combobox
builder.Services.AddSingleton<LocalEmbedder>();

builder.Services.AddSmartComponents()
    .WithInferenceBackend<OpenAIInferenceBackend>();
//.WithInferenceBackend<CustomSmartPastePrompt>(); // Smart Pastebox

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

/// Dumb suggestions for combo box
var categories = new[] {
            "Toyota", "Honda", "Ford", "Chevrolet", "Volkswagen",
            "BMW", "Mercedes-Benz", "Audi", "Nissan", "Hyundai",
            "Kia", "Volvo", "Subaru", "Mazda", "Lexus",
            "Tesla", "Jeep", "Fiat", "Chrysler", "Porsche"
        };
app.MapSmartComboBox("api/normal-api", request => categories);

/// Embeddings - Better AI on combo box
var embedder = app.Services.GetRequiredService<LocalEmbedder>();
var embedRange = embedder.EmbedRange(categories);
app.MapSmartComboBox("api/clever-api", request => embedder.FindClosest(request.Query, embedRange));

app.Run();
