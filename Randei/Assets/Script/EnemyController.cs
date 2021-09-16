using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpaw;
    //�����ӵ���϶
    public float shotSpace;
    //�����ӵ��ȴ�ʱ����
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
