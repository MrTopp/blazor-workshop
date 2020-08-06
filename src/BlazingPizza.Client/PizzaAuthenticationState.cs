using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazingPizza.Client
{
    /// <summary>
    /// Tillägg för att spara orderstatus mellan redirects
    /// </summary>
    public class PizzaAuthenticationState : RemoteAuthenticationState
    {
        public Order Order { get; set; }
    }
}
