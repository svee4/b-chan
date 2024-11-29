using System.Text;

#pragma warning disable CA1305 // Specify IFormatProvider
#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA1307 // Specify StringComparison for clarity

const string DiscordSocketClientFieldName = "_socketClient";

var events =
	typeof(Discord.WebSocket.DiscordSocketClient)
	.GetEvents()
	.Select(ev => new EventInfo(ev.Name, ev.EventHandlerType!.GetGenericArguments()))
	.ToList();

var addEvents = new StringBuilder();
var removeEvents = new StringBuilder();
var publishMethods = new StringBuilder();
var records = new StringBuilder();

foreach (var e in events)
{
	var fieldEventName = $"{DiscordSocketClientFieldName}.{e.EventName}";
	var publishMethodName = $"Publish{e.EventName}";
	var recordName = $"{e.EventName}Event";

	addEvents.AppendLine($"{fieldEventName} += {publishMethodName};");
	removeEvents.AppendLine($"{fieldEventName} -= {publishMethodName};");

	var stuff = e.Arguments.Select((type, index) =>
		{
			var arg = $"arg{index + 1}";
			return (Params: $"{TypeToString(type)} {arg}", Args: arg);
		})
		.Take(e.Arguments.Length - 1);

	publishMethods.AppendLine($"""
		private Task {publishMethodName}({string.Join(", ", stuff.Select(t => t.Params))}) =>
			PublishEvent(new {recordName}({string.Join(", ", stuff.Select(t => t.Args))}));
		""");

	records.AppendLine($"public sealed record {recordName}({string.Join(", ", stuff.Select(t => t.Params))});");
}

foreach (var (name, sb) in (List<(string, StringBuilder)>)
	[
		(nameof(addEvents), addEvents),
		(nameof(removeEvents), removeEvents),
		(nameof(publishMethods), publishMethods),
		(nameof(records), records)
	])
{
	File.WriteAllText($"aa_{name}.txt", sb.ToString());
}

static string TypeToString(Type type)
{
	if (!type.IsGenericType)
	{
		return $"{type.Namespace}.{type.Name}";
	}

	var gens = string.Join(", ", type.GetGenericArguments().Select(TypeToString));
	return $"{type.Namespace}.{type.Name[..type.Name.IndexOf('`')]}<{gens}>";
}

record EventInfo(string EventName, Type[] Arguments);
