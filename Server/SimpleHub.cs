using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shared;

public class SimpleHub : Hub
{
    public async Task Handle(IGenericMessage message)
    {
	    Console.WriteLine("Handle called!");
            await Clients.All.SendAsync("OnNotification", message);
    }

    public async Task Hello(string client)
    {
	    Console.WriteLine($"{client} said hello");
    }
}