using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVisibleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] FinishSpehere;

    private void Start()
    {
        StartVisible();
    }

    private void StartVisible() 
    {
        int Index = Load.LoadSphere();
        GameObject sphere = FinishSpehere[Index];
        for(int i = 0; i < FinishSpehere.Length; i++)
        {
            if (FinishSpehere[i] == sphere)
            {
                FinishSpehere[i].SetActive(true);
                continue;
            }
            FinishSpehere[i].SetActive(false);
        }
    }

    public void ChangeVisible()
    {
        int Index = 0;
        for (int i = 0; i < FinishSpehere.Length; i++)
        {
            if(FinishSpehere[i].activeInHierarchy == true)
            {
                FinishSpehere[i].SetActive(false);
                try
                {
                    FinishSpehere[i + 1].SetActive(true);
                    Index = i + 1;
                }
                catch(IndexOutOfRangeException)
                {
                    FinishSpehere[0].SetActive(true);
                    Index = 0;
                }
                Save.SaveSphere(Index);
                break;
            }
        }
    }
}
