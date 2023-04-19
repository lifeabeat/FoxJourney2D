using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPoints : MonoBehaviour
{
    public MovingPoints up, right, left, down;
    public bool isLevel,isLocked;
    public string levelToLoad, levelToCheck, levelName;

    public int gemsCollected, totalGems;
    public float bestsTime, targetTime;

    public GameObject timeBadge, gemBadge1, gemBadge2, gemBadge3;
    

     void Start()
    {
        if (isLevel && levelToLoad != null)
        {
            if (PlayerPrefs.HasKey(levelToLoad + "_Gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_Gems");
            }
            if (PlayerPrefs.HasKey(levelToLoad + "_Time"))
            {
                bestsTime = PlayerPrefs.GetFloat(levelToLoad + "_Time");
            }

            if (bestsTime <= targetTime && bestsTime != 0 )
            {
                timeBadge.SetActive(true);
            }

            UpdateGemCompleteMap();

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

    public void UpdateGemCompleteMap()
    {
        if (gemsCollected >= totalGems)
        {
            gemBadge1.SetActive(true);
            gemBadge2.SetActive(true);
            gemBadge3.SetActive(true);
        }
        else if (gemsCollected > (totalGems * 2 / 3))
        {
            gemBadge1.SetActive(true);
            gemBadge2.SetActive(true);
        }
        else if(gemsCollected > (totalGems * 1 / 3))
        {
            gemBadge1.SetActive(true);
        }



    }    
}
