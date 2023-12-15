using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButon : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // 0. sahneyi yükle
    }
}
