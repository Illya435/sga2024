using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    [SerializeField] private ParralaxSytsem paralaxSystem;

    [SerializeField] float deletePos = -18f;
    [SerializeField] GameObject housePrefab;
    GameObject[] houses = new GameObject[5];

    [SerializeField] Sprite[] houseSprites = new Sprite[5];

    float instanceTime = 0;

    [Range(0.01f, 2f)]
    [SerializeField] float minInstanceTime = 0.01f;
    [Range(1f, 10f)]
    [SerializeField] float maxInstanceTime = 1f;

    private void Start()
    {
        instanceTime = Random.Range(0.01f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        instanceTime -= Time.deltaTime;

        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i] == null && instanceTime < 0)
            {
                GameObject tempHouse = Instantiate(housePrefab, transform.position, Quaternion.identity);
                int index = Random.Range(0, houseSprites.Length);
                tempHouse.GetComponent<SpriteRenderer>().sprite = houseSprites[index];
                houses[i] = tempHouse;
                instanceTime = Random.Range(minInstanceTime, maxInstanceTime);
            }
        }

        float speed = paralaxSystem.speedLevel1;

        for (int i = 0; i < houses.Length; i++)
        {
            if (houses[i] == null)
            {
                continue;
            }
            Vector3 pos = houses[i].transform.position;
            pos += new Vector3(-1, 0, 0) * Time.deltaTime * speed;

            if (pos.x < deletePos)
            {
                Destroy(houses[i]);
            }

            houses[i].transform.position = pos;
        }
    }
}
