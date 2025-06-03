using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaController : MonoBehaviour
{
    public TextMeshProUGUI textoEnergia;
    public Scrollbar barraEnergia;

    void Start()
    {
        barraEnergia.size = 1;
        textoEnergia.text = "100%";        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
