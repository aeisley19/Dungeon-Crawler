using UnityEngine;

public sealed class RupeeManager
{
    private static RupeeManager instance = null;
    private static readonly object padlock = new object();
    private int rupeeCount = 0;

    public static RupeeManager Instance
    {
        get
        {
            lock(padlock)
            {
                instance ??= new RupeeManager();

                return instance;
            }
        }        
    }
    
    public int RupeeCount { get { return rupeeCount; } }

    public void AddRupees(int amount)
    {
        rupeeCount += amount;
    }

    public void LoseRupees(int amount) 
    {
        rupeeCount -= amount;
    }
}
