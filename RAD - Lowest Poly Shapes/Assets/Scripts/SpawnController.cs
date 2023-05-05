using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    float frequency = 0.5f;
    public GameObject[] platforms;
    public Transform platformSpawnPoint;
    float counter = 0.0f;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if(counter <= 0.0f)
        {
            GeneratePlatforms();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }
        GameObject currentChild;
        for(int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollPlatform(currentChild);
            if(currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
    }

    void ScrollPlatform(GameObject currentPlatform)
    {
        currentPlatform.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GeneratePlatforms()
    {
        GameObject newPlatform = Instantiate(platforms[Random.Range(0, platforms.Length)], platformSpawnPoint.position, Quaternion.identity) as GameObject;
        newPlatform.transform.parent = transform;
        counter = 3.0f;
    }

    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
    }
}
