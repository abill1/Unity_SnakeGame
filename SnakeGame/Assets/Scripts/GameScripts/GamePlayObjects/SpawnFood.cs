
/*****************************************************************************************
* SpawnFood
*  The script to manage the frequency of food prefab in the scene and instantiates the 
*  the object when Spawn() is called. 
*  
*****************************************************************************************/

using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float startTime = 3.0f;
    [SerializeField] private float spawnInterval = 8.0f;

    //********************************************************************************
    // Member Variables 
    //********************************************************************************

    // ----- Holds the play area boundary
    private Transform borderTop;
    private Transform borderBottom;
    private Transform borderLeft;
    private Transform borderRight;

    //********************************************************************************
    // Unity Methods 
    //********************************************************************************

    void Awake()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name.ToString());
        int snakeNum = GameObject.Find("SnakeHead").GetInstanceID();
        int colNum = collision.gameObject.GetInstanceID();

        if (snakeNum == colNum)
            Debug.Log("Confirmed collision with snake.");    

    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    void Spawn()
    {
        float offset = 1.0f;
        float x = Random.Range(borderLeft.position.x + offset, borderRight.position.x - offset);
        float y = Random.Range(borderBottom.position.y + offset, borderTop.position.y - offset);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);

    }

    

}
