using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyFirstrestFulApi;

public class StartUp : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        // Do nothing here
        return Task.CompletedTask;
    }
}
