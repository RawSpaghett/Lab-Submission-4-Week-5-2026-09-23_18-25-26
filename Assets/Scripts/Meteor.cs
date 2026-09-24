using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MeteorBase
{
    protected override int health => 5;
    protected override int speed => 3
    ;
    protected virtual void awake()
    {
        base.awake();
    }
    protected override void Update()
    {
        base.Update();
    }
    
}
