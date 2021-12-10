using UnityEngine;

public class Pause : MonoBehaviour
{
   public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
