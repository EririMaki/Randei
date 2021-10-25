using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LeaderboardRead : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Ranking;

    public Text leadersDisplay;
    public void DisplayLeaderBoard()
    {
        leadersDisplay.text = "";
        if (File.Exists(Application.dataPath + "/Savedata" + "/byBin.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open);
            GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);//convert binary info to obj
            fileStream.Close();//reading completed
            int index = 1;
            foreach (int item in save.ranking)
            {
                //int index = System.Array.IndexOf(save.ranking, item);

                leadersDisplay.text += "The #" + index + " Score: " + item + "\n\n";
                index++;
                Debug.Log(item);
            }
        }
        else
        {
            leadersDisplay.text = "No Records";
            Debug.Log("No Scores");
        }
    }

    public void OpenRanking()
    {
        Startpanel.SetActive(false);
        Ranking.SetActive(true);
    }

    public void CloseRanking()
    {
        Startpanel.SetActive(true);
        Ranking.SetActive(false);
    }

}
