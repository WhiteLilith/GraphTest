using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int stations_id = 0;
            int branch_id = 0;

            string[] stationNamesGreen = {"Ховрино",
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
                                    "Площадь Свердлова",
                                    "Новокузнецкая",
                                    "Павелецкая",
                                    "Автозаводская",
                                    "Завод имени Сталина",
                                    "Технопарк",
                                    "Коломенская",
                                    "Каширская",
                                    "Кантемировская",
                                    "Царицыно",
                                    "Ленино",
                                    "Орехово",
                                    "Домодедовская",
                                    "Красногвардейская",
                                    "Алма - Атинская" };

            IBranch stationsGreenBranch = CreateBranch(stationNamesGreen, "Замоскворецкая линия", 
                                            "green", ref branch_id, ref stations_id);

            ShowConnectedStations(stationsGreenBranch, "Алма - Атинская");
        }

        static IBranch CreateBranch(string[] stations, string branchName, 
            string branchColor, ref int branchID, ref int stationsID)
        {
            List<IStation> stationsBranch = new List<IStation>(0);
            for (int i = stationsID; i < stations.Length; i++, stationsID++)
            {
                stationsBranch.Add(new Station(stations[i], stationsID.ToString()));
                if (i > 0)
                {
                    stationsBranch[i - 1].ConnectStation(stationsBranch[i], true);
                }
            }

            IBranch branch = new Branch(branchName, branchID.ToString(), branchColor, stationsBranch);
            branchID++;
            return branch;
        }

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
