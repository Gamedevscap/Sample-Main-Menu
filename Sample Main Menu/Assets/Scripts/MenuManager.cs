using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    /* ---
    ATTACH THIS SCRIPT 
    TO THE EVENT SYSTEM GAMEOBJECT 
    --- */

    [Header("Main Menu Composition")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject selectLevelMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject infoMenu;

    [Header("First Selected Buttons")]
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject selectLevelButton;
    [SerializeField] GameObject settingsButton;

    EventSystem es;

    private void Start()
    {
        es = GetComponent<EventSystem>();
    }

    private void Update()
    {
        BackToMainMenu();
        //FirstSelected();
    }

    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void ExitGame()
    {
        Application.Quit();
    }

    //--- Modify the event system to change the first selected button (usefull for the controller input) ---//

    /*void FirstSelected()
    {
        if (mainMenu.gameObject.activeSelf == true)
        {
            es.SetSelectedGameObject(startButton);
        }

        if (selectLevelMenu.gameObject.activeSelf == true)
        {
            es.SetSelectedGameObject(selectLevelButton);
        }

        if (settingsMenu.gameObject.activeSelf == true)
        {
            es.SetSelectedGameObject(settingsButton);
        }
    }*/

    //--- Conditions to use the "B" button or "Escape" button to back to the main menu ---//

    void BackToMainMenu()
    {
        if (Input.GetButton("Cancel"))
        {
            if (mainMenu.gameObject.activeSelf == false && selectLevelMenu.gameObject.activeSelf == true)
            {
                selectLevelMenu.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(true);
            }
            if (mainMenu.gameObject.activeSelf == false && settingsMenu.gameObject.activeSelf == true)
            {
                settingsMenu.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(true);
            }
            if (mainMenu.gameObject.activeSelf == false && infoMenu.gameObject.activeSelf == true)
            {
                infoMenu.gameObject.SetActive(false);
                mainMenu.gameObject.SetActive(true);
            }
        }
    }
}
