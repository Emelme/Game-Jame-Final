using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHeart : MonoBehaviour
{
    public List<GameObject> inHeart;

   
    public int gearID;
    public int gearCount;

    public int pumpID;
    public int pumpCount;

    public int pipeID;
    public int pipeCount;

    public int BagID;
    public int BagCount;

    public int GlassID;
    public int GlassCount;

    public int MetalID;
    public int MetalCount;

    public GameObject drill;
    public GameObject garden;
    public GameObject iron;
    public GameObject radio;

    public void Update()
    {
        
        if(gearCount >= 5 && pipeCount >= 2 && pumpCount >= 1)
        {
            Instantiate(drill, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (gearCount >= 1 && pipeCount >= 2 && BagCount >= 2 && GlassCount >= 2 && MetalCount >=1)
        {
            Instantiate(garden, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (gearCount >= 2 && pipeCount >= 1 && pumpCount >= 1 && GlassCount >= 2 && MetalCount >= 2 && FindObjectOfType<ResManager>().water >= 5)
        {
            FindObjectOfType<ResManager>().water -= 5;
            Instantiate(iron, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (gearCount >=1 && pipeCount >= 3 && GlassCount >= 1 && MetalCount >= 3 && FindObjectOfType<ResManager>().iron >= 5 && FindObjectOfType<ResManager>().food >= 10)
        {
            FindObjectOfType<ResManager>().iron -= 5;
            FindObjectOfType<ResManager>().food -= 10;
            Instantiate(radio, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    public void Count()
    {
        if(inHeart.Count <= 8)
        {
            pipeCount = 0;
            pumpCount = 0;
            gearCount = 0;
            BagCount = 0;
            GlassCount = 0;
            MetalCount = 0;
            foreach (GameObject i in inHeart)
            {
                if (i.GetComponent<itemBase>().itemID == pipeID) pipeCount++;
                if (i.GetComponent<itemBase>().itemID == pumpID) pumpCount++;
                if (i.GetComponent<itemBase>().itemID == gearID) gearCount++;
                if (i.GetComponent<itemBase>().itemID == BagID) BagCount++;
                if (i.GetComponent<itemBase>().itemID == GlassID) GlassCount++;
                if (i.GetComponent<itemBase>().itemID == MetalID) MetalCount++;
            }
        }
       
    }
}
