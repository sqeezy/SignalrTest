using System;
using Newtonsoft.Json;

namespace Shared
{
	public static class MessageConverter
	{
		public static TResult Convert<TResult>(IGenericMessage message)
		{
			return (TResult)Convert(message);
		}

		public static object Convert(IGenericMessage message)
		{
			if (message == null) throw new ArgumentNullException(nameof(message));

			var type = Type.GetType(message.Type);
			if (type == null) throw new InvalidCastException("Message Type not found!");

			var result = JsonConvert.DeserializeObject(message.Payload?.ToString(), type);
			if (result == null) throw new JsonSerializationException("Message could not be deserialized!");

			return result;
		}
	}}