using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }

    public void CenaLogin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
    }

    public void CenaCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    }

    public void Voltar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
