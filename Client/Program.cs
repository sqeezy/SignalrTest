using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Shared;

namespace Client
{
	internal class Program
	{
		private static async Task Main(string[] args)
		{
			var clients = Enumerable.Range(0, 10).Select(_ => new SimpleClient()).ToArray();

			foreach (var client in clients)
			{
				await client.SendHello();
			}

			while (true)
			{
				foreach (var simpleClient in clients)
				{
					await simpleClient.SendMessage(new StringMessage(DateTime.Now.ToString()));
				}
			}
		}
	}
}