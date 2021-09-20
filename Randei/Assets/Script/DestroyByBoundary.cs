using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    //当其他碰撞器离开Boundary的触发器时，销毁该碰撞器对应的游戏对象。
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
