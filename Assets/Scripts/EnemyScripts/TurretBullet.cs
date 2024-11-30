using UnityEngine;
using UnityEngine.SceneManagement; // 用于加载场景

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit! Restarting level...");
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
