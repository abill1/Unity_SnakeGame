
/*****************************************************************************************
* HiScoreEntry_SO
*  An individual entry in the leaderboard. Contains a name and a score. 
*  
*****************************************************************************************/

using System;
using UnityEngine;
using System.IO;

public class HiScoreEntry_SO : FileData_Proto, IComparable<HiScoreEntry_SO>
{
    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private string playerName;
    [SerializeField] private int score;

    //********************************************************************************
    // Constructors
    //********************************************************************************

    public static HiScoreEntry_SO CreateEntry()
    {
        return HiScoreEntry_SO.Create<HiScoreEntry_SO>();
    }

    public static HiScoreEntry_SO CreateEntry(string _name, int _score)
    {
        HiScoreEntry_SO instance = HiScoreEntry_SO.Create<HiScoreEntry_SO>();
        instance.playerName = _name;
        instance.score = _score;
        return instance;
    }

    //********************************************************************************
    // Operator Methods
    //********************************************************************************

    public int CompareTo(HiScoreEntry_SO that)
    {
        int retVal = 0;

        if (that != null)
            retVal = this.score.CompareTo(that.score);
        if (retVal < 0)
            retVal = 1;
        else if (retVal > 0)
            retVal = -1;

        return retVal;
    }

    //********************************************************************************
    // Utility
    //********************************************************************************

    override public void Serialize(ref BinaryWriter writer)
    {
        writer.Write(playerName);
        writer.Write(score);

    }

    override public void Deserialize(ref BinaryReader reader)
    {
        playerName = reader.ReadString();
        score = reader.ReadInt32();

    }

    //********************************************************************************
    // Getters
    //********************************************************************************
    public int GetScore() { return score; }
    public string GetPlayerName() { return playerName; }

    //********************************************************************************
    // Setters
    //********************************************************************************

    public void SetEntry(string _name, int _score)
    {
        playerName = _name;
        score = _score;

    }

    public void SetEntry(string _name)
    {
        playerName = _name;

    }

    public void SetEntry(int _score)
    {
        score = _score;

    }

    //********************************************************************************
    // Private Helpers
    //********************************************************************************

}

