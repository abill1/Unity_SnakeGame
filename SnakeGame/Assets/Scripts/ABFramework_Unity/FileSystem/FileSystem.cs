
/*****************************************************************************************
* FileSystem
*  Used to write the data from any object derived by the FileData_Proto class to a file
*  
*****************************************************************************************/

using System.IO;
using UnityEngine;

public class FileSystem : ScriptableObject
{
    //********************************************************************************
    // Singleton
    //********************************************************************************

    private static FileSystem Instance;

    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private string FolderLocation;
    [SerializeField] private string ROOT_LOCATION = Application.dataPath + "\\";

    //********************************************************************************
    // Utility Methods
    //********************************************************************************

    public static void Save<T>(string _fileName, ref T _proto) where T : FileData_Proto
    {
        string fileName = GetInstance().ROOT_LOCATION + _fileName;
        FileStream stream = File.OpenWrite(fileName);
        BinaryWriter writer = new BinaryWriter(stream);
        _proto.Serialize(ref writer);
        writer.Close();
        stream.Close();

    }


    public static bool Load<T>(string _fileName, ref T _proto) where T : FileData_Proto
    {
        string fileName = GetInstance().ROOT_LOCATION + _fileName;
        FileStream stream = File.Open(fileName, FileMode.OpenOrCreate);
        bool bSuccess = false;
        if (stream.Length > 0)
        {
            bSuccess = true;
            BinaryReader reader = new BinaryReader(stream);
            _proto.Deserialize(ref reader);
            reader.Close();         
        }
        stream.Close();

        return bSuccess;
    }

    //********************************************************************************
    // Get Singleton Instance
    //********************************************************************************

    private static FileSystem GetInstance()
    {
        if(Instance == null)
            Instance = ScriptableObject.CreateInstance<FileSystem>();    

        return Instance;
    }

}

