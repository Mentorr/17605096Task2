using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _17605096_GADE6112_POE
{
    [Serializable]
    class GameEngine
    {
        Map map;
        private int roundnum;
        Random r = new Random();
        GroupBox GBMap;

        public int RoundNum
        {
            get { return roundnum; }
        }

        public GameEngine(int numUnits, int numBuildings, TextBox txtInfo, GroupBox GMap)
        {
            GBMap = GMap;
            map = new Map(numUnits, numBuildings, txtInfo);
            map.Generate();
            map.Display(GBMap);
            
            

            roundnum = 1;
        }
        public void Update()
        {
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25)
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);

                        if (distanceTo <= mu.Attackrange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.Xpos > closestMu.Xpos) 
                                {
                                    mu.Move(0);
                                }
                                else if (mu.Xpos < closestMu.Xpos) 
                                {
                                    mu.Move(2);
                                }
                                else if (mu.Ypos > closestMu.Ypos) 
                                {
                                    mu.Move(3);
                                }
                                else if (mu.Ypos < closestMu.Ypos)
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.Xpos > closestRu.Xpos) 
                                {
                                    mu.Move(0);
                                }
                                else if (mu.Xpos < closestRu.Xpos) 
                                {
                                    mu.Move(2);
                                }
                                else if (mu.Ypos > closestRu.Ypos)
                                {
                                    mu.Move(3);
                                }
                                else if (mu.Ypos < closestRu.Ypos)
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];

                    (Unit closest, int distanceTo) = ru.Closest(map.Units);

                  
                    if (distanceTo <= ru.Attackrange)
                    {
                        ru.isAttacking = true;
                        ru.Combat(closest);
                    }
                    else 
                    {
                        if (closest is MeleeUnit)
                        {
                            MeleeUnit closestMu = (MeleeUnit)closest;
                            if (ru.Xpos > closestMu.Xpos) 
                            {
                                ru.Move(0);
                            }
                            else if (ru.Xpos < closestMu.Xpos)
                            {
                                ru.Move(2);
                            }
                            else if (ru.Ypos > closestMu.Ypos) 
                            {
                                ru.Move(3);
                            }
                            else if (ru.Ypos < closestMu.Ypos)
                            {
                                ru.Move(1);
                            }
                        }
                        else if (closest is RangedUnit)
                        {
                            RangedUnit closestRu = (RangedUnit)closest;
                            if (ru.Xpos > closestRu.Xpos)
                            {
                                ru.Move(0);
                            }
                            else if (ru.Xpos < closestRu.Xpos)
                            {
                                ru.Move(2);
                            }
                            else if (ru.Ypos > closestRu.Ypos)
                            {
                                ru.Move(3);
                            }
                            else if (ru.Ypos < closestRu.Ypos) 
                            {
                                ru.Move(1);
                            }
                        }
                    }
                }
            }
            map.Display(GBMap);
            roundnum++;
        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.Xpos - end.Xpos) + Math.Abs(start.Ypos - end.Ypos);
            }
            return distance;
        }

        public void Read()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fin = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            
        }

       
        
    }
}
