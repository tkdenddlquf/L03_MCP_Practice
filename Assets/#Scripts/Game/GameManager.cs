using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnEnable()
    {
        player.Died += StopGame;
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame) Restart();
    }

    private void OnDisable()
    {
        player.Died -= StopGame;
    }

    private void StopGame()
    {
        // 물리·회전·생성·타이머가 모두 deltaTime 기반이라 timeScale 0으로 일괄 정지된다.
        Time.timeScale = 0f;
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
