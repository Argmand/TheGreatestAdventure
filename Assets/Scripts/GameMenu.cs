using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject stopMenuGO;

    public GameObject highlightResumeOption, highlightResetOption, highlightQuitOption;

    public Button resumeButton, resetButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StopMenu"))
        {
            StopMenu();
        }
    }

    private void StopMenu() 
    {
        if (stopMenuGO.activeSelf)
        {
            Time.timeScale = 1;
            stopMenuGO.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            stopMenuGO.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Button Click!");
            
        }
    }

    public void HandlMouseEnter() 
    {
        if (resumeButton.IsInteractable()) 
        {
            highlightResumeOption.SetActive(true);
        }
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
        stopMenuGO.SetActive(false);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame() 
    {
        Debug.Log("game has been closed");
        Application.Quit();
    }
}
