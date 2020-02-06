using System;

namespace Shared
{
	public interface IGenericMessage
	{
		string Type { get; }
		object Payload { get; }
	}

	public class Message
	{
		public Message(object value)
		{
			Value = value ?? throw new ArgumentNullException(nameof(value));

			var type = value.GetType();

			Type = $"{type.FullName}, {type.Assembly.GetName().Name}";
		}

		protected Message()
		{
		}

		public object Value { get; protected set; }
		public string Type { get; protected set; }
	}
}