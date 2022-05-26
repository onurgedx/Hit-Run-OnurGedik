using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScript : MonoBehaviour
{

    public static CanvasScript Instance;

    public Text text;


    private void Awake()
    {
        if(Instance==null)
        {Instance = this;}
    }

    public void LevelCompleted()
    {
        StartCoroutine(LevelCompletedIEnumerator());
    }
    private IEnumerator LevelCompletedIEnumerator()
    {
        Camera mainCam = Camera.main;
        while(mainCam.fieldOfView < 170) {
        mainCam.fieldOfView += Time.fixedDeltaTime * 120;
            yield return null;
        }

        text.text = "Level Completed!";
       
    }


    public void ChangeAmmoType()
    {
        Gun.Instance.ChangeAmmoType();

    }

    public void RestartButton()
    {
        GameManager.Instance.ActiveSceneRestart();
    }


}
