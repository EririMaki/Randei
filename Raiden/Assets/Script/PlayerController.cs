using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public string player = "1";

    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public bool isbuffed = false;
    public bool isDuo = false;

    //test
    void Update()
    {
        if (isbuffed == false && isDuo == false)
        {
            if (Input.GetButton("Fire" + player) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                shotSpawn.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if (isbuffed == true)
        {
            if (Input.GetButton("Fire" + player) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                shotSpawn.rotation = Quaternion.Euler(0f, 20f, 0f);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                shotSpawn.rotation = Quaternion.Euler(0f, -20f, 0f);
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
        if (isDuo == true)
        {
            if (Input.GetButton("Fire" + player) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                shotSpawn.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(shot, shotSpawn.position + new Vector3(-0.5f, 0f, 0f), shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position + new Vector3(0.5f, 0f, 0f), shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {  

        float moveHorizontal = Input.GetAxis("Horizontal" + player);
        float moveVertical = Input.GetAxis("Vertical" + player);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
    public void AddFireRate()
    {
        fireRate = fireRate * .8f;
    }
    public void isBuffed()
    {
        Debug.Log("Multiple!");
        isbuffed = true;
    }
    public void isMultipleBuff()
    {
        Debug.Log("Multiple!");
        isDuo = true;
        isbuffed = false;
    }
}
