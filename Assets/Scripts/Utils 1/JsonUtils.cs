using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class JsonUtils 
{
    public static T getJsonObject<T>(string url) 
    {
        string jsonFile = "";
        if(File.Exists(url))
        {
            jsonFile = File.ReadAllText(url);
        }
        //Debug.Log("JSON FILE: "+jsonFile);
        
        return  JsonUtility.FromJson<T>(jsonFile);
    }

    public static void writeJsonObject(string url, object objectSaved)
    {
        string objectJson = JsonUtility.ToJson(objectSaved);
        System.IO.File.WriteAllText(url, objectJson);
    }
    public static void writeJsonWebObject(string url, object objectSaved)
    {
        string objectJson = JsonUtility.ToJson(objectSaved);
        UnityWebRequest request = UnityWebRequest.Put(url, objectJson);
        request.SendWebRequest();

        //System.IO.File.WriteAllText(url, objectJson);
    }
    
}
