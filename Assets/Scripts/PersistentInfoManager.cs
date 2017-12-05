using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentInfoManager : MonoBehaviour
{
    private Statistics stats;
    private float CurrentRun_Time;

    public int DeflectedProjectilesCount_Current;
    public int EnemyKillCount_Current;


    // Use this for initialization
    void Start()
    {
        stats = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Statistics>();
        CurrentRun_Time = 0;
        DeflectedProjectilesCount_Current = 0;
        EnemyKillCount_Current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        stats.TotalTimeInSeconds += Time.deltaTime;
        CurrentRun_Time += Time.deltaTime;
    }

    public void UpdatePersistentStatistics()
    {
        if (stats.LongestRunInSeconds < CurrentRun_Time)
            stats.LongestRunInSeconds = CurrentRun_Time;
        stats.EnemyKills += EnemyKillCount_Current;
        stats.ProjectilesDeflected += DeflectedProjectilesCount_Current;
        stats.PlayerDeaths++;
        stats.Currency += (int)((EnemyKillCount_Current + (DeflectedProjectilesCount_Current / 5)) * (CurrentRun_Time / 30));
    }
}
