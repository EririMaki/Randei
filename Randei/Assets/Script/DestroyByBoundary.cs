using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    //��������ײ���뿪Boundary�Ĵ�����ʱ�����ٸ���ײ����Ӧ����Ϸ����
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
