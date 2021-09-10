using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpaw;
    //发射子弹间隙
    public float shotSpace;
    //发射子弹等待时间
    public float shotWait;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyShipFire", shotWait, shotSpace);
    }

    void EnemyShipFire()
    {
        Instantiate(shot, shotSpaw.position, shotSpaw.rotation);
    }

  
}
