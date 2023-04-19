using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PolygonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр полигона
            Polygon polygon = new Polygon();
            polygon.type = "FeatureCollection";
            polygon.features = new List<Feature>()
            {
                new Feature()
                {
                    type = "Feature",
                    geometry = new Geometry()
                    {
                        type = "Point",
                        coordinates = new double[] { 102.0, 0.5 }
                    },
                    properties = new Dictionary<string, object>()
                    {
                        { "prop0", "value0" }
                    }
                },
                new Feature()
                {
                    type = "Feature",
                    geometry = new Geometry()
                    {
                        type = "LineString",
                        coordinates = new List<double[]>()
                        {
                            new double[] { 102.0, 0.0 },
                            new double[] { 103.0, 1.0 },
                            new double[] { 104.0, 0.0 },
                            new double[] { 105.0, 1.0 }
                        }
                    },
                    properties = new Dictionary<string, object>()
                    {
                        { "prop0", "value0" },
                        { "prop1", 0.0 }
                    }
                },
                new Feature()
                {
                    type = "Feature",
                    geometry = new Geometry()
                    {
                        type = "Polygon",
                        coordinates = new List<List<double[]>>()
                        {
                            new List<double[]>()
                            {
                                new double[] { 100.0, 0.0 },
                                new double[] { 101.0, 0.0 },
                                new double[] { 101.0, 1.0 },
                                new double[] { 100.0, 1.0 },
                                new double[] { 100.0, 0.0 }
                            }
                        }
                    },
                    properties = new Dictionary<string, object>()
                    {
                        { "prop0", "value0" },
                        { "prop1", new Dictionary<string, object>()
                            {
                                { "this", "that" }
                            }
                        }
                    }
                }
            };
            // Сериализуем полигон в JSON-строку
            string polygonJson = JsonConvert.SerializeObject(polygon, Formatting.Indented);
            Console.WriteLine(polygonJson);

            // Записываем JSON-строку в файл
            string filePath = @"D:\data.json";
            File.WriteAllText(filePath, polygonJson);
            Console.WriteLine($"Файл {filePath} успешно создан.");
        }
    }

    // Классы для сериализации в JSON
    public class Polygon
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Dictionary<string, object> properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public object coordinates { get; set; }
    }
}





