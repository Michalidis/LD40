using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public int PlayerDeaths;
    public int EnemyKills;
    public int ProjectilesDeflected;
    public float LongestRunInSeconds;
    public float TotalTimeInSeconds;
    public int Currency;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("IndestructibleInfo").GetComponentInChildren<Statistics>().RewriteStatistics_MainMenuONLY();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RewriteStatistics_MainMenuONLY()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Text t = GameObject.Find("Statistics_Text").GetComponent<Text>();
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Your have died {0}x\n", PlayerDeaths))
                .Append(string.Format("Your have destroyed {0} enemy ships\n", EnemyKills))
                .Append(string.Format("Your have deflected {0} projectiles\n", ProjectilesDeflected))
                .Append(string.Format("Your longest run lasted for {0}m {1}s\n", Mathf.RoundToInt(LongestRunInSeconds / 60), Mathf.RoundToInt(LongestRunInSeconds % 60)))
                .Append(string.Format("Your longest run lasted for {0}h {1}m {2}s\n", Mathf.RoundToInt(TotalTimeInSeconds / 60 / 60), Mathf.RoundToInt(TotalTimeInSeconds % 3600 / 60), Mathf.RoundToInt(TotalTimeInSeconds % 60)))
                .Append(string.Format("\nYou currently have {0} Metal Gears to spend\n", Currency))
                .Append(string.Format("Note: You can earn Metal Gears by deflecting projectiles and destroying enemy ships.")); ;

            t.text = sb.ToString();
        }
    }

    public void ResetStatistics_MainMenuONLY()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Statistics globalStats = GameObject.Find("IndestructibleInfo").GetComponentInChildren<Statistics>();
            globalStats.PlayerDeaths = 0;
            globalStats.TotalTimeInSeconds = 0;
            globalStats.ProjectilesDeflected = 0;
            globalStats.EnemyKills = 0;
            globalStats.LongestRunInSeconds = 0;
            globalStats.Currency = 0;

            globalStats.RewriteStatistics_MainMenuONLY();
        }
    }
}
