using System;
using System.Collections.Generic;

namespace BombGame

{

  class Bomb
  {
    public static List<List<string>> Solution = new List<List<string>>();
    public static List<string> Printable = new List<string>();
    public static List<string> TestedParts = new List<string>();
    public static Random rnd = new Random();
    private static string [] Parts = new string [] {"Red Wire", "Blue Wire", "Green Wire", "Black Wire", "White Wire", "Omega Switch", "Gamma Switch", "Orange Button", "Green Button", "Lime Wire", "Purple Wire", "Turqoise Button", "Yellow Wire", "Alpha Switch", "Epsilon Switch", "Blue Button", "Black Button"};
    private static string [] Traps = new string [] {"Red Button", "Blue Button", "Green Button", "Black Button", "White Button", "Purple Wire", "Mauve Wire", "Orange Switch", "Green Switch", "Lime Button", "Purple Button", "Turqoise Wire", "Yellow Button", "Alpha Button", "Epsilon Button", "Blue Switch", "Black Switch", "Red Switch"};
 
    public static List<List<string>> StageBuilder(int parts, int traps) 
        {
            Solution.Clear();
            Printable.Clear();
            List<string> stageList = new List<string>();
            List<string> trapsList = new List<string>();
            int i = 0;
            int t = 0;
            while( i < parts)
            {
                int index = rnd.Next(0,17);
                string part = Bomb.GetParts(index);
                if (!stageList.Contains(part))
                {
                    stageList.Add(part);
                    Printable.Add(part);
                    i++;
                }
            }
            Solution.Add(stageList);
            while( t < traps)
            {
                int index = rnd.Next(0,18);
                string trap = Bomb.GetTraps(index);
                if (!trapsList.Contains(trap) && !stageList.Contains(trap))
                {
                    trapsList.Add(trap);
                    Printable.Add(trap);
                    t++;
                }
            }
            Solution.Add(trapsList);
            return Solution;
        }

    public static string disarmAttempt(string component)
    {
        string success = "";
        if (Solution[0][0] == component)
        {
            success = "success";
            Printable.Remove(component);
            Solution[0].Remove(component);
            if (TestedParts.Contains(component))
            {
                TestedParts.Remove(component);
            }
        }
        else if (Solution[0].Contains(component))
        {
            if (!TestedParts.Contains(component))
            {
                TestedParts.Add(component);
            }
            success = "fail";
        }
        else if (Solution[1].Contains(component))
        {
            Printable.Remove(component);
            success = "trap";
        }
        return success;

    }

    public static string GetParts(int i)
    {
        return Parts[i];
    }
    public static string GetTraps(int i)
    {
        return Traps[i];
    }

    }
}


    