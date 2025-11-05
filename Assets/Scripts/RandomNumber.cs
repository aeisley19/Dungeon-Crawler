using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System;
using Unity.VisualScripting;
using System.Diagnostics;
using Unity;

public class RandomNumber
{
    private HashSet<int> excludeList = new();
    Random rand = new Random();

    public void AddExclude(int exclusion)
    {
        excludeList.Add(exclusion);
    }

    public void ClearExlude()
    {
        excludeList.Clear();
    }
    
    public int? GetNumber(int min, int max)
    {
        IEnumerable<int> range = Enumerable.Range(min, max).Where(i => !excludeList.Contains(i));
        int index = rand.Next(min, max - excludeList.Count());

        if (excludeList.Count == max) return null;
        
        return range.ElementAt(index);
    }
    
}
