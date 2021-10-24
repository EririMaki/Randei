using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public GameObject shield;
    private float timer = 3f;
    public float tumble = 5f;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightShift)) || ((Input.GetKeyDown(KeyCode.Space))))
        {
            Debug.Log("Function called");
            shield.SetActive(true);
            timer = 3f;
        }
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            shield.SetActive(false);
        }
    }
}
