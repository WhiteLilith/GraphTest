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
            
            IBranch stationsGreenBranch = CreateBranch(stationNamesGreen, "Замоскворецкая линия", 
                                            "green", ref branch_id, ref stations_id);
            IBranch stationsRedBranch = CreateBranch(stationsNamesRed, "Сокольническая линия",
                                            "red", ref branch_id, ref stations_id);

            stationsGreenBranch.ConnectBranches(stationsRedBranch.GetStationByName("Охотный Ряд"),
                stationsGreenBranch.GetStationByName("Театральная"));

            // ShowConnectedStations(stationsRedBranch, "Охотный Ряд");

            IPathFinder pathFinder = new PathFinder();
            List<IStation> path = pathFinder.FindPath(stationsGreenBranch.GetStationByName("Царицыно"), 
                stationsRedBranch.GetStationByName("Бульвар Рокоссовского"), null);

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
