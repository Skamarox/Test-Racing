using UnityEngine;

public class Save
{
    public static void SaveSphere(int index) 
    {
        PlayerPrefs.SetInt("Index", index);
    }
}

public class Load
{
    public static int LoadSphere() 
    {
        int loadedObject = PlayerPrefs.GetInt("Index");
        return loadedObject;
    }
}