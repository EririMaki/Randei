using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Use right shift key to use wingman
 */
public class WingmanController : MonoBehaviour
{
    public int wingmanNum;//wingman number
    public float wingManAngle;//angle between each wingman
    public int skillPoints = 1;
    public GameObject wingman;
    public Transform wingmanSpawn;

    public float skillMoveSpeed;//the move speed of the skill
    private Rigidbody rb;

    //private GameObject go;
    private SkillController skillController;

    public int CurrentSkillNum { get; private set; }//initial Skill Num is 0
    public int MaximumSkillNum { get; private set; }
    public WingmanController(int currentSkillNum, int maximumSkillNum)
    {
        if (currentSkillNum < 0) throw new ArgumentOutOfRangeException("The Skill Num Must Greater Than -1");
        if (currentSkillNum > maximumSkillNum) throw new ArgumentOutOfRangeException("Current Skill Number Cannot Greater Than 20 times");
        CurrentSkillNum = currentSkillNum;
        MaximumSkillNum = maximumSkillNum;
    }

    // Active Skill number should be zero when player starts the game.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * skillMoveSpeed;

        skillController = GetComponent<SkillController>();
    }

    /*Skill number cannot be greater than the maximum and less than 0
     *Skill will increase by 1 when player eats a Skill buff
     *User uses skill once, skill number decreases by 1
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && skillController.hasSkill)//press space to active the skill
        {
            skillController.SkillConsumption(skillPoints);
            if(skillController.hasSkill)CallWingman();
        }
    }
    public void CallWingman()//Active Skill
    {
        //fan shaped 
        for (int i = -wingmanNum / 2; i < wingmanNum / 2 + 1; i++)
        {
            GameObject tempBullet = Instantiate(wingman, wingmanSpawn.position, wingmanSpawn.rotation);
            //A fan shaped attack, distributing the wingman evenly in the fan range
            wingmanSpawn.rotation = Quaternion.Euler(0f, i * wingManAngle, 0f);
        }
    }
}
