using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : Observer
{
    public Image achievementBanner;
    public Text achievementText;

    //Event
    TileEvent cookiesEvent, cakeEvent, candyEvent;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        //Buat event
        cookiesEvent = new CookiesTileEvent(3);
        cakeEvent = new CakeTileEvent(10);
        candyEvent = new CandyTileEvent(5);

        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(string value)
    {
        string key;

        //Seleksi event yang terjadi, dan panggil class event nya
        if (value.Equals("Cookies event"))
        {
            cookiesEvent.OnMatch();
            if(cookiesEvent.AchievementCompleted())
            {
                key = "Match first cookies";
                void ActiveAchievementBanner(bool active)
                {
                    achievementBanner.gameObject.SetActive(active);
                }

                IEnumerator ShowAchievementBanner()
                {
                    ActiveAchievementBanner(true);
                    yield return new WaitForSeconds(2f);
                    ActiveAchievementBanner(false);
                }
            }
        }
        //throw new NotImplementedException();
    }
}
public class CakeTileEvent : TileEvent
{
    private int matchCount;
    private int requiredAmount;

    public CakeTileEvent(int amount)
    {
        requiredAmount = amount;
    }

    public override void OnMatch()
    {
        matchCount++;
    }

    public override bool AchievementCompleted()
    {
        if (matchCount == requiredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class CookiesTileEvent : TileEvent
{
    private int matchCount;
    private int requiredAmount;

    public CookiesTileEvent(int amount)
    {
        requiredAmount = amount;
    }

    public override void OnMatch()
    {
        matchCount++;
    }

    public override bool AchievementCompleted()
    {
        if (matchCount == requiredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class CandyTileEvent : TileEvent
{
    private int matchCount;
    private int requiredAmount;

    public CandyTileEvent(int amount)
    {
        requiredAmount = amount;
    }

    public override void OnMatch()
    {
        matchCount++;
    }

    public override bool AchievementCompleted()
    {
        if (matchCount == requiredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

