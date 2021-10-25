using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ReadScore : MonoBehaviour
{
    public Text money;
    public Text errorMessage;
    private int baseGold = 0;
    private void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open);
        GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);
        fileStream.Close();
        int baseGold = 0;
        baseGold =  save.gold;
        money.text = "Remaining Gold: " + baseGold.ToString();
    }

    //Function for buying health
    public void AddHealth()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
        GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);
        //i = save.health;
        fileStream.Flush();
        fileStream.Close();
        if(save.gold > 500)
        {
            save.health += 1;
            save.gold -= 500;
            bf = new BinaryFormatter();
            FileStream newfileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt");
            bf.Serialize(newfileStream, save);
            fileStream.Close();
            baseGold = save.gold;
            money.text = "Remaining Gold: " + baseGold.ToString();
            Debug.Log(save.health);
        }
        else
        {
            errorMessage.gameObject.SetActive(true);
        }
        
    }
    //Function for buying Skills
    public void AddSkill()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);
        fileStream.Flush();
        fileStream.Close();
        if (save.gold > 500)
        {
            save.skill += 1;
            save.gold -= 500;
            bf = new BinaryFormatter();
            FileStream newfileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt");
            bf.Serialize(newfileStream, save);
            fileStream.Close();
            baseGold = save.gold;
            money.text = "Remaining Gold: " + baseGold.ToString();
            Debug.Log(save.health);
        }
        else
        {
            errorMessage.gameObject.SetActive(true);
        }
    }
    //Function for buying attack speed
    public void AddSpeed()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);
        fileStream.Flush();
        fileStream.Close();
        if (save.gold > 800)
        {
            save.rate *= 0.9f;
            save.gold -= 800;
            bf = new BinaryFormatter();
            FileStream newfileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt");
            bf.Serialize(newfileStream, save);
            fileStream.Close();
            baseGold = save.gold;
            money.text = "Remaining Gold: " + baseGold.ToString();
        }
        else
        {
            errorMessage.gameObject.SetActive(true);
        }
    }
}
