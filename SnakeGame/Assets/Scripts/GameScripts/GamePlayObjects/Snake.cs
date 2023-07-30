
/*****************************************************************************************
* Snake
*  The script for the player (the snake). This script contains the player input state
*  and manages the growth of the snake object. 
*  
*****************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Snake : MonoBehaviour
{
    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private float moveInterval = 0.25f;
    [SerializeField] private float lastMove = 0.0f;
    [SerializeField] private int score = 0;

    //********************************************************************************
    // Private Member Variables
    //********************************************************************************

    private int hiscore = 0;
    private GamePlayState stateObj;
    private List<GameObject> snakeBody;
    private int snakeSize = 0;
    private const int MAX_SIZE = 63;
    private PlayerMoveStateManager moveStateManager;

    //********************************************************************************
    // Unity Methods
    //********************************************************************************

    // Start is called before the first frame update
    void Start()
    {
        stateObj = GameObject.Find("GameLevelState").GetComponent<GamePlayState>();
        GameObject body = GameObject.Find("SnakeBody");
        snakeBody = new List<GameObject>();        

        for (int i = 0; i < MAX_SIZE; i++)
        {       
            GameObject tmp = Instantiate(body, new Vector2(-82, 0), Quaternion.identity);
            tmp.GetComponent<SpriteRenderer>().enabled = false;
            tmp.GetComponent<Collider2D>().enabled = false;
            snakeBody.Add(tmp);

        }

        LeaderBoard_SO.Load();
        hiscore = LeaderBoard_SO.GetHiScore();
        GameObject.Find("HiScore").GetComponent<TMPro.TextMeshProUGUI>().text = hiscore.ToString();
        moveStateManager = new PlayerMoveStateManager();

    }

    // Update is called once per frame
    void Update()
    {
        moveStateManager.CheckForStateUpdate();

        if (Time.time - lastMove > moveInterval)
        {
            Move();
            lastMove = Time.time;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name.ToString());
        if (collision.transform.gameObject.CompareTag("Border"))
        {
            if (LeaderBoard_SO.CheckForNewHiScore(score))
            {
                stateObj.StopSceneThemeMusic();
                SceneManager.LoadScene("NewHiScoreScene");
            }
            else
            {
                stateObj.NextScene();
            }

        }
        else if (collision.gameObject.name.StartsWith("food_Prefab"))
        {
            Food food = collision.gameObject.GetComponent<Food>();
            AddToScore(food.GetValue());
            Debug.Log("Score: " + score);
            GameObject.Find("PlayerScore").GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
            AudioManager.PlaySound("AteFood");

            // ----- For testing purpose, Destroy the object.
            // ----- TODO: Create a food manager that creates a 
            // pool of food objects to grab from when "spawning"
            // a new food in the scene. The manager should be 
            // used to limit the garbage collection. 

            Destroy(collision.gameObject);

            if (snakeSize < MAX_SIZE)
            {
                GameObject body = snakeBody.ElementAt(snakeSize);
                body.GetComponent<SpriteRenderer>().enabled = true;
                body.GetComponent<Collider2D>().enabled = true;
                snakeSize++;

            }

        }
        else if (collision.gameObject.CompareTag("SnakeBody"))
        {
            if (LeaderBoard_SO.CheckForNewHiScore(score))
            {
                stateObj.StopSceneThemeMusic();
                SceneManager.LoadScene("NewHiScoreScene");
            }
            else
            {
                stateObj.NextScene();
            }

        }

    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    void Move()
    {
        Vector2 last = transform.position;

        // Updates the head into a new direction
        moveStateManager.Move(this.transform);       

        if(snakeSize > 0)
        {
            GameObject body = snakeBody.ElementAt(snakeSize - 1);
            body.transform.position = last;
            snakeBody.RemoveAt(snakeSize - 1);
            snakeBody.Insert(0, body);

        }     

    }

    //********************************************************************************
    // Getters
    //********************************************************************************

    public int GetScore() { return score; }

    //********************************************************************************
    // Setters
    //********************************************************************************

    public void AddToScore(int _value)
    {
        score += _value;

    }

}

