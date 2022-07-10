namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldierList = new List<Soldier>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                switch (soldierType)
                {
                    case "Private":
                        decimal salaryP = decimal.Parse(soldierInfo[4]);
                        var soldierP = new Private(firstName, lastName, id, salaryP);
                        soldierList.Add(soldierP);
                        break;

                    case "LieutenantGeneral":
                        decimal salaryLG = decimal.Parse(soldierInfo[4]);
                        int[] privateList = soldierInfo.Skip(5).Select(int.Parse).ToArray();
                        List<Private> list = new List<Private>();

                        foreach (var idLG in privateList)
                        {
                            Private currentPrivate = (Private) soldierList.First(s => s.Id == idLG);
                            list.Add(currentPrivate);
                        }

                        var soldierLG = new LieutenantGeneral(firstName, lastName, id, salaryLG, list);
                        soldierList.Add(soldierLG);
                        break;

                    case "Engineer":
                        decimal salaryE = decimal.Parse(soldierInfo[4]);
                        string corpE = soldierInfo[5];
                        string[] repairsList = soldierInfo.Skip(6).ToArray();
                        List<Repair> repairs = new List<Repair>();

                        for (int i = 0; i < repairsList.Length; i+=2)
                        {
                            string repairPart = repairsList[i];
                            int repairHours = int.Parse(repairsList[i + 1]);

                            Repair repair = new Repair(repairPart, repairHours);
                            repairs.Add(repair);
                        }

                        Engineer engineer = new Engineer(firstName, lastName, id, salaryE, corpE, repairs);
                        
                        if (engineer.Corps == string.Empty)
                        {
                           continue; 
                        }
                        soldierList.Add(engineer);
                        break;

                    case "Commando":
                        decimal salaryC = decimal.Parse(soldierInfo[4]);
                        string corpC = soldierInfo[5];
                        string[] missionList = soldierInfo.Skip(6).ToArray();
                        List<Mission> missions = new List<Mission>();

                        if (missionList.Length != 0)
                        {
                            for (int i = 0; i < missionList.Length; i += 2)
                            {
                                string codeName = missionList[i];
                                string state = missionList[i + 1];

                                Mission mission = new Mission(codeName, state);
                                missions.Add(mission);
                            }
                        }

                        Commando commando = new Commando(firstName, lastName, id, salaryC, corpC, missions);

                        if (commando.Corps == string.Empty)
                        {
                            continue;
                        }
                        
                        soldierList.Add(commando);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(soldierInfo[4]);
                        Spy spy = new Spy(firstName, lastName, id, codeNumber);
                        soldierList.Add(spy);
                        break;
                }
            }

            foreach (var soldier in soldierList)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
