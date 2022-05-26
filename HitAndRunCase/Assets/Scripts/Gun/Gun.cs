using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun : MonoBehaviour
{

    public static Gun Instance;

   public delegate void Ammo(RaycastHit hitInfo);
    public Ammo ammoFire;

    public float AmmoReachDuration = 0.4f;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        ammoFire =FireBullet;
        
    }

    

    public void ChangeAmmoType()
    {
        if(ammoFire==FireBomb)
        {
            ammoFire = FireBullet;
        }
        else
        {
            ammoFire = FireBomb;
        }

    }



    // FireBomb ve FireBullet biribirini tekrar ediyor gibi bu hos degil farkindayým ama ilk gunden yollamis olmak icin buraya girismiyorum
    private void FireBomb(RaycastHit hitInfo)
    {

        GameObject destinationCube = hitInfo.transform.gameObject;
        
        GameObject bullet = PoolManager.Instance.RequestBomb();
       
        bullet.transform.position = transform.position;

        Vector3 directionBullet = destinationCube.transform.position - transform.position;

        Vector3 reflectionBullet = Vector3.Reflect(directionBullet, hitInfo.normal);
        bullet.transform.DOMove(destinationCube.transform.position, AmmoReachDuration).OnComplete(() => AmmoAfterArrive(bullet, destinationCube, reflectionBullet, directionBullet,hitInfo));

    }

    private void FireBullet(RaycastHit hitInfo)
    {

        GameObject destinationCube = hitInfo.transform.gameObject;
        
        GameObject bullet = PoolManager.Instance.RequestBullet();
      
        bullet.transform.position = transform.position;

        Vector3 directionBullet = destinationCube.transform.position - transform.position;

        Vector3 reflectionBullet = Vector3.Reflect(directionBullet, hitInfo.normal);
        bullet.transform.DOMove(destinationCube.transform.position, AmmoReachDuration).OnComplete(() => AmmoAfterArrive(bullet, destinationCube, reflectionBullet, directionBullet,hitInfo));

    }
    

    private void  AmmoAfterArrive(GameObject bull,GameObject cube, Vector3 reflectionBullet,Vector3 directionBullet,RaycastHit hitInfo)
    {

        bull.GetComponent<Collider>().enabled = true;

        bull.transform.DOMove(bull.transform.position + reflectionBullet, AmmoReachDuration).OnComplete(()=>bull.SetActive(false));


       


        
        
    
        Wall.Instance.ChangeCubesColors();
        
        


    }
   
  
    

}
