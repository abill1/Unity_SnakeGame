
/*****************************************************************************************
* FileData_Proto
*  A base class for any data that needs to be written to a file. 
*  
*****************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class FileData_Proto : ScriptableObject
{
    //********************************************************************************
    // Constructor
    //********************************************************************************
    

    // ----- Any derived object must call this method to instantiate the derived method. 
    protected static T Create<T>() where T : FileData_Proto
    {
        return ScriptableObject.CreateInstance<T>();
    }

    //********************************************************************************
    // File IO Methods
    //********************************************************************************

    abstract public void Serialize(ref BinaryWriter _writer);
    abstract public void Deserialize(ref BinaryReader _reader);

}

