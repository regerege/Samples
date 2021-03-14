using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ModelClass
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("char")]
        public char Character { get; set; }
    }

    class Program
    {
        private static void JsonSample01()
        {
            var json = @"
[
  { 'id': 65, 'char': 'A' },
  { 'id': 66, 'char': 'B' }
]";
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModelClass>>(json);
            json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            Console.WriteLine(json);
            foreach(var model in list)
            {
                Console.WriteLine($"{model.Id} : {model.Character}");
            }
        }

        private static void JsonSample02()
        {
            var json = @"
[
    [ 'a', 'b', 'c' ],
    [ 'd', 'e', 'f' ],
    [ 'g', 'h', 'i' ]
]
";
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<string[][]>(json);
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"obj[{i}][0] = '{obj[i][0]}'");
                Console.WriteLine($"obj[{i}][1] = '{obj[i][1]}'");
                Console.WriteLine($"obj[{i}][2] = '{obj[i][2]}'");
            }
        }

        static void Main(string[] args)
        {
            JsonSample02();
        }
    }
}
