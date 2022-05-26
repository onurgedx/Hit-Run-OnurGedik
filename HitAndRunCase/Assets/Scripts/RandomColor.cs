using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RandomColor : MonoBehaviour
{
    public bool alive = true;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor();
    }
    public void ChangeColor()
    {
        meshRenderer.material.color = Random.ColorHSV(0f,1f, 0.0f,1f, 0.5f,1);
        
    }

}
