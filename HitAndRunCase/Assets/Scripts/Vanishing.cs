using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class Vanishing : MonoBehaviour
{
   
    private void OnEnable()
    {
        Invoke("SelfDestroy", 8f);
       
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
