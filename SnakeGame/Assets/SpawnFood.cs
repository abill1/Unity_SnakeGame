using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public float startTime = 3.0f;
    public float spawnInterval = 4.0f;

    // Border positions
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Awake()
    {
        // Not great since these are hard coded names. What if someone changes the name???
        borderTop = GameObject.Find("borderTop").transform;
        borderBottom = GameObject.Find("borderBottom").transform;
        borderLeft = GameObject.Find("borderLeft").transform;
        borderRight = GameObject.Find("borderRight").transform;
        foodPrefab = GameObject.Find("food_Prefab");
        Debug.Log("Spawn Food Awake called.\n");
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnInterval);

    }

    void Spawn()
    {
        float x = Random.Range(borderLeft.position.x, borderRight.position.x);
        float y = Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);

    }

}
