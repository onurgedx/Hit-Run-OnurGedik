using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Camera MainCam;
    private void Awake()
    {
        if(MainCam==null)
        {
            MainCam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TouchProcess();
    }
    private void TouchProcess()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {


                Ray ray = MainCam.ScreenPointToRay(finger.position);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if(hitInfo.transform.gameObject.layer==6)
                    { Gun.Instance.ammoFire(hitInfo); }
                    
                    
                    

                }

            }

        }
    }








}
