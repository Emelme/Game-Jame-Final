using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResManager : MonoBehaviour
{
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI ironText;

    public int water;
    public int food;
    public int iron;

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        waterText.text = water.ToString();
        foodText.text = food.ToString();
        ironText.text = iron.ToString();
    }
}
