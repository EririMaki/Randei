
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAircraft : MonoBehaviour
{

    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int Num;

    
    void Start()
    {
        Num = characterPrefabs.Length;
        characterGameObjects = new GameObject[Num];
        for (int i = 0; i < Num; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
    }



    void UpdateCharacterShow()
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < Num; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void SwapButtonClick()
    {
        selectedIndex++;
        selectedIndex %= Num;
        UpdateCharacterShow();
    }

}