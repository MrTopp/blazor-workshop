using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    /// <summary>
    /// Http access för Orderdata
    /// </summary>
    public class OrdersClient
    {
        private readonly HttpClient httpClient;

        public OrdersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Hämta alla order
        /// </summary>
        public async Task<IEnumerable<OrderWithStatus>> GetOrders() =>
            await httpClient.GetFromJsonAsync<IEnumerable<OrderWithStatus>>("orders");


        /// <summary>
        /// Hämta specifik order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<OrderWithStatus> GetOrder(int orderId) =>
            await httpClient.GetFromJsonAsync<OrderWithStatus>($"orders/{orderId}");

        /// <summary>
        /// Beställ pizzor
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<int> PlaceOrder(Order order)
        {
            var response = await httpClient.PostAsJsonAsync("orders", order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }

        /// <summary>
        /// Aktivera statusuppdateringar
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}