using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bomb : Ammo
{

    public ParticleSystem particleSystem;

    protected override void ExplodeOnce()
    {
        base.ExplodeOnce();
        if (explodeChance)
        {
            explodeChance = false;

            particleSystem.Play();
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        ExplodeOnce();
    }


    private void OnDisable()
    {
        explodeChance = true;
    }

}
