using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portada : MonoBehaviour
{
    public void ComenzarJueguito()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juegazo");
    }
}
