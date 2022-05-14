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
    private bool toSend;
    public GameObject itemUI;
    

    // Start is called before the first frame update
    void Start()
    {
        haveItem = false;
        toSend = false;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendItem(InputAction.CallbackContext context)
    {
        toSend = context.action.triggered;
    }

    private void FixedUpdate()
    {
        if (toSend)
        {
            if (haveItem)
            {
                itemHolding.Execute(gameObject);
                haveItem = false;
                itemHolding = null;
                toSend = false;
                UpdateUI();
            }
            else
            {
                Debug.Log("No item");
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