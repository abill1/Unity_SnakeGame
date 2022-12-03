using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveStart = 0.3f;
    public float moveInterval = 0.3f;

    Vector2 dir = Vector2.right;    // Default movement in right direction

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", moveStart, moveInterval);

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Investigate better input options other than conditional
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;


    }

    void Move()
    {
        // Updates the head into a new direction
        this.transform.Translate(dir);

    }

}
