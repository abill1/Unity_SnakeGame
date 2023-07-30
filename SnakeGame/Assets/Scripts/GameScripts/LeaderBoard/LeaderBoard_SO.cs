
/*****************************************************************************************
* LeaderBoard_SO
*  Stores the top ten high scores and handles the display of the scores during the end
*  game scene. 
*  This object is used to read and write the high scores to a file. 
*  
*****************************************************************************************/

using System;
using System.IO;
using UnityEngine;

public class LeaderBoard_SO : FileData_Proto
{
    //********************************************************************************
    // Singleton
    //********************************************************************************

    private static LeaderBoard_SO Instance;

    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private string fileName = "LeaderBoard.save";

    //********************************************************************************
    // Constant Fields
    //********************************************************************************

    private const int NUMBER_OF_ENTRIES = 10;

    //********************************************************************************
    // Private Member Variables
    //********************************************************************************

    private string tag_EndLBName = "EndLB_EntryName";
    private string tag_EndLBScore = "EndLB_EntryScore";
    private HiScoreEntry_SO[] leaderBoard;
    private GameObject[] EndLB_EntryNames;
    private GameObject[] EndLB_EntryScores;

    //********************************************************************************
    // Utility
    //********************************************************************************

    public static void Load()
    {
        bool bSuccess = false;
        if (GetInstance().leaderBoard == null)
        {
            GetInstance().leaderBoard = new HiScoreEntry_SO[NUMBER_OF_ENTRIES];
            for(int i = 0; i < NUMBER_OF_ENTRIES; i++)
            {
                GetInstance().leaderBoard[i] = HiScoreEntry_SO.CreateEntry();
            }
        }

        bSuccess = FileSystem.Load(GetInstance().fileName, ref GetRef());
        if (bSuccess)
        {
            Debug.Log("Successfully loaded leader board.");
        }
        else
        {
            int score = 50;
            int inc = 50;

            Debug.Log("Failed to load leader board. Creating default data.");          
            Debug.Assert(GetInstance().leaderBoard != null);
            foreach (HiScoreEntry_SO entry in GetInstance().leaderBoard)
            {
                entry.SetEntry("AAA", score);
                score += inc;
            }

            Array.Reverse(GetInstance().leaderBoard);

        }

    }

    public static void Save()
    {
        FileSystem.Save(GetInstance().fileName, ref GetRef());
    }

    public static bool CheckForNewHiScore(int _score)
    {
        bool bNewScore = false;
        ref HiScoreEntry_SO last = ref GetInstance().leaderBoard[9];
        Debug.Log("Lowest Score: " + last.GetScore().ToString());
        if(last.GetScore() < _score)
        {
            bNewScore = true;
            last.SetEntry(_score);
            Debug.Log("Added new hi score record: " + last.GetScore().ToString());          
        }

        return bNewScore;
    }

    public static void SortLeaderBoard()
    {
        Array.Sort(GetInstance().leaderBoard);
    }

    override public void Serialize(ref BinaryWriter writer)
    {
        foreach (HiScoreEntry_SO entry in leaderBoard)
        {
            entry.Serialize(ref writer);
        }

    }

    override public void Deserialize(ref BinaryReader reader)
    {
        foreach (HiScoreEntry_SO entry in leaderBoard)
        {
            entry.Deserialize(ref reader);
        }
    }

    //********************************************************************************
    // Setters
    //********************************************************************************

    public static void AddNewHiScore(string _name, int _score)
    {
        GetInstance().leaderBoard[9].SetEntry(_name, _score);
    }

    public static void AddNewHiScore(string _name)
    {
        GetInstance().leaderBoard[9].SetEntry(_name);
    }

    public static void AddNewHiScore(int _score)
    {
        GetInstance().leaderBoard[9].SetEntry(_score);
    }

    public static void PopulateTable()
    {
        GetInstance().EndLB_EntryNames = GameObject.FindGameObjectsWithTag(GetInstance().tag_EndLBName);
        GetInstance().EndLB_EntryScores = GameObject.FindGameObjectsWithTag(GetInstance().tag_EndLBScore);
        int i = 0;
        foreach (HiScoreEntry_SO entry in GetInstance().leaderBoard)
        {
            GetInstance().EndLB_EntryNames[i].GetComponent<TMPro.TextMeshProUGUI>().text = entry.GetPlayerName();
            GetInstance().EndLB_EntryScores[i].GetComponent<TMPro.TextMeshProUGUI>().text = entry.GetScore().ToString();
            i++;
        }
    }

    //********************************************************************************
    // Getters
    //********************************************************************************

    public static int GetHiScore()
    {
        return GetInstance().leaderBoard[0].GetScore();
    }

    private static ref LeaderBoard_SO GetRef()
    {
        return ref Instance;
    }

    private static LeaderBoard_SO GetInstance()
    {
        if (Instance == null)
            Instance = LeaderBoard_SO.Create<LeaderBoard_SO>();   

        return Instance;
    }

}

