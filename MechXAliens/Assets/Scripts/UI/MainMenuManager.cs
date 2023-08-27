using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        ActivateMainMenu(true);
    }

    public void ActivateMainMenu(bool state)
    {
        mainMenu.SetActive(state);
        optionMenu.SetActive(!state);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {

    }
}
