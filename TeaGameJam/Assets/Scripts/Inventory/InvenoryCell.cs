using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvenoryCell : MonoBehaviour
{
    public GameObject containGO;

    public int ammount;

    public TextMeshProUGUI amm;

    public void Update()
    {
        amm.text = ammount.ToString();
    }

    
}
