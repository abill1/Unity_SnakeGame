
/*****************************************************************************************
* NewHiScore_UI
*  Script to behavior of the UI element used to take the player name to update the 
*  leader board record when a new high score is achieved. 
*  
*****************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewHiScore_UI : MonoBehaviour
{
    //********************************************************************************
    // Singleton
    //********************************************************************************

    private static NewHiScore_UI Instance;

    //********************************************************************************
    // Private Member Variables
    //********************************************************************************

    private TMP_InputField inputField;
    private Button submitBtn;

    //********************************************************************************
    // Unity Methods
    //********************************************************************************

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        inputField = transform.Find("PlayerNameInput").GetComponent<TMP_InputField>();
        inputField.ActivateInputField();
        submitBtn = transform.Find("SubmitPlayerNameButton").GetComponent<Button>();
        submitBtn.interactable = true;
        submitBtn.onClick.AddListener(SubmissionEvent);

    }

    //********************************************************************************
    // Utility Methods
    //********************************************************************************

    public static void Show()
    {
        GetInstance().gameObject.SetActive(true);
    }

    public static void Hide()
    {
        GetInstance().gameObject.SetActive(false);
    }

    //********************************************************************************
    // Private Methods
    //********************************************************************************

    private void SubmissionEvent()
    {
        Debug.Log("Player name input: " + inputField.text);
        LeaderBoard_SO.AddNewHiScore(inputField.text);
        LeaderBoard_SO.SortLeaderBoard();
        LeaderBoard_SO.Save();
        Hide();
        GameObject.Find("NewHiScoreState").GetComponent<NewHiScoreState>().NextScene();
    }

    //********************************************************************************
    // Singleton Getter
    //********************************************************************************

    private static NewHiScore_UI GetInstance()
    {
        return Instance;
    }

}
