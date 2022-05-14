using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    private MeshRenderer render;
    private float elapsedTime;
    public bool invisible;
    public List<IObject> allItems2 = new List<IObject>();

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible)
        {
            //Debug.Log(elapsedTime);
            if (elapsedTime <= 1000.0)
            {
                elapsedTime += 1;
            }
            else 
            {
                    invisible = false;
                    elapsedTime = 0;
                    render.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!invisible)
            {
                ItemManager itemManager = other.GetComponent<ItemManager>();
                itemManager.itemHolding = getRandomItem();
                itemManager.haveItem = true;
                itemManager.UpdateUI();
                setInvisible();
            }
        }
    }

    public void setInvisible()
    {
        Debug.Log("JE SUIS ENTRER");
        render.enabled = false;
        invisible = true;  
    }
    
    public IObject getRandomItem()
    {
        System.Random rand = new System.Random();
        return allItems2[rand.Next(0, allItems2.Count)];    
    }

}
