using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public bool haveItem;
    public IObject itemHolding;
    public GameObject itemUI;
    

    // Start is called before the first frame update
    void Start()
    {
        haveItem = false;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendItem(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            if (haveItem)
            {
                itemHolding.Execute(gameObject);
                haveItem = false;
                itemHolding = null;
                UpdateUI();
            }
            else
            {
            }
        }
    }

    public void UpdateUI()
    {
        if (itemHolding != null){
            itemUI.GetComponent<Text>().text = itemHolding.name;
        }else{
            itemUI.GetComponent<Text>().text = "No Item";
        }
    }
}