using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Wall : MonoBehaviour
{

    public static Wall Instance;
    public GameObject _raw;
    public GameObject _cube;

    public int _rowCount;
    public int _columnCount;
    

    private float width_cube;
    private float height_cube;

    public List<RandomColor> cubesRandomColorScripts;

    public int cubeCount;

  private  float firstColumnStartPosX ;
    private float firstRowStartPosY;
    private Camera camMain;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        cubeCount = _rowCount * _columnCount;

        MeshRenderer temp_cubeCollider = _cube.GetComponent<MeshRenderer>();
        width_cube = temp_cubeCollider.bounds.size.x;
        height_cube = temp_cubeCollider.bounds.size.y;
        firstColumnStartPosX = transform.position.x-_columnCount * width_cube * 0.5f + width_cube * 0.5f;
        firstRowStartPosY = transform.position.y + _rowCount * height_cube * 0.5f - height_cube * 0.5f;

        camMain = Camera.main;

}
    // Start is called before the first frame update
    void Start()
    {

        

      
        
    }
    private void OnEnable()
    {
        
        CreateWall();
        
    }
    
    private void CreateWall()
    {



        Vector3 rawPosTemporary =  _raw.transform.position;
        rawPosTemporary.y = firstRowStartPosY;
        _raw.transform.position = rawPosTemporary;

        for (int i=0; i<_columnCount;i++)
         {
           
          
          GameObject TemporaryCube = Instantiate(_cube, new Vector3( (firstColumnStartPosX + i * width_cube),_raw.transform.position.y,_raw.transform.position.z), Quaternion.identity, _raw.transform);
            cubesRandomColorScripts.Add(TemporaryCube.GetComponent<RandomColor>());
        }
        
        
        for(int k = 1; k < _rowCount; k++)
        {
         GameObject InstanceRaw=   Instantiate(_raw, _raw.transform.position - k * height_cube*Vector3.up, Quaternion.identity, transform);

            RandomColor[] listRandomColorTemporary = InstanceRaw.GetComponentsInChildren<RandomColor>();
            for (int j = 0; j < listRandomColorTemporary.Length; j++)
            { 
                cubesRandomColorScripts.Add(listRandomColorTemporary[j]);
            }
                

            
        }
        StartCoroutine( SetProperFieldOfView());


    }
    
    private IEnumerator SetProperFieldOfView()
    {

        Vector3 pointOfCorner = new Vector3(firstColumnStartPosX, firstRowStartPosY, transform.position.z);

        Vector3 pointOfCornerAsViewport = camMain.WorldToViewportPoint(pointOfCorner);

        
        while(!(pointOfCornerAsViewport.x>0.8f || pointOfCornerAsViewport.x<0.2f || pointOfCornerAsViewport.y>0.8f || pointOfCornerAsViewport.y<0.2f) )
        {
            pointOfCornerAsViewport = camMain.WorldToViewportPoint(pointOfCorner);

            camMain.fieldOfView -= Time.fixedDeltaTime*120;
            yield return null;

        }
        
        
      
    }

    public void ChangeCubesColors()
    {
        for(int i=0;i<cubesRandomColorScripts.Count;i++)
        {
            if(cubesRandomColorScripts[i]!=null &&cubesRandomColorScripts[i].transform.parent!=null)
            {
                cubesRandomColorScripts[i].ChangeColor();
                
                

            }
        }
    }


   
}
