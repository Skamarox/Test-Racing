using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] MenuGroup;
    [SerializeField] private GameObject[] GameGroup;

    public void Open() 
    {
        Open(MenuGroup);
        Close(GameGroup);
    }

    public void Close()
    {
        Open(GameGroup);
        Close(MenuGroup);
    }

    private void Close(GameObject[] Group) 
    {
        foreach (var group in Group)
        {
            group.SetActive(false);
        }
    }
    private void Open(GameObject[] Group)
    {
        foreach (var group in Group)
        {
            group.SetActive(true);
        }
    }
}
