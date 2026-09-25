using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MeteorBase
{
    protected override int health => 5;
    protected override int speed => 2;
    protected virtual void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }
}
