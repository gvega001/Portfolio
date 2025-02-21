# Copilot Custom Instructions for Portfolio

## 1. Project Overview & Goals

- **Portfolio Focus:**  
  A modern, minimalist portfolio that showcases your projects, skills, and integrates interactive AI features (OpenAI/GPT-driven chatbot).

- **Technology Stack:**  
  - **.NET 9 MAUI Blazor Hybrid:** Combines native UI with Blazor web components.
  - **Blazor Components & Pages:** Used for dynamic content (Home, About, Portfolio, Contact).
  - **AI Integration:** Incorporate OpenAI for interactive chatbot and code explanations.
  - **Styling:** Use TailwindCSS (if integrated) for a responsive, clean UI.
  - **Coding Standards:** Embrace C# 12 features, async/await patterns, dependency injection, and SOLID principles.

---

## 2. Project Structure Recap

- **/Pages:**  
  Blazor pages (e.g., Home, About, Portfolio, Contact).  
  _Copilot Tip:_ Ensure each page has proper routing and lifecycle methods.

- **/Components:**  
  Reusable UI components like NavMenu, Footer, and ProjectCards.  
  _Copilot Tip:_ Factor out common UI elements to promote reusability and maintainability.

- **/Platforms:**  
  Platform-specific configurations for MAUI (Android, iOS, Windows, etc.).  
  _Copilot Tip:_ Verify platform settings for resources, icons, and platform-specific behaviors.

- **/wwwroot:**  
  Static assets (CSS, JS, images).  
  _Copilot Tip:_ Optimize asset loading and consider lazy-loading larger resources.

- **/Services:**  
  Business logic, API services (e.g., GPT integration).  
  _Copilot Tip:_ Implement interfaces for services and register them with dependency injection for testability and modularity.

---

## 3. Key Development Areas & Copilot Guidance

### A. **Blazor & Component Enhancements**

- **Reusable Component Patterns:**  
  - Implement patterns for modals, cards, and nav menus using Blazor’s `RenderFragment`.
  - Example:
    ```razor
    @* NavMenu.razor *@
    <nav class="bg-gray-800 p-4">
      <ul class="flex space-x-4">
        @foreach(var link in NavigationLinks)
        {
            <li>
              <NavLink class="text-white" href="@link.Url">@link.Title</NavLink>
            </li>
        }
      </ul>
    </nav>
    ```
  - _Copilot Tip:_ When suggesting changes, prioritize clean separation of concerns and reusability.

### B. **AI Integration with OpenAI**

- **Service Layer (in /Services):**  
  - Create an interface (e.g., `IOpenAiService`) and an implementation that uses `HttpClient` to call OpenAI’s API asynchronously.
  - Example:
    ```csharp
    public interface IOpenAiService
    {
        Task<string> GetChatbotResponseAsync(string prompt);
    }

    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;
        public OpenAiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetChatbotResponseAsync(string prompt)
        {
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/...", new StringContent(prompt));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
    ```
  - _Copilot Tip:_ Use async/await everywhere for non-blocking API calls and handle exceptions gracefully.

### C. **Dependency Injection & C# 12 Enhancements**

- **Program.cs Setup:**  
  - Register services using DI for easy testing and separation.
  - Example:
    ```csharp
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .ConfigureFonts(fonts =>
      {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
      });

    builder.Services.AddHttpClient<IOpenAiService, OpenAiService>();

    var app = builder.Build();
    return app;
    ```
  - _Copilot Tip:_ Leverage C# 12’s new features (like list patterns, global using directives, etc.) where applicable.

### D. **UI/UX & Performance Optimizations**

- **Responsive Layouts:**  
  - Use TailwindCSS (or equivalent) to ensure that layouts adjust fluidly between mobile and desktop.
  - _Copilot Tip:_ When generating components, check for accessibility standards (ARIA attributes, semantic HTML).

- **Performance:**  
  - Optimize Blazor component rendering by using proper lifecycle methods.
  - Implement lazy loading for images and heavy components.
  - _Copilot Tip:_ Suggest improvements in data fetching and caching where possible.

---

## 4. Deployment Strategy

### A. **Pre-Deployment Checklist**

- **Platform Validation:**  
  - Double-check configurations in the `/Platforms` directory for each target (Android, iOS, Windows, etc.).
  - Validate API keys and secure them using .NET’s secret management tools.

- **Testing:**  
  - Run your app on device emulators/simulators.
  - Verify responsiveness and performance using profiling tools.

### B. **Build & Publish Process**

- **Command Line & CI/CD:**  
  - For Android:
    ```bash
    dotnet publish -f:net9.0-android -c Release
    ```
  - Adjust for iOS, Windows, or MacOS as needed.
  - _Copilot Tip:_ Generate GitHub Actions workflows to automate builds and tests.

- **Deployment Tools:**  
  - Use Visual Studio’s built-in deployment tools for debugging and publishing.
  - Consider services like App Center for mobile app distribution.

### C. **Post-Deployment**

- **Monitoring & Updates:**  
  - Add logging and error reporting (e.g., using Application Insights).
  - Plan for iterative updates based on recruiter feedback.

---

## 5. Final Copilot Custom Instructions Recap

When feeding these instructions to Copilot, ensure it focuses on:

- **Reusable Blazor components** (cards, modals, nav menus).
- **Async/await patterns** in API calls.
- **Proper DI setup** and SOLID principles.
- **Secure AI interactions** with OpenAI.

And keeps in mind:

- Minimalist, responsive UI/UX.
- Performance and accessibility enhancements.
- TailwindCSS usage for modern styling.
- Deployment nuances for MAUI Blazor Hybrid apps.

