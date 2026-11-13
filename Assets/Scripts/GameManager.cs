using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    [Tooltip("The current value to display, as a fraction of Max Health.")]
    public FloatVariableSO currentHealth;
    public FloatVariableSO maxHealth;
    //[SerializeField] private HandshakeManager handshakeManager;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnApplicationQuit()
    {
        currentHealth.value = maxHealth.value;
    }
}
