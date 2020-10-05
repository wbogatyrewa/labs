/*
На основе одной из готовых обобщенных (шаблонных) объектных коллекций .NET создать класс
«Авиакомпания», включающий список самолетов. Классы самолетов должны образовывать
иерархию с базовым классом. Самолеты бывают двух типов: пассажирские и грузовые. Описать в
базовом классе абстрактный метод для расчета взлетного веса самолета. Для пассажирских
авиалайнеров взлетный вес – это количество мест на средний вес человека (62 кг.), для
грузовиков взлетный вес задается явно исходя из фактического веса груза, также взлетный вес
включает вес самого самолета, он определяется исходя из типа авиалайнера. В виде меню
программы реализовать нижеприведенный функционал.
1. Упорядочить всю последовательность авиалайнеров по возрастанию взлетного веса. При
совпадении взлетного веса – упорядочивать данные по номеру рейса. Вывести номер рейса, тип
самолета, список ФИО экипажа и взлетный вес для всех элементов списка.
2. Вывести первые 5 бортов из полученного в пункте 1 списка.
3. Вывести последние 3 номера рейса борта из полученного в пункте 1 списка.
4. В реальном времени (в процессе заполнения списка авиалайнеров) рассчитывать и
поддерживать в актуальном состоянии средний взлетный вес самолета по авиакомпании,
сохранить значение как поле класса «Авиакомпания».
5. Организовать запись и чтение всех данных в/из файла. Реализовать поддержку формата файлов
JSON.
6. Организовать обработку некорректного формата входного файла.
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace labs {
    
    class lab3 {
        public void Main3() {

            Airline aeroflot = new Airline();

            aeroflot.Planes.Add(new Cargo { flight = 8451, crew = { "Nika", "Vova" }, 
                                            weightOfPlane = 554, weightOfCargo = 7964 });
            aeroflot.Planes.Add(new Passenger { flight = 6845, crew = { "Dasha", "Igor" }, 
                                            weightOfPlane = 145, seat = 512 });
            aeroflot.Planes.Add(new Cargo { flight = 4314, crew = { "Alex", "Sasha" }, 
                                            weightOfPlane = 431, weightOfCargo = 3424 });
            aeroflot.Planes.Add(new Passenger { flight = 4541, crew = { "Misha", "Taya" }, 
                                            weightOfPlane = 214, seat = 165 });
            aeroflot.Planes.Add(new Passenger { flight = 9984, crew = { "Sasha", "Nastya" }, 
                                            weightOfPlane = 354, seat = 202 });
            
            while (true) {
                Console.WriteLine("FUNCTION: add, sort, print5, print3, average, write and read");
                string func = Console.ReadLine();
                if (func == "add") {
                    // Добавить новый самолет в авиакомпанию
                    Console.WriteLine("Enter flight");
                    int flight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter crew");
                    List<string> crew = Console.ReadLine().Split(",").ToList<string>();
                    Console.WriteLine("Enter weight of plane");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter type of plane");
                    string type = Console.ReadLine();
                    if (type == "Cargo" || type == "cargo") {
                        Console.WriteLine("Enter weight of cargo");
                        int weightCargo =  Convert.ToInt32(Console.ReadLine());
                        aeroflot.AddPlane(new Cargo { flight = flight, crew = crew, 
                                                    weightOfPlane = weight, weightOfCargo = weightCargo });
                    } else if (type == "Passenger" || type == "passenger") {
                        Console.WriteLine("Enter seat");
                        int seat =  Convert.ToInt32(Console.ReadLine());
                        aeroflot.AddPlane(new Passenger { flight = flight, crew = crew, 
                                                    weightOfPlane = weight, seat = seat });
                    }
                } else if (func == "sort") {
                    // Сортировка списка самолетов, затем его вывод
                    aeroflot.SortByWeight();
                    PrintPlanes(aeroflot.Planes, 0, aeroflot.Planes.Count);
                } else if (func == "print5") {
                    // Вывод первых 5 бортов 
                    Console.WriteLine("Pervye 5 bortov");
                    PrintPlanes(aeroflot.Planes, 0, 5);
                } else if (func == "print3") {
                    // Вывод последних 3х бортов
                    Console.WriteLine("Poslednie 3 borta");
                    aeroflot.Planes.Reverse();
                    PrintPlanes(aeroflot.Planes, 0, 3);
                    aeroflot.Planes.Reverse();
                } else if (func == "average") {
                    // Средний взлетный вес самолета по авиакомпании
                    aeroflot.averageWeight = AverageWeightOfPlane(aeroflot);
                    Console.WriteLine("Average weight = {0:0.0}", aeroflot.averageWeight);
                } else if (func == "write") {
                    // Запись данных в файл JSON
                    Console.WriteLine("Enter filename");
                    string FileWriter = Console.ReadLine();
                    var options = new JsonSerializerOptions {
                        Converters = { new BaseClassConverter() },
                        WriteIndented = true
                    };
                    string jsonWriter = JsonSerializer.Serialize<object>(aeroflot.Planes, options);
                    File.WriteAllText(FileWriter, jsonWriter);
                } else if (func == "read") {
                    // Чтение данных из файла и обработка некорректного формата входного файла
                    try {
                        Console.WriteLine("Enter filename");
                        string FileReader = Console.ReadLine();
                        if (Path.GetExtension(FileReader) != ".json") {
                            // проверка на расширение
                            throw new Exception("Invalid file extension. Required .json");
                        } else if (!File.Exists(FileReader)) {
                            // проверка на существование файла
                            throw new Exception("File doesn't exist");
                        } else if (new FileInfo(FileReader).Length == 0) {
                            // проверка на пустоту файла
                            throw new Exception("File is empty");
                        } else {
                            var options = new JsonSerializerOptions {
                                Converters = { new BaseClassConverter() },
                                WriteIndented = true
                            };
                            string jsonReader = File.ReadAllText(FileReader);
                            var airline = JsonSerializer.Deserialize<List<Plane>>(jsonReader, options);
                            PrintPlanes(airline, 0, airline.Count);
                        }
                    } catch (Exception e) {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }
                Console.WriteLine("DO YOU WANT TO CONTINUE? y or n");
                string cont = Console.ReadLine();
                if (cont == "n") {
                    break;
                }
            }
        }

        static void PrintPlanes(List<Plane> airline, int begin, int end) {
            for (int i = begin; i < end; i++) {
                Plane p = airline[i];
                Console.WriteLine("№ {0}, Type: {1}, TakeOff weight: {2}",
                                    p.flight, p.GetTypePlane(), p.TakeoffWeight());
                Console.Write("Crew: ");
                foreach (string c in p.crew) {
                    Console.Write("{0}, ", c);
                }
                Console.WriteLine();
            }
        }

        static double AverageWeightOfPlane(Airline airline) {
            // рассчет среднего взлетного веса всех самолетов авиакомпании
            double s = 0.0;
            foreach (Plane plane in airline.Planes) {
                s += plane.TakeoffWeight();
            }
            double average = s/airline.Planes.Count;
            return average;
        }
    }
    public class BaseClassConverter : JsonConverter<Plane> {
        // перегрузка операторов чтения и записи для Json сериализации
        private enum TypeDiscriminator {
            Plane = 0,
            Cargo = 1,
            Passenger = 2
        }
        public override bool CanConvert(Type type) {
            return typeof(Plane).IsAssignableFrom(type);
        }

        public override Plane Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) {

            if (reader.TokenType != JsonTokenType.StartObject) {
                throw new JsonException();
            }
            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName
                    || reader.GetString() != "TypeDiscriminator") {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.Number) {
                throw new JsonException();
            }

            Plane baseClass;
            TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
            switch (typeDiscriminator) {
                case TypeDiscriminator.Cargo:
                    if (!reader.Read() || reader.GetString() != "Cargo") {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) {
                        throw new JsonException();
                    }
                    baseClass = (Cargo)JsonSerializer.Deserialize(ref reader, typeof(Cargo));
                    break;
                case TypeDiscriminator.Passenger:
                    if (!reader.Read() || reader.GetString() != "Passenger") {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) {
                        throw new JsonException();
                    }
                    baseClass = (Passenger)JsonSerializer.Deserialize(ref reader, typeof(Passenger));
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject) {
                throw new JsonException();
            }
            return baseClass;
        }

        public override void Write(
            Utf8JsonWriter writer,
            Plane value,
            JsonSerializerOptions options) {

            writer.WriteStartObject();
            if (value is Cargo cargo) {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Cargo);
                writer.WritePropertyName("Cargo");
                JsonSerializer.Serialize(writer, cargo);
            }
            else if (value is Passenger passenger) {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Passenger);
                writer.WritePropertyName("Passenger");
                JsonSerializer.Serialize(writer, passenger);
            }
            else {
                throw new NotSupportedException();
            }
            writer.WriteEndObject();
        }
    }
    public abstract class Plane {
        public int flight { get; set; }
        public List<string> crew { get; set; } = new List<string>();
        public int weightOfPlane { get; set; }
        public abstract string GetTypePlane();
        public abstract int TakeoffWeight();
    }
    public class Passenger : Plane {
        private int averageHumanWeight = 62;
        public int seat { get; set; }
        public override string GetTypePlane() {
            return "Passenger";
        }
        public override int TakeoffWeight() {
            return seat * averageHumanWeight + weightOfPlane;
        }
    }
    public class Cargo : Plane {
        public int weightOfCargo { get; set; }
        public override string GetTypePlane() {
            return "Cargo";
        }
        public override int TakeoffWeight() {
            return weightOfCargo + weightOfPlane;
        }

    }

    class Airline {
        public List<Plane> Planes { get; set; } = new List<Plane>();
        public double averageWeight { get; set; }

        public List<Plane> SortByWeight() {
            var SortedPlanes = from p in Planes
                               orderby p.TakeoffWeight(), p.flight
                               select p;
            return SortedPlanes.ToList<Plane>();
        }

        public void AddPlane(Plane plane) {
            Planes.Add(plane);
        }
    }
}

