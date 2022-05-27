using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance;
    public GameObject _bullet;
    public GameObject _bomb;
    public GameObject bulletPool;
    public GameObject bombPool;

    public List<GameObject> bulletList;
    public List<GameObject> bombList;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }

        
        for(int i=bulletPool.transform.childCount-1;i>=0;i--)
        {
            GameObject go = bulletPool.transform.GetChild(i).gameObject;
            bulletList.Add(go);
            go.SetActive(false);
            
        }

        for (int i  = bombPool.transform.childCount-1; i >=0 ; i--)
        {
            GameObject go = bombPool.transform.GetChild(i).gameObject;
            bombList.Add(go);
            go.SetActive(false);

        }
        

    }


    public GameObject RequestAmmo(List<GameObject> ammoList,GameObject ammoType)
    {
        foreach(GameObject ammo in ammoList)
        {
            if(ammo != null) { 
            if(ammo.activeInHierarchy==false)
            { ammo.SetActive(true);
                return ammo;           
            }
            }
        }




        GameObject newAmmo = Instantiate(ammoType, Gun.Instance.transform.position,Quaternion.identity,transform) ;
        ammoList.Add(newAmmo);
        return newAmmo;


    }

    public GameObject RequestBullet()
    {
        GameObject bulletWillBeSent = RequestAmmo(bulletList, _bullet);
        return bulletWillBeSent;
    }
    public GameObject RequestBomb()
    {
        GameObject bombWillBeSent = RequestAmmo(bombList, _bomb);
        return bombWillBeSent;
    }
}
