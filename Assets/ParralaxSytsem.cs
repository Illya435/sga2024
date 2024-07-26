using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxSytsem : MonoBehaviour

{
    GameObject[] ChunkObstacle;
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

    [SerializeField] List<GameObject> prefabChunksObstacle;
    //[SerializeField] GameObject level1Prefab;
    //[SerializeField] GameObject level2Prefab;
    //[SerializeField] GameObject level3Prefab;
    private float timer = 0;
    private const float timetospeedup = 10;
    private float boostspeed = 1.0f;

    Camera cam;
    float offsetX = 0;

    //float[] level1_Y = new float[3];
    //float[] level2_Y = new float[3];
    //float[] level3_Y = new float[3];


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        offsetX = cam.transform.position.x;

        ChunkObstacle = new GameObject[11];
        for (int i = 0; i <11; i++)
        {
            ChunkObstacle[i] = GameObject.Instantiate(prefabChunksObstacle[0]);
            ChunkObstacle[i].transform.position =  ( new Vector3(4.8525f * i , -1.75f,0) );

        }

        //level1_Y = level1.position.y;
        //level2_Y = level2.position.y;
        //level3_Y = level3.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timetospeedup)
        {
            boostspeed += 0.2f;
            timer = 0;
        }
        //float AxeX = cam.transform.position.x - offsetX;
        //level1.position = new Vector3(AxeX / 2 + level1_X, level1.position.y, level1.position.z);
        //level2.position = new Vector3(AxeX / 3 + level2_X, level2.position.y, level2.position.z);
        //level3.position = new Vector3(AxeX / 4 + lev
        //el3_X, level3.position.y, level3.position.z);
        //Debug.Log(AxeX);
        GameObject toRemove1 = null;

        for (int i = 0; i < 11; i++)
        {
            GameObject chunk = ChunkObstacle[i];
            chunk.transform.position += Vector3.left * Time.deltaTime * speedLevel1 * boostspeed;
            if (chunk.transform.position.x < deletePosLevel1)
            {
                toRemove1 = chunk;
                ChunkObstacle[i] = GenerateChunk();
                ChunkObstacle[i].transform.position = SpawnPosition.transform.position  + new Vector3(0, -4.9f, 0);
            }
            if (toRemove1 != null)
                Destroy(toRemove1);

        }

        for (int i = 0; i < levels1.Length; i++)
        {
            Transform temp = levels1[i];


            //float y = 
            temp.position += Vector3.left * Time.deltaTime * speedLevel1 * boostspeed;
            if (temp.position.x < deletePosLevel1)
            {

                temp.position = SpawnPosition.transform.position;
            }
            levels1[i] = temp;

        }
        
        
  

        for (int u = 0; u < levels2.Length; u++)
        {
            Transform temp = levels2[u];

            temp.position += Vector3.left * Time.deltaTime * speedLevel2 * boostspeed;
            if(temp.position.x < deletePosLevel2)
            {
                temp.position = SpawnPosition2.transform.position;
            }
            levels2[u] = temp;
        }
        
        for (int v = 0; v < levels3.Length; v++)
        {
            Transform temp = levels3[v];

            temp.position += Vector3.left * Time.deltaTime * speedLevel3 * boostspeed;
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

    GameObject GenerateChunk()
    {
        int rdm = Random.Range(0, prefabChunksObstacle.Count);
        return GameObject.Instantiate(prefabChunksObstacle[rdm]);
    }
}
