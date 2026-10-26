using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string obstacleTag = "Obstacle";

    public event Action Died;
    private bool isDead;

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 delta = new Vector3(input.x, 0f, input.y) * speed * Time.fixedDeltaTime;
        body.MovePosition(body.position + delta);
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead || !collision.gameObject.CompareTag(obstacleTag)) return;
        isDead = true;
        Debug.Log("Game Over");
        Died?.Invoke();
    }
}
