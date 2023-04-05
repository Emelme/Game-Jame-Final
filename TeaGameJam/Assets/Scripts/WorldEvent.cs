using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldEvent : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject tornadoPrefab;
    public GameObject crab;
    public List<GameObject> supplies;
    private int i;
    private int a = 0;
    public bool isStarted = false;

    public GameObject windPrefab1;
    public GameObject windPrefab2;
    private ParticleSystem ps1;
    private ParticleSystem ps2;
    public GameObject player;
    public Walking walking;

    public GameObject popup;
    public TextMeshProUGUI poptext;
    // Start is called before the first frame update
    void Start()
    {
        walking = FindObjectOfType<Walking>();

        StartCoroutine(wait());
        StartCoroutine(spawnResourses());
    }

    
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(60f);
        StartCoroutine(eventWorld());
    }
    public IEnumerator eventWorld()
    {
        if (isStarted == false)
        {
            isStarted = true;
            yield return new WaitForSeconds(1f);
            i = Random.Range(1, 5);
            Debug.Log(i);
            if (i == 1) StartCoroutine(meteorRain());
            if (i == 2) StartCoroutine(tornado());
            if (i == 3) StartCoroutine(crabs());
            if (i == 4) StartCoroutine(wind());
            
        }
    }
    public IEnumerator popupEvent()
    {
        yield return new WaitForSeconds(7f);
        popup.SetActive(false);
    }
    public IEnumerator meteorRain()
    {
        popup.SetActive(true);
        poptext.text = "A meteor shower is coming. He will break down buildings, thereby impairing their productivity. To repair the building, go closer to it and press the LMB";
        StartCoroutine(popupEvent());
        while ( a < 30)
        {
            Instantiate(meteorPrefab, new Vector3(Random.Range(-55, 60), 15, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            a += 1;
        }
        a = 0;
        yield return new WaitForSeconds(60f);
        isStarted = false;
        StartCoroutine(eventWorld());
    }

    public IEnumerator tornado()
    {
        popup.SetActive(true);
        poptext.text = "The tornado is already close. How good that it is weak and almost harmless";
        StartCoroutine(popupEvent());
        Instantiate(tornadoPrefab, new Vector3(60, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(60f);
        isStarted = false;
        StartCoroutine(eventWorld());
    }

    public IEnumerator crabs()
    {
        popup.SetActive(true);
        poptext.text = "The bugs are already here. If they touch you, they will take away water and food. Click on them LMB to destroy";
        StartCoroutine(popupEvent());
        while (a < 6)
        {
            Instantiate(crab, new Vector3(Random.Range(-50, 60), Random.Range(-3, 3), 0), Quaternion.identity);
            
            a++;
        }
        yield return new WaitForSeconds(60f);
        isStarted = false;
        StartCoroutine(eventWorld());

    }
    public IEnumerator spawnResourses()
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("res2");
        while (i < 6)
        {
            Instantiate(supplies[Random.Range(0, supplies.Count)], new Vector3(Random.Range(-50, 50), Random.Range(-1, 1), 0), Quaternion.identity);
            i++;
        }
        i = 0;
        
        Debug.Log("res");
        StartCoroutine(spawnResourses());
    }

    public IEnumerator wind()
    {
        popup.SetActive(true);
        poptext.text = "A fresh Martian breeze. Beauty";
        StartCoroutine(popupEvent());
        float startTime = Time.time;

        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);

        bool isWindLeftToRight = Random.Range(0, 2) == 0;

        if (isWindLeftToRight)
        {
            position = new Vector3(-30f, 5f, 0f);
            rotation = Quaternion.Euler(0f, 90f, 90f);
        }
        else
        {
            position = new Vector3(30f, 5f, 0f);
            rotation = Quaternion.Euler(0f, -90f, 90f);
        }

        GameObject wind1Instance = Instantiate(windPrefab1, player.transform.position + position, rotation);
        GameObject wind2Instance = Instantiate(windPrefab2, player.transform.position + position, rotation);

        wind1Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        wind2Instance.transform.localScale = new Vector3(1f, 1f, 1f);

        ps1 = wind1Instance.GetComponent<ParticleSystem>();
        ps2 = wind2Instance.GetComponent<ParticleSystem>();

        ps1.Play();
        ps2.Play();

        while (true)
        {
            if (isWindLeftToRight)
            {
                if (Input.GetAxisRaw("Horizontal") > 0f)
                {
                    walking.runSpeed = 10.5f;
                }
                else
                {
                    walking.runSpeed = 3.5f;
                }
            }
            else if (!isWindLeftToRight)
            {
                if (Input.GetAxisRaw("Horizontal") > 0f)
                {
                    walking.runSpeed = 3.5f;
                }
                else
                {
                    walking.runSpeed = 10.5f;
                }
            }

            wind1Instance.transform.position = new Vector3(player.transform.position.x + position.x, wind1Instance.transform.position.y, player.transform.position.z + position.z);
            wind2Instance.transform.position = new Vector3(player.transform.position.x + position.x, wind2Instance.transform.position.y, player.transform.position.z + position.z);

            if (Time.time - startTime >= 20f)
            {
                break;
            }

            yield return null;
        }

        ps1.Stop();
        ps2.Stop();

        yield return new WaitForSeconds(2f);

        DestroyImmediate(wind1Instance, true);
        DestroyImmediate(wind2Instance, true);

        walking.runSpeed = 7f;
        yield return new WaitForSeconds(60f);
        isStarted = false;
        StartCoroutine(eventWorld());
    }
}
