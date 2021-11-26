using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject winPanel, losePanel;

    public void WinState()
    {
        winPanel.SetActive(true);
    }

    public void LoseState()
    {
        losePanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}