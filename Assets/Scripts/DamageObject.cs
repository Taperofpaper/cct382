using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [Header("Data")]
    [Tooltip("The current value to display, as a fraction of Max Health.")]
    public FloatVariableSO currentHealth;

    public GameEventSO onHealthChanged;

    void OnTriggerEnter(Collider other)
    {
        if (currentHealth.value > 0)
        {
            currentHealth.value -= 1;
        }
        onHealthChanged.Raise();
    }
}
