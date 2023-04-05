using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironMine : MonoBehaviour
{
    public int ironMined;
    public int mine;
    public float miningSpeed = 10;
    public float durable = 1;
    public GameObject icon;

    public bool isRepair;
    public void Start()
    {
        ironMined = FindObjectOfType<ResManager>().iron;
        StartCoroutine(mining());
    }

    public void Update()
    {
        if (durable < 1) icon.SetActive(true);

        else icon.SetActive(false);

        if (isRepair)
        {
            if (Input.GetMouseButton(0) && FindObjectOfType<ResManager>().iron > 0)
            {
                FindObjectOfType<ResManager>().iron -= 1;
                durable += 0.3f;
            }
        }

        if (durable > 1) durable = 1;
        if (durable >= 1) isRepair = false;
    }
    public void hollow()
    {
        StartCoroutine(mining());
    }

    public IEnumerator mining()
    {
        Debug.Log("s");
        if (FindObjectOfType<ResManager>().water > 2)
        {
            FindObjectOfType<ResManager>().water -= 2;
            FindObjectOfType<ResManager>().iron++;
            mine++;

            yield return new WaitForSeconds(miningSpeed / durable);      
        }
        hollow();
    }

        public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "meteor" && durable > 0.3)
        {
            durable -= 0.3f;
        }

        if (collision.transform.tag == "repair" && durable < 1) isRepair = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "repair") isRepair = false;
    }
}
