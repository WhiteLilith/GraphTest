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
                "Горьковская",
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

            
            IBranch stationsGreenBranch = CreateBranch(stationNamesGreen, "Замоскворецкая линия", 
                                            "green", ref branch_id, ref stations_id);
            IBranch stationsRedBranch = CreateBranch(stationsNamesRed, "Сокольническая линия",
                                            "red", ref branch_id, ref stations_id);
            IBranch stationsBlueBranch = CreateBranch(stationsNamesBlue, "Арбатско-покровская линия",
                                            "blue", ref branch_id, ref stations_id);
            IBranch stationsBrownBranch = CreateBranch(stationsNamesBrown, "Кольцевая линия",
                                            "brown", ref branch_id, ref stations_id);

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
               
            // ShowConnectedStations(stationsRedBranch, "Охотный Ряд");

            IPathFinder pathFinder = new PathFinder();
            
            List<IStation> path = pathFinder.FindPath(stationsBlueBranch.GetStationByName("Щёлковская"),
                stationsGreenBranch.GetStationByName("Царицыно"), null);

            foreach(var station in path)
            {
                Console.WriteLine(station.GetStationName(), "\n");
            }
        }

        /// <summary>
        /// Создание ветки
        /// </summary>
        /// <param name="stations"></param>
        /// <param name="branchName"></param>
        /// <param name="branchColor"></param>
        /// <param name="branchID"></param>
        /// <param name="stationsID"></param>
        /// <returns></returns>
        static IBranch CreateBranch(string[] stations, string branchName, 
            string branchColor, ref int branchID, ref int stationsID)
        {
            List<IStation> stationsBranch = new List<IStation>(0);
            for (int i = 0; i < stations.Length; i++, stationsID++)
            {
                if (i == 0 || i == stations.Length)
                {
                    stationsBranch.Add(new Station(stations[i], stationsID.ToString(), true));
                }
                else
                {
                    stationsBranch.Add(new Station(stations[i], stationsID.ToString(), false));
                }
                if (i > 0)
                {
                    stationsBranch[i - 1].ConnectStation(stationsBranch[i], true);
                }
            }

            IBranch branch = new Branch(branchName, branchID.ToString(), branchColor, stationsBranch);
            branchID++;
            return branch;
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
