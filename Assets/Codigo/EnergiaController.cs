using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaController : MonoBehaviour
{
    public TextMeshProUGUI textoEnergia;
    public Scrollbar barraEnergia;
    public float speed = 1f;
    private ControladorJuego controlador;
    void Start()
    {
        controlador = FindAnyObjectByType<ControladorJuego>();
        barraEnergia.size = 1;
        textoEnergia.text = GetTextEnergy();
    }

    public void UpdateEnergy(float change)
    {
        barraEnergia.size += change / 100 * speed;
        textoEnergia.text = GetTextEnergy();
        if (barraEnergia.size <= 0) controlador.FinalDelJuego();
    }

    private string GetTextEnergy()
    {
        float energia = barraEnergia.size * 100f;
        return energia.ToString("F2") + "%";
    }
}
