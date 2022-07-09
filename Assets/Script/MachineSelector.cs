using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSelector : MonoBehaviour
{
    [SerializeField] private Menu _Menu;
    private int Index = 0;
    private int Selector = 0;
    [SerializeField] private GameObject[] CarsInMenu;
    [SerializeField] private GameObject[] CarsInGame;

    private void Start()
    {
        CarsInMenu[Index].SetActive(true);
    }

    public void Next() 
    {
        Index++;
        Selector = Index > CarsInMenu.Length - 1 ? Index = 0 : Index;
        VisualCar(CarsInMenu);
    }

    public void Previous() 
    {
        Index--;
        Selector = Index < 0 ? Index = CarsInMenu.Length - 1 : Index;
        VisualCar(CarsInMenu);
    }

    private void VisualCar(GameObject[] Car) 
    {
        Debug.Log(Selector);
        for(int i = 0; i < Car.Length; i++)
        {
            if(Car[i] == Car[Selector])
            {
                Car[i].SetActive(true);
                continue;
            }
            Car[i].SetActive(false);
        }
    }

    public void Select()
    {
        _Menu.Close();
        VisualCar(CarsInGame);
    }
}
