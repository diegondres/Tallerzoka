using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public Image mensajeFinal;
    public TextMeshProUGUI textoFinal;
    public TextMeshProUGUI timer;
    private int countEnemies = 0;
    public GameObject energy;
    public bool endGame = false;
    private Prota prota;
    void Awake()
    {
        prota = FindAnyObjectByType<Prota>();
    }
    void Update()
    {
        if (endGame && Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Portada");
        }
    }
    public void FinalDelJuego()
    {
        textoFinal.text = $"Felicitaciones!! Lograste sobrevivir por {timer.text}. \nEn ese tiempo lograste destruir {countEnemies} enemigos";
        timer.gameObject.SetActive(false);
        energy.SetActive(false);
        mensajeFinal.gameObject.SetActive(true);
        Destroy(prota.gameObject);
        endGame = true;
    }

    public void AddOneDead()
    {
        countEnemies++;
    }

}
