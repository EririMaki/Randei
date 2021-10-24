using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpaw1;
    public Transform shotSpaw2;
    public Transform shotSpaw3;
    //发射子弹间隙
    public float shotSpace;
    //发射子弹等待时间间隔
    public float shotWait;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyShipFire", shotWait, shotSpace);
    }

    void EnemyShipFire()
    {
        Instantiate(shot, shotSpaw1.position, shotSpaw1.rotation);
        Instantiate(shot, shotSpaw2.position, shotSpaw2.rotation);
        Instantiate(shot, shotSpaw3.position, shotSpaw3.rotation);
    }
}
