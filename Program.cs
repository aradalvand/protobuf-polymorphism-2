using System.Text.Json;
using Google.Protobuf;

var eventToSerialize = new PolymorphicProtobuf.Event
{
	BisarEvent = new()
	{
		Bar = "abc",
	},
};
Console.WriteLine("eventToSerialize: " + JsonSerializer.Serialize(eventToSerialize, options: new() { WriteIndented = true }));

var bytes = eventToSerialize.ToByteArray();
var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(eventToSerialize);
Console.WriteLine($"--- protobuf byte array length: {bytes.Length} VS JSON: {jsonBytes.Length} ---");

var deserializedEvent = PolymorphicProtobuf.Event.Parser.ParseFrom(bytes);
Console.WriteLine("deserializedEvent: " + JsonSerializer.Serialize(deserializedEvent, options: new() { WriteIndented = true }));
