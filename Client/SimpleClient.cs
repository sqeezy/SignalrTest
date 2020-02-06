using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Shared;

namespace Client
{
	internal class SimpleClient
	{
		private readonly HubConnection _connection;

		public SimpleClient()
		{
			_connection = new HubConnectionBuilder()
				.WithUrl("http://localhost:5000/SimpleHub")
				.WithAutomaticReconnect()
				.Build();
			var start = _connection.StartAsync();
			start.Wait();
			_connection.Closed += OnConnectionOnClosed;
		}

		private async Task OnConnectionOnClosed(Exception error)
		{
			await Task.Delay(new Random().Next(0, 5) * 1000);
			await _connection.StartAsync();
		}

		public async Task SendMessage(IGenericMessage message)
		{
			await _connection.SendAsync("Handle", message);
		}

		public async Task OnNotification(IGenericMessage message)
		{
			var notification = MessageConverter.Convert<IGenericMessage>(message);
			Console.WriteLine($"{GetHashCode()}: received {notification.Type}");
			await Task.Delay(0);
		}

		public async Task SendHello()
		{
			await _connection.SendAsync("Hello", GetHashCode().ToString());
		}
	}
}