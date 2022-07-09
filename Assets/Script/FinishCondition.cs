using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCondition : MonoBehaviour
{
    [SerializeField] private SphereVisibleManager Manager;
    [SerializeField] private Menu _Menu;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            Manager.ChangeVisible();
            _Menu.Open();
            other.gameObject.SetActive(false);
        }
    }
}
