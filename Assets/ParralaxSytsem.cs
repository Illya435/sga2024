using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxSytsem : MonoBehaviour

{
    [SerializeField] Transform[] levels1 = new Transform[3];
    //[SerializeField] Transform level2;
    //[SerializeField] Transform level3;
    [SerializeField] float deletePosLevel1 = -18f;
    [SerializeField] public float speedLevel1 = 3;
    [SerializeField] GameObject SpawnPosition;

    // pour level2
    [SerializeField] Transform[] levels2 = new Transform[3];
    [SerializeField] float deletePosLevel2 = -23;
    [SerializeField] float speedLevel2 = 2;
    [SerializeField] GameObject SpawnPosition2;

    // pour level3
    [SerializeField] Transform[] levels3 = new Transform[3];
    [SerializeField] float deletePosLevel3 = -19;
    [SerializeField] float speedLevel3 = 1;
    [SerializeField] GameObject SpawnPosition3;


    //[SerializeField] GameObject level1Prefab;
    //[SerializeField] GameObject level2Prefab;
    //[SerializeField] GameObject level3Prefab;

    Camera cam;
    float offsetX = 0;

    float level1_X;
    float level2_X;
    float level3_X;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        offsetX = cam.transform.position.x;
        //level1_X = level1.position.x;
        //level2_X = level2.position.x;
        //level3_X = level3.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        //float AxeX = cam.transform.position.x - offsetX;
        //level1.position = new Vector3(AxeX / 2 + level1_X, level1.position.y, level1.position.z);
        //level2.position = new Vector3(AxeX / 3 + level2_X, level2.position.y, level2.position.z);
        //level3.position = new Vector3(AxeX / 4 + level3_X, level3.position.y, level3.position.z);
        //Debug.Log(AxeX);

        for (int i = 0; i < levels1.Length; i++)
        {
            Transform temp = levels1[i];

            temp.position += Vector3.left * Time.deltaTime * speedLevel1;
            if (temp.position.x < deletePosLevel1)
            {
                temp.position = SpawnPosition.transform.position;
            }
            levels1[i] = temp;
        }
       
        for (int u = 0; u < levels2.Length; u++)
        {
            Transform temp = levels2[u];

            temp.position += Vector3.left * Time.deltaTime * speedLevel2;
            if(temp.position.x < deletePosLevel2)
            {
                temp.position = SpawnPosition2.transform.position;
            }
            levels2[u] = temp;
        }
        
        for (int v = 0; v < levels3.Length; v++)
        {
            Transform temp = levels3[v];

            temp.position += Vector3.left * Time.deltaTime * speedLevel3;
            if (temp.position.x < deletePosLevel3)
            {
                temp.position = SpawnPosition3.transform.position;
            }
            levels3[v] = temp;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(deletePosLevel1, 0, 0), 1);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(deletePosLevel2, 0, 0), 1);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(deletePosLevel2, 0, 0), 1);
    }
}
