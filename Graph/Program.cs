using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int stations_id = 0;
            int branch_id = 0;

            string[] stationNamesGreen = 
            {
                "Ховрино",
                "Беломорская",
                "Речной вокзал",
                "Водный стадион",
                "Войковская",
                "Сокол",
                "Аэропорт",
                "Динамо",
                "Белорусская",
                "Маяковская",
                "Тверская",
                "Театральная",
                "Новокузнецкая",
                "Павелецкая",
                "Автозаводская",
                "Технопарк",
                "Коломенская",
                "Каширская",
                "Кантемировская",
                "Царицыно",
                "Ленино",
                "Орехово",
                "Домодедовская",
                "Красногвардейская",
                "Алма - Атинская" 
            };

            string[] stationsNamesRed =
            {
                "Бульвар Рокоссовского",
                "Черкизовская",
                "Преображенская площадь",
                "Сокольники",
                "Красносельская",
                "Комсомольская",
                "Красные Ворота",
                "Чистые пруды",
                "Лубянка",
                "Охотный Ряд",
                "Библиотека имени Ленина",
                "Кропоткинская",
                "Парк культуры",
                "Фрунзенская",
                "Спортивная",
                "Воробьёвы горы",
                "Университет",
                "Проспект Вернадского",
                "Юго-Западная",
                "Тропарёво",
                "Румянцево",
                "Саларьево",
                "Филатов луг",
                "Прокшино",
                "Ольховая",
                "Коммунарка"
            };

            string[] stationsNamesBlue =
            {
                "Пятницкое шоссе",
                "Митино",
                "Волоколамская",
                "Мякинино",
                "Строгино",
                "Крылатское",
                "Молодёжная",
                "Кунцевская",
                "Славянский бульвар",
                "Парк Победы",
                "Киевская",
                "Смоленская",
                "Арбатская",
                "Площадь Революции",
                "Курская",
                "Бауманская",
                "Электрозаводская",
                "Семёновская",
                "Партизанская",
                "Измайловская",
                "Первомайская",
                "Щёлковская"
            };

            string[] stationsNamesBrown =
            {
                "Парк культуры",
                "Октябрьская",
                "Добрынинская",
                "Павелецкая",
                "Таганская",
                "Курская",
                "Комсомольская",
                "Проспект Мира",
                "Новослободская",
                "Белорусская",
                "Краснопресненская",
                "Киевская"
            };


            IBranch stationsGreenBranch = new Branch("Замоскворецкая линия", "green", stationNamesGreen);
            IBranch stationsRedBranch = new Branch("Сокольническая линия", "red", stationsNamesRed);
            IBranch stationsBlueBranch = new Branch("Арбатско-покровская линия", "blue", stationsNamesBlue);
            IBranch stationsBrownBranch = new Branch("Кольцевая линия", "brown", stationsNamesBrown);

            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Парк культуры"), 
                stationsBrownBranch.GetStationByName("Киевская"));


            Branch.ConnectBranches(stationsRedBranch.GetStationByName("Охотный Ряд"),
                stationsGreenBranch.GetStationByName("Театральная"));

            Branch.ConnectBranches(stationsBlueBranch.GetStationByName("Площадь Революции"),
                stationsGreenBranch.GetStationByName("Театральная"));

            Branch.ConnectBranches(stationsRedBranch.GetStationByName("Библиотека имени Ленина"),
                stationsBlueBranch.GetStationByName("Арбатская"));

            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Парк культуры"),
                stationsRedBranch.GetStationByName("Парк культуры"));

            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Павелецкая"),
                stationsGreenBranch.GetStationByName("Павелецкая"));

            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Курская"),
                stationsBlueBranch.GetStationByName("Курская"));
            
            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Комсомольская"),
                stationsRedBranch.GetStationByName("Комсомольская"));
            
            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Белорусская"),
                stationsGreenBranch.GetStationByName("Белорусская"));
            
            Branch.ConnectBranches(stationsBrownBranch.GetStationByName("Киевская"),
                stationsBlueBranch.GetStationByName("Киевская"));


            IUnderground underground = new Underground();
            underground.AddBranch(stationsBlueBranch);
            underground.AddBranch(stationsBrownBranch);
            underground.AddBranch(stationsGreenBranch);
            underground.AddBranch(stationsRedBranch);

            // ShowConnectedStations(stationsRedBranch, "Охотный Ряд");

            IPathFinder pathFinder = new BreadthFirstSearch();

            Console.WriteLine("Укажите станцию отправления");
            string departureStation = Console.ReadLine().ToLower();
            Console.WriteLine("Укажите станцию назначения");
            string destinationStation = Console.ReadLine().ToLower();

            List<IStation> path = pathFinder.FindPath(underground.GetStationByName(departureStation),
                underground.GetStationByName(destinationStation));

            int averageTime = 3;
            int destinationTime = path.Count * averageTime;

            Console.WriteLine("\n");
            foreach(var station in path)
            {
                Console.WriteLine(station.GetStationName(), "\n");
            }
            Console.WriteLine($"\nВремя поездки:{destinationTime}");
        }

        /// <summary>
        /// Показ станция, с которыми соединенна текущаяя станция
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="stationName"></param>
        static void ShowConnectedStations(IBranch branch, string stationName)
        {
            List<IStation> stations = branch.GetStationByName(stationName).GetConnectedStations();
            foreach (IStation stat in stations)
            {
                Console.WriteLine(stat.GetStationName() + " " + stat.GetStationID(), "\n");
            }
        }
    }
}
