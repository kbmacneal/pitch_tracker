// Generated by https://quicktype.io

namespace player_tracker.Classes
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class DodgerPlayer
    {
        [JsonProperty("roster_40")]
        public Roster40 Roster40 { get; set; }
    }

    public class PitcherModel
    {
        public string Name { get; set; }
        public string Throws { get; set; }
    }

    public partial class Roster40
    {
        [JsonProperty("copyRight")]
        public string CopyRight { get; set; }

        [JsonProperty("queryResults")]
        public QueryResults QueryResults { get; set; }
    }

    public partial class QueryResults
    {
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("totalSize")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TotalSize { get; set; }

        [JsonProperty("row")]
        public Dictionary<string, string>[] Row { get; set; }
    }

    public partial class DodgerPlayer
    {
        public static DodgerPlayer FromJson(string json) => JsonConvert.DeserializeObject<DodgerPlayer>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DodgerPlayer self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}