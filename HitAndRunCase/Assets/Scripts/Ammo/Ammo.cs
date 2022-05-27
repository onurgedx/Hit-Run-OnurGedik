using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float ExplodePower = 100;
    public  Collider collider;

    private Vector3 firstScale;

    public bool explodeChance;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        firstScale = transform.localScale;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        

        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        // rb.AddForce((transform.position-Camera.main.transform.position) * ExplodePower*Random.Range(0.8f,1.4f));
        rb.AddExplosionForce(ExplodePower, collider.bounds.center - collider.bounds.extents.z * Vector3.forward, 5.5f);
        rb.gameObject.layer = 0;

        Wall.Instance.cubeCount--;
        if (Wall.Instance.cubeCount == 0)
        {
            GameManager.Instance.LevelCompletedGM();
        }

        rb.gameObject.GetComponent<Vanishing>().enabled = true;

        rb.gameObject.GetComponent<Collider>().enabled = false;
        
       
        

    }

    protected virtual void ExplodeOnce()
    {
       
    }

    



    private void OnDisable()
    {
        transform.localScale = firstScale;
    }
}
