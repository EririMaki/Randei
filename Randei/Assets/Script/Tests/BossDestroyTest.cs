using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class BossDestroyTest : MonoBehaviour
{
    [Test]
    public void BossLife()
    {

        var bossLife = new BossLife(20);
        Assert.AreEqual(20, bossLife.lifeNum);
    }

    [Test]
    public void BossLifeDecrease()
    {

        var bossLifeDecrease = new BossLifeDecrease(1);
        Assert.AreEqual(19, bossLifeDecrease.lifeRemain);
    }

    [Test]
    public void BossLifeCannotLessThanZero()
    {

        var bossLifeCannotLessThanZero = new BossLifeCannotLessThanZero(200);
        Assert.AreEqual(0, bossLifeCannotLessThanZero.validLife);
    }

}

public class BossLife
{
    public int lifeNum;
    public BossLife(int lifeNumber)
    {
        lifeNum = lifeNumber;
    }
}

public class BossLifeDecrease
{
    public int lifeRemain;
    BossLife boss = new BossLife(20);
    public BossLifeDecrease(int damange)
    {
        lifeRemain = boss.lifeNum - damange;
    }
}

public class BossLifeCannotLessThanZero
{
    public int validLife = 20;
    public BossLifeCannotLessThanZero(int damange)
    {
        if ((validLife-damange)>= 0)
        {
            validLife = validLife - damange;
        }
        else
        {
            validLife = 0;
        }
    }
}