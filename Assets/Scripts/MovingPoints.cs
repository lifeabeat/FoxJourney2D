using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPoints : MonoBehaviour
{
    public MovingPoints up, right, left, down;
    public bool isLevel,isLocked;
    public string levelToLoad, levelToCheck, levelName;
    

     void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            isLocked = true;

            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_Unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_Unlocked") == 1)
                    {
                        isLocked = false;
                    }   
                    
                }     
            }    

            if(levelToLoad == levelToCheck)
            {
                isLocked = false;
            }    
        }    
    }
}
