using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Repeat(scrollSpeed * Time.time, 30);
        transform.position = startPos + distance * Vector3.forward * (-1);

    }
}
