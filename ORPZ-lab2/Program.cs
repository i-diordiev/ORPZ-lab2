using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace ORPZ_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            
            #region Initializing lists with data

            List<Helicopter> helicopters = new List<Helicopter>()
            {
                new Helicopter() { Type = "Eurocopter EC120", MaximumHeight = 5180, MaximumFlightRange = 727, LoadCapacity = 755, AirlineId = 1},
                new Helicopter() { Type = "Eurocopter EC120", MaximumHeight = 5180, MaximumFlightRange = 727, LoadCapacity = 755, AirlineId = 1},
                new Helicopter() { Type = "Eurocopter EC130", MaximumHeight = 7010, MaximumFlightRange = 606, LoadCapacity = 1160, AirlineId = 1},
                new Helicopter() { Type = "Sikorsky S-70", MaximumHeight = 5835, MaximumFlightRange = 584, LoadCapacity = 1200, AirlineId = 1},
                new Helicopter() { Type = "Sikorsky S-76", MaximumHeight = 3870, MaximumFlightRange = 761, LoadCapacity = 1616, AirlineId = 1},
                new Helicopter() { Type = "Eurocopter EC120", MaximumHeight = 5180, MaximumFlightRange = 727, LoadCapacity = 755, AirlineId = 2},
                new Helicopter() { Type = "Eurocopter EC130", MaximumHeight = 7010, MaximumFlightRange = 606, LoadCapacity = 1160, AirlineId = 2},
                new Helicopter() { Type = "Sikorsky S-70", MaximumHeight = 5835, MaximumFlightRange = 584, LoadCapacity = 1200, AirlineId = 2},
                new Helicopter() { Type = "Sikorsky S-70", MaximumHeight = 5835, MaximumFlightRange = 584, LoadCapacity = 1200, AirlineId = 2},
                new Helicopter() { Type = "Eurocopter EC130", MaximumHeight = 7010, MaximumFlightRange = 606, LoadCapacity = 1160, AirlineId = 3},
                new Helicopter() { Type = "Sikorsky S-70", MaximumHeight = 5835, MaximumFlightRange = 584, LoadCapacity = 1200, AirlineId = 3},
                new Helicopter() { Type = "Sikorsky S-70", MaximumHeight = 5835, MaximumFlightRange = 584, LoadCapacity = 1200, AirlineId = 3},
                new Helicopter() { Type = "Eurocopter EC120", MaximumHeight = 5180, MaximumFlightRange = 727, LoadCapacity = 755, AirlineId = 4},
                new Helicopter() { Type = "Eurocopter EC120", MaximumHeight = 5180, MaximumFlightRange = 727, LoadCapacity = 755, AirlineId = 4},
                new Helicopter() { Type = "Eurocopter EC130", MaximumHeight = 7010, MaximumFlightRange = 606, LoadCapacity = 1160, AirlineId = 4}
            };
            
            List<Plane> planes = new List<Plane>()
            {
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 11135, TakeoffRunLength = 2500, AirlineId = 1},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 11135, TakeoffRunLength = 2500, AirlineId = 1},
                new Plane() {Type = "Airbus A330", Wingspan = 60.3f, LoadCapacity = 45000, MaximumFlightRange = 13400, TakeoffRunLength = 2300, AirlineId = 1},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 1},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 1},
                new Plane() {Type = "Airbus A350", Wingspan = 64.75f, LoadCapacity = 30000, MaximumFlightRange = 15200, TakeoffRunLength = 2600, AirlineId = 2},
                new Plane() {Type = "Airbus A350", Wingspan = 64.75f, LoadCapacity = 30000, MaximumFlightRange = 15200, TakeoffRunLength = 2600, AirlineId = 2},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 40000, MaximumFlightRange = 11135, TakeoffRunLength = 3410, AirlineId = 2},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 40000, MaximumFlightRange = 11135, TakeoffRunLength = 3410, AirlineId = 2},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 2},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 2},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 9695, TakeoffRunLength = 2500, AirlineId = 3},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 9695, TakeoffRunLength = 2500, AirlineId = 3},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 9695, TakeoffRunLength = 2500, AirlineId = 3},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 3},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 3},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 3},
                new Plane() {Type = "Airbus A380", Wingspan = 79.75f, LoadCapacity = 50000, MaximumFlightRange = 15200, TakeoffRunLength = 2050, AirlineId = 3},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 9695, TakeoffRunLength = 2500, AirlineId = 4},
                new Plane() {Type = "Boeing 777", Wingspan = 60.9f, LoadCapacity = 35000, MaximumFlightRange = 9695, TakeoffRunLength = 2500, AirlineId = 4},
                new Plane() {Type = "Boeing 787", Wingspan = 60.17f, LoadCapacity = 42000, MaximumFlightRange = 13620, TakeoffRunLength = 3100, AirlineId = 4},
                new Plane() {Type = "Airbus A350", Wingspan = 64.75f, LoadCapacity = 30000, MaximumFlightRange = 15200, TakeoffRunLength = 2600, AirlineId = 4},
                new Plane() {Type = "Airbus A350", Wingspan = 64.75f, LoadCapacity = 30000, MaximumFlightRange = 15200, TakeoffRunLength = 2600, AirlineId = 4}
            };
            
            List<Airline> airlines = new List<Airline>()
            {
                new Airline() { Id = 1, Name = "Qatar Airways", OfficeLocation = "Doha", DateOfCreation = new DateTime(1994, 01, 20)},
                new Airline() { Id = 2, Name = "Singapore Airlines", OfficeLocation = "Singapore", DateOfCreation = new DateTime(1947, 05, 01)},
                new Airline() { Id = 3, Name = "Emirates", OfficeLocation = "Dubai", DateOfCreation = new DateTime(1985, 03, 25)},
                new Airline() { Id = 4, Name = "Japan Airlines", OfficeLocation = "Tokyo", DateOfCreation = new DateTime(1951, 08, 01)}, 
            };

            #endregion
            
            #region Writing the data into .xml file

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            using (XmlWriter writer = XmlWriter.Create("planes.xml", settings))
            {
                writer.WriteStartElement("planes");
                foreach (var plane in planes)
                {
                    writer.WriteStartElement("plane");
                    writer.WriteElementString("type", plane.Type);
                    writer.WriteElementString("wingspan", plane.Wingspan.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("loadCapacity", plane.LoadCapacity.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("maximumFlightRange", plane.MaximumFlightRange.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("takeoffRunLength", plane.TakeoffRunLength.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("airlineId", plane.AirlineId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("helicopters.xml", settings))
            {
                writer.WriteStartElement("helicopters");
                foreach (var helicopter in helicopters)
                {
                    writer.WriteStartElement("helicopter");
                    writer.WriteElementString("type", helicopter.Type);
                    writer.WriteElementString("maximumHeight", helicopter.MaximumHeight.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("maximumFlightRange", helicopter.MaximumFlightRange.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("loadCapacity", helicopter.LoadCapacity.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("airlineId", helicopter.AirlineId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("airlines.xml", settings))
            {
                writer.WriteStartElement("airlines");
                foreach (var airline in airlines)
                {
                    writer.WriteStartElement("airline");
                    writer.WriteElementString("id", airline.Id.ToString());
                    writer.WriteElementString("name", airline.Name);
                    writer.WriteElementString("officeLocation", airline.OfficeLocation);
                    writer.WriteElementString("dateOfCreation", airline.DateOfCreation.ToString(CultureInfo.CurrentCulture));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            #endregion

            #region Reading the data from .xml file

            XDocument planesDoc = XDocument.Load("planes.xml");
            foreach (XElement plane in planesDoc.Descendants("plane"))
            {
                string type = (string) plane.Element("type");
                float wingspan = (float) plane.Element("wingspan");
                float loadCapacity = (float) plane.Element("loadCapacity");
                float maximumFlightRange = (float) plane.Element("maximumFlightRange");
                float takeoffRunLength = (float) plane.Element("takeoffRunLength");
                int airlineId = (int) plane.Element("airlineId");

                Console.WriteLine($"Type - {type}, wingspan - {wingspan}, load capacity - {loadCapacity}, " +
                                  $"maximum flight range - {maximumFlightRange}, takeoff run length - {takeoffRunLength}");
            }
            
            Console.WriteLine("\n");
            
            XDocument helicoptersDoc = XDocument.Load("helicopters.xml");
            foreach (XElement heli in helicoptersDoc.Descendants("helicopter"))
            {
                string type = (string) heli.Element("type");
                float maximumHeight = (float) heli.Element("maximumHeight");
                float maximumFlightRange = (float) heli.Element("maximumFlightRange");
                float loadCapacity = (float) heli.Element("loadCapacity");
                int airlineId = (int) heli.Element("airlineId");

                Console.WriteLine($"Type - {type}, maximum height - {maximumHeight}, maximum flight range - {maximumFlightRange}, " +
                                  $"load capacity - {loadCapacity}");
            }

            Console.WriteLine("\n");
            
            XDocument airlinesDoc = XDocument.Load("airlines.xml");
            foreach (XElement airline in airlinesDoc.Descendants("airline"))
            {
                int id = (int) airline.Element("id");
                string name = (string) airline.Element("name");
                string officeLocation = (string) airline.Element("officeLocation");
                DateTime dateOfCreation = (DateTime) airline.Element("dateOfCreation");

                Console.WriteLine($"Name - {name}, office location - {officeLocation}, date of creation - {dateOfCreation}");
            }

            Console.WriteLine("\n");

            #endregion

            #region LINQ to XML

            #region Query 1

            Console.WriteLine("Query 1");
            Console.WriteLine("Show information about airlines");
            
            // var query1 = from a in airlines
            //     select a;
            
            var query1 = airlinesDoc.Descendants("airline")
                .Select(el => new Airline()
                {
                    Id = (int) el.Element("id"),
                    Name = (string) el.Element("name"),
                    OfficeLocation = (string) el.Element("officeLocation"),
                    DateOfCreation = (DateTime) el.Element("dateOfCreation")
                });
            
            Console.WriteLine("Result: ");
            foreach (var result in query1)
                Console.WriteLine($"{result.Name}, location - {result.OfficeLocation}, date of creation - {result.DateOfCreation}");

            #endregion
            
            #region Query 2

            Console.WriteLine("\n");
            Console.WriteLine("Query 2");
            Console.WriteLine("Select unique types of planes");
            
            // var query2 = planes.Select(p => p.Type).Distinct();
            
            var query2 = planesDoc.Descendants("plane").Select(el => (string) el.Element("type")).Distinct();
            
            Console.WriteLine("Result: ");
            foreach (var result in query2)
                Console.WriteLine(result);

            #endregion
            
            #region Query 3

            Console.WriteLine("\n");
            Console.WriteLine("Query 3");
            Console.WriteLine("Select planes with wingspan > 62, sort by wingspan and if equal, sort by type");
            
            // var query3 = from p in planes 
            //     where p.Wingspan > 62
            //     orderby p.Wingspan, p.Type
            //     select p;
            
            var query3 = planesDoc.Descendants("plane")
                .Where(el => (float) el.Element("wingspan") > 62)
                .OrderBy(el => (float) el.Element("wingspan"))
                .ThenBy(el => (string) el.Element("type"))
                .Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                });
            
            Console.WriteLine("Result: ");
            foreach (var result in query3)
                Console.WriteLine($"{result.Type}, wingspan - {result.Wingspan}");

            #endregion
            
            #region Query 4

            Console.WriteLine("\n");
            Console.WriteLine("Query 4");
            Console.WriteLine("Show information about helicopters, sorted by maximum height in descending order");
            
            // var query4 = helicopters.Select(h => h).OrderByDescending(h => h.MaximumHeight);
            
            var query4 = helicoptersDoc.Descendants("helicopter")
                .OrderByDescending(el => (float) el.Element("maximumHeight"))
                .Select(el => new Helicopter()
                {
                    Type = (string) el.Element("type"), 
                    MaximumHeight = (float) el.Element("maximumHeight"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    AirlineId = (int) el.Element("airlineId")
                });
                
            Console.WriteLine("Result: ");
            foreach (var result in query4)
                Console.WriteLine($"{result.Type}, maximum height - {result.MaximumHeight}" +
                                  $", maximum flight range - {result.MaximumFlightRange}" +
                                  $", load capacity - {result.LoadCapacity}");

            #endregion
            
            #region Query 5

            Console.WriteLine("\n");
            Console.WriteLine("Query 5");
            Console.WriteLine("Group planes by airline");
            
            // var query5 = from p in planes
            //     group p by p.AirlineId;
            
            var query5 = planesDoc.Descendants("plane")
                .Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .GroupBy(p => p.AirlineId);
            
            Console.WriteLine("Result: ");
            foreach (var result in query5)
            {
                Console.WriteLine("Airline ID: " + result.Key);
                Console.WriteLine("Planes:");
                foreach (var plane in result)
                    Console.WriteLine(plane.Type);

                Console.WriteLine();
            }

            #endregion
            
            #region Query 6

            Console.WriteLine("\n");
            Console.WriteLine("Query 6");
            Console.WriteLine("Group helicopters by airline, sorted by airline ID in descending order");
            
            // var query6 = helicopters.GroupBy(h => h.AirlineId).OrderByDescending(g => g.Key);
            var query6 = helicoptersDoc.Descendants("helicopter")
                .Select(el => new Helicopter()
                {
                    Type = (string) el.Element("type"), 
                    MaximumHeight = (float) el.Element("maximumHeight"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .GroupBy(h => h.AirlineId)
                .OrderByDescending(g => g.Key);
            
            Console.WriteLine("Result: ");
            foreach (var result in query6)
            {
                Console.WriteLine("Airline ID: " + result.Key);
                Console.WriteLine("Planes:");
                foreach (var helicopter in result)
                    Console.WriteLine(helicopter.Type);
                
                Console.WriteLine();
            }

            #endregion
            
            #region Query 7

            Console.WriteLine("\n");
            Console.WriteLine("Query 7");
            Console.WriteLine("Get total load capacity of planes that belongs to each airline, sorted in ascending order");
            
            // var query7 = from p in planes
            //     group p by p.AirlineId into g
            //     select new { 
            //         Airline = airlines.Where(a => a.Id == g.Key).Select(a => a.Name).FirstOrDefault(),
            //         TotalCapacity = g.Sum(p => p.LoadCapacity) 
            //     };
            
            var query7 = from p in planesDoc.Descendants("plane")
                    .Select(el => new Plane()
                    {
                        Type = (string) el.Element("type"), 
                        Wingspan = (float) el.Element("wingspan"), 
                        LoadCapacity = (float) el.Element("loadCapacity"), 
                        MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                        TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                        AirlineId = (int) el.Element("airlineId")
                    })
                group p by p.AirlineId into g
                select new { 
                    Airline = airlines.Where(a => a.Id == g.Key).Select(a => a.Name).FirstOrDefault(),
                    TotalCapacity = g.Sum(p => p.LoadCapacity) 
                };
            
            Console.WriteLine("Result: ");
            foreach (var result in query7)
                Console.WriteLine($"Airline - {result.Airline}, total load capacity - {result.TotalCapacity}");

            #endregion
            
            #region Query 8

            Console.WriteLine("\n");
            Console.WriteLine("Query 8");
            Console.WriteLine("Get a type of plane and name of airline it belongs to");
            
            // var query8 = planes.Join(airlines,
            //     p => p.AirlineId,
            //     a => a.Id,
            //     (p, a) => new { Airline = a.Name, Type = p.Type });

            var query8 = planesDoc.Descendants("plane").Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .Join(airlinesDoc.Descendants("airline").Select(el => new Airline()
                    {
                        Id = (int) el.Element("id"),
                        Name = (string) el.Element("name"),
                        OfficeLocation = (string) el.Element("officeLocation"),
                        DateOfCreation = (DateTime) el.Element("dateOfCreation")
                    }),
                    p => p.AirlineId,
                    a => a.Id,
                    (p, a) => new { Airline = a.Name, p.Type });
            
            Console.WriteLine("Result: ");
            foreach (var result in query8)
                Console.WriteLine($"Type - {result.Type}, airline - {result.Airline}");

            #endregion
            
            #region Query 9

            Console.WriteLine("\n");
            Console.WriteLine("Query 9");
            Console.WriteLine("Get total count of planes");
            
            // var query9 = planes.Count();

            var query9 = planesDoc.Descendants("plane").Count();
            
            Console.WriteLine($"Result: {query9}");

            #endregion
            
            #region Query 10

            Console.WriteLine("\n");
            Console.WriteLine("Query 10");
            Console.WriteLine("Get planes with load capacity > 37000, except planes with wingspan > 70");
            
            // var query10 = planes.Where(p => p.LoadCapacity > 37000)
            //     .Except(planes.Where(p2 => p2.Wingspan > 70));
            
            var query10 = planesDoc.Descendants("plane").Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .Where(p => p.LoadCapacity > 37000)
                .Except(planes.Where(p2 => p2.Wingspan > 70));
            
            Console.WriteLine("Result: ");
            foreach (var result in query10)
                Console.WriteLine($"{result.Type}, wingspan - {result.Wingspan}, load capacity - {result.LoadCapacity}");

            #endregion
            
            #region Query 11

            Console.WriteLine("\n");
            Console.WriteLine("Query 11");
            Console.WriteLine("Get types of all aircrafts that belongs to \"Emirates\"");
            
            // var query11 = planes.Join(airlines,
            //         p => p.AirlineId,
            //         a => a.Id,
            //         (p, a) => new { Aircraft = p.Type, Airline = a.Name })
            //     .Where(t => t.Airline == "Emirates")
            //     .Union(helicopters.Join(airlines,
            //         h => h.AirlineId,
            //         a => a.Id,
            //         (h, a) => new { Aircraft = h.Type, Airline = a.Name })
            //         .Where(t1 => t1.Airline == "Emirates"));
            
            var query11 = planesDoc.Descendants("plane").Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .Join(airlinesDoc.Descendants("airline").Select(el => new Airline()
                {
                    Id = (int) el.Element("id"),
                    Name = (string) el.Element("name"),
                    OfficeLocation = (string) el.Element("officeLocation"),
                    DateOfCreation = (DateTime) el.Element("dateOfCreation")
                }),
                p => p.AirlineId,
                a => a.Id,
                (p, a) => new { Aircraft = p.Type, Airline = a.Name })
                .Where(t => t.Airline == "Emirates")
                .Union(helicoptersDoc.Descendants("helicopter").Select(el => new Helicopter()
                    {
                        Type = (string) el.Element("type"), 
                        MaximumHeight = (float) el.Element("maximumHeight"), 
                        MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                        LoadCapacity = (float) el.Element("loadCapacity"), 
                        AirlineId = (int) el.Element("airlineId")
                    })
                    .Join(airlinesDoc.Descendants("airline").Select(el => new Airline()
                    {
                        Id = (int) el.Element("id"),
                        Name = (string) el.Element("name"),
                        OfficeLocation = (string) el.Element("officeLocation"),
                        DateOfCreation = (DateTime) el.Element("dateOfCreation")
                    }),
                    h => h.AirlineId,
                    a => a.Id,
                    (h, a) => new { Aircraft = h.Type, Airline = a.Name })
                    .Where(t1 => t1.Airline == "Emirates"));
            
            Console.WriteLine("Result: ");
            foreach (var result in query11)
                Console.WriteLine(result.Aircraft);

            #endregion
            
            #region Query 12

            Console.WriteLine("\n");
            Console.WriteLine("Query 12");
            Console.WriteLine("Get number of helicopters for each airline");
            
            // var query12 = from a in airlines
            //     join h in helicopters on a.Id equals h.AirlineId into temp
            //     select new { Airline = a.Name, NumOfHelis = temp.Count() };
            
            var query12 = from a in airlinesDoc.Descendants("airline").Select(el => new Airline()
                {
                    Id = (int) el.Element("id"),
                    Name = (string) el.Element("name"),
                    OfficeLocation = (string) el.Element("officeLocation"),
                    DateOfCreation = (DateTime) el.Element("dateOfCreation")
                })
                join h in helicoptersDoc.Descendants("helicopter").Select(el => new Helicopter()
                {
                    Type = (string) el.Element("type"), 
                    MaximumHeight = (float) el.Element("maximumHeight"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    AirlineId = (int) el.Element("airlineId")
                }) on a.Id equals h.AirlineId into temp
                select new { Airline = a.Name, NumOfHelis = temp.Count() };
            
            Console.WriteLine("Result: ");
            foreach (var result in query12)
                Console.WriteLine($"{result.Airline} - {result.NumOfHelis}");
            

            #endregion
            
            #region Query 13

            Console.WriteLine("\n");
            Console.WriteLine("Query 13");
            Console.WriteLine("Get all helicopters, except first, for each airline");
            
            // var query13 = helicopters.GroupBy(h => h.AirlineId)
            //     .Select(g => new
            //     {
            //         Airline = airlines.FirstOrDefault(a => g.Key == a.Id),
            //         Helicopters = g.Skip(1)
            //     });
            
            var query13 = helicoptersDoc.Descendants("helicopter").Select(el => new Helicopter()
                {
                    Type = (string) el.Element("type"), 
                    MaximumHeight = (float) el.Element("maximumHeight"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                .GroupBy(h => h.AirlineId)
                .Select(g => new
                {
                    Airline = airlines.FirstOrDefault(a => g.Key == a.Id),
                    Helicopters = g.Skip(1)
                });
            
            Console.WriteLine("Result: ");
            foreach (var result in query13)
            {
                Console.WriteLine(result.Airline);
                foreach (var heli in result.Helicopters)
                    Console.WriteLine(heli.Type);
            }

            #endregion
            
            #region Query 14

            Console.WriteLine("\n");
            Console.WriteLine("Query 14");
            Console.WriteLine("Get count of planes, grouped by maximum flight range");
            
            // var query14 = from p in planes
            //     group p by p.MaximumFlightRange
            //     into g
            //     select new { MaxFlightRange = g.Key, PlanesCount = g.Count() };
            
            var query14 = from p in planesDoc.Descendants("plane").Select(el => new Plane()
                {
                    Type = (string) el.Element("type"), 
                    Wingspan = (float) el.Element("wingspan"), 
                    LoadCapacity = (float) el.Element("loadCapacity"), 
                    MaximumFlightRange = (float) el.Element("maximumFlightRange"), 
                    TakeoffRunLength = (float) el.Element("takeoffRunLength"), 
                    AirlineId = (int) el.Element("airlineId")
                })
                group p by p.MaximumFlightRange
                into g
                select new { MaxFlightRange = g.Key, PlanesCount = g.Count() };
            
            Console.WriteLine("Result: ");
            foreach (var result in query14)
                Console.WriteLine($"Flight range - {result.MaxFlightRange}, planes count - {result.PlanesCount}");

            #endregion
            
            #region Query 15

            Console.WriteLine("\n");
            Console.WriteLine("Query 15");
            Console.WriteLine("Get total load capacity of helicopters");
            
            // var query15 = helicopters.Sum(h => h.LoadCapacity);

            var query15 = helicoptersDoc.Descendants("helicopter").Sum(el => (float) el.Element("loadCapacity"));
            
            Console.WriteLine($"Result: {query15}");

            #endregion
            
            #endregion
        }
    }
}