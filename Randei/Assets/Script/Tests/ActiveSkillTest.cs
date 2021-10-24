using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


/*Author: Tai Zhang
 * The Active Skill only can be used if the Skill Num > 0
 * The Skill Num cannot be greater than the maximum number of skill
 * The Skill Num also cannot be less than zero
 * The Skill will increase when accessing the AddSkillNum(), but Skill Num won't be greater than the Max.
 * The Skill will decrease when accessing the SkillConsumption(), but Skill Num won't be less than zero.
 */

namespace Editor
{

    public class ActiveSkillTest
    {
        [Test]
        public void Active_Skill_Num_Default_Zero()
        {
            
            var SkillNum = new SkillNum(0);
            Assert.AreEqual(0, SkillNum.CurrentSkillNum);
        }

        [Test]
        public void Throws_Exception_When_Current_Active_Skill_Num_Less_Than_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> new SkillNum(-1));
        }
    
        [Test]
        public void Throws_Excption_When_Usable_Skill_Num_Is_Greater_Than_Maximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SkillNum(2,1));
        }
    }
    public class SkillNumIncrement
    {
        [Test]
        public void Zero_Does_Nothing()
        {
            var skillNum = new SkillNum(0);
            skillNum.AddSkillNum(0);
            Assert.AreEqual(0, skillNum.CurrentSkillNum);
        }

        [Test]
        public void Incremets_Current_Skill_Num()
        {
            var skillNum = new SkillNum(0);
            skillNum.AddSkillNum(1);
            Assert.AreEqual(1, skillNum.CurrentSkillNum);
        }

        [Test]
        public void OverAdding_Is_Ignored()
        {
            var skillNum = new SkillNum(19, 20);
            skillNum.AddSkillNum(2);
            Assert.AreEqual(20, skillNum.CurrentSkillNum);
        }

        [Test]
        public void One_Skill_Num_Decrease()
        {
            var skillNum = new SkillNum(1);
            skillNum.SkillConsumption(1);

            Assert.AreEqual(0, skillNum.CurrentSkillNum);
        }

        [Test]
        public void Over_Skill_Consumption_Is_Ignored()
        {
            var skillNum = new SkillNum(1);
            skillNum.SkillConsumption(2);

            Assert.AreEqual(0, skillNum.CurrentSkillNum);
        }

    }
    public class SkillNum
    {
        public int CurrentSkillNum { get; private set; }
        public int MaximumSkillNum { get; private set; }
        public SkillNum(int currentSkillNum, int maximumSkillNum = 20)
        {
            if (currentSkillNum < 0) throw new ArgumentOutOfRangeException("The Skill Num Must Greater Than -1");
            if (currentSkillNum > maximumSkillNum) throw new ArgumentOutOfRangeException("Current Skill Number Cannot Greater Than 20 times");
            CurrentSkillNum = currentSkillNum;
            MaximumSkillNum = maximumSkillNum;
        }

        public void AddSkillNum(int amount)
        {
            CurrentSkillNum = Mathf.Min(CurrentSkillNum + amount, MaximumSkillNum);        
        }

        public void SkillConsumption(int amount)
        {
            CurrentSkillNum = Mathf.Max(CurrentSkillNum - amount, 0);
        }
    }
}