namespace Shared
{
	public class StringMessage : IGenericMessage
	{
		public StringMessage(string payload)
		{
			Payload = payload;
		}

		public string Type
		{
			get
			{
				var type = typeof(StringMessage);
				return $"{type.FullName}, {type.Assembly.GetName().Name}";
			}
		}

		public object Payload { get; }
	}
}