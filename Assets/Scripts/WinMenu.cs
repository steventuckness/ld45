using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private GameObject winMenuUI;

    void Start()
    {
        winMenuUI.SetActive(false);
    }
    
    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        winMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
