using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
/*use space key to use missile
 */
public class SkillController : MonoBehaviour
{

    //used for skill control
    public int currentSkillNum = 10;//initial and current skills number
    public int maximumSkillNum = 20;//the maximum skill buff that player/players can have
    public Text skillDisplay;//display skills number
    public bool hasSkill = false;//false means skill number is <= 0

    public int skillBulletNum;//active skill bullet number
    public float skillBulletAngle;//angle between each acrive skill bullet
    public int skillPoints = 1;//the points needed for active a skill
    //private GameController game;
    /*public int currentSkillNum;//initial and current skills number
    public int maximumSkillNum = 20;//the maximum skill buff that player/players can have
    public Text skillDisplay;//display skills number
    public bool hasSkill = true;//false means skill number is <= 0*/

    public GameObject skillBullet;
    public Transform skillBulletSpawn;

    public float skillMoveSpeed;//the move speed of the skill
    private Rigidbody rb;

    public int CurrentSkillNum { get; private set; }//initial Skill Num is 0
    public int MaximumSkillNum { get; private set; }
    public SkillController(int currentSkillNum, int maximumSkillNum)
    {
        if (currentSkillNum < 0) throw new ArgumentOutOfRangeException("The Skill Num Must Greater Than -1");
        if (currentSkillNum > maximumSkillNum) throw new ArgumentOutOfRangeException("Current Skill Number Cannot Greater Than 20 times");
        CurrentSkillNum = currentSkillNum;
        MaximumSkillNum = maximumSkillNum;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * skillMoveSpeed;

        /*SkillController go = GameObject.FindGameObjectWithTag("GameController");
        game = go.GetComponent<SkillController>();*/
    }

    /*Skill number cannot be greater than the maximum and less than 0
     *Skill will increase by 1 when player eats a Skill buff
     *User uses skill once, skill number decreases by 1
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&hasSkill) // && skillConsumption.hasSkill press space to active the skill when it has
        {
            SkillConsumption(skillPoints);
            if(hasSkill)ActiveSkill_MultiBullets();
        }
    }
    public void ActiveSkill_MultiBullets()//Active Skill
    {
        //fan shaped barrage
        for (int i = -skillBulletNum / 2; i < skillBulletNum / 2 + 1; i++)
        {
            GameObject tempBullet = Instantiate(skillBullet, skillBulletSpawn.position, skillBulletSpawn.rotation);
            //A fan shaped attack, distributing the bullets evenly in the fan range
            skillBulletSpawn.rotation = Quaternion.Euler(0f, i * skillBulletAngle, 0f);
        }                 
    }
    /*Skill number cannot be greater than the maximum and less than 0
   *Skill will increase by 1 when player eats a Skill buff
   *User uses skill once, skill number decreases by 1
   */
    public void AddSkillNum(int amount)//this is used for adding a certain amount of skill number when player eats a skill buff
    {
        currentSkillNum = Mathf.Min(currentSkillNum + amount, maximumSkillNum);
        if (currentSkillNum > 0)
        {
            hasSkill = true;
        }
        else
        {
            hasSkill = false;
        }
        DisplaySkillNum();
    }
    public void SkillConsumption(int amount)//use one skill, decrease total skill number
    {
      /*  if (currentSkillNum <= 0)
        {
            hasSkill = false;
            Debug.Log("No Skill is Available");
        }
        else
        {
            currentSkillNum = Mathf.Max(currentSkillNum - amount, 0);
        }*/

        switch (currentSkillNum)
        {
            case 0:
                hasSkill = false;
                Debug.Log("No Skill is Available");
                break;
            default:
                currentSkillNum = Mathf.Max(currentSkillNum - amount, 0);
                hasSkill = true;
                break;
        }

        DisplaySkillNum();
    }

    public void DisplaySkillNum()
    {
        Debug.Log("Skills: " + currentSkillNum);
        skillDisplay.text = "Skills: " + currentSkillNum.ToString();
    }
}