using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// LAB 8 - GOAL 2 & GOAL 3
///
/// You don't need to know C# to finish this script. Read the plain-language
/// comments above each section, then fill in the blanks marked "TODO" -
/// those are the only lines you need to write yourself.
///
/// What this script does, in order, every time the game runs:
///   1. Register itself with a shared GameEventSO, so it gets called
///      automatically whenever health changes - without the script that
///      changed it ever needing to know this one exists (Goal 2).
///   2. Whenever that happens, read two shared numbers (current health and
///      max health) and turn them into a 0-1 ratio the Slider understands
///      (Goal 2).
///   3. Also play a short sound at that exact moment, so the player hears
///      the hit as well as seeing the bar move (Goal 3).
///
/// Setup reminder: this script goes on its own empty GameObject - not on 
/// the Canvas or the Slider itself - and you drag in the two FloatVariableSO 
/// assets, the GameEventSO, the Slider, and an AudioSource in the Inspector.
/// </summary>
public class HealthBarUI : MonoBehaviour
{
    [Header("Data")]
    [Tooltip("The current value to display, as a fraction of Max Health.")]
    public FloatVariableSO currentHealth;
    public FloatVariableSO maxHealth;

    [Tooltip("The event this script listens for. Raised by whatever changes currentHealth.")]
    public GameEventSO onHealthChanged;

    [Header("UI")]
    public Slider slider;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip changeSound;

    // ------------------------------------------------------------------
    // OnEnable / OnDisable turn this script's listening on and off,
    // matching whether this GameObject is active in the scene - the same
    // Register/Unregister pattern from the lab prep deck's Week 6 callback
    // (attackAction.performed += ... there is RegisterListener(...) here).
    // ------------------------------------------------------------------
    private void OnEnable()
    {
        // ------------------------------------------------------------
        // TODO (one line):
        // Register OnHealthChangedEvent (the method a little further down
        // this file) as a listener on onHealthChanged, so Unity calls it
        // automatically whenever the event is raised elsewhere.
        //
        // The method you want is:
        //     onHealthChanged.RegisterListener(methodName);
        //
        // The method name to register is OnHealthChangedEvent - with no
        // parentheses after it here, since you're handing over the method
        // itself, not calling it.
        //
        // Write your one line below this comment:
        onHealthChanged.RegisterListener(OnHealthChangedEvent);


        // ------------------------------------------------------------

        // Sync once immediately, so the Slider reflects whatever
        // currentHealth already is the moment the scene starts - without
        // this, the bar would show a stale value until the first actual
        // change event. Provided for you, no change needed here.
        SyncSlider();
    }

    private void OnDisable()
    {
        // ------------------------------------------------------------
        // TODO (one line):
        // The exact mirror of the line you wrote in OnEnable above - stop
        // listening when this object is disabled, so it doesn't keep
        // reacting after it shouldn't.
        //
        // The method you want is:
        //     onHealthChanged.UnregisterListener(methodName);
        //
        // Write your one line below this comment:
        onHealthChanged.UnregisterListener(OnHealthChangedEvent);


        // ------------------------------------------------------------
    }

    // ------------------------------------------------------------------
    // Called automatically by onHealthChanged whenever it's Raised()
    // elsewhere - you never call this method directly yourself anywhere
    // in this script. This is the "reaction" half of the listener pattern.
    // ------------------------------------------------------------------
    private void OnHealthChangedEvent()
    {
        
        SyncSlider();

        // ------------------------------------------------------------
        // TODO (one line):
        // Play changeSound through audioSource, exactly once, the moment
        // this method runs (Goal 3).
        //
        // The method you want is:
        //     audioSource.PlayOneShot(clip);
        //
        // Hint: the clip you want is already stored above as changeSound.
        //
        // Write your one line below this comment:
        audioSource.PlayOneShot(changeSound);


        // ------------------------------------------------------------
    }

    // ------------------------------------------------------------------
    // Just the visual sync, with no sound - safe to call anytime,
    // including once at startup before any real change has occurred.
    // ------------------------------------------------------------------
    private void SyncSlider()
    {
        if (slider == null || maxHealth == null || maxHealth.value <= 0f) return;

        // ------------------------------------------------------------
        // TODO (one line):
        // Set slider.value to currentHealth's value as a fraction of
        // maxHealth's value, so a Slider with Min 0 / Max 1 fills to the
        // right proportion (Goal 2).
        //
        // Both shared numbers are read the same way:
        //     currentHealth.value
        //     maxHealth.value
        //
        // Write your one line below this comment:
        slider.value = currentHealth.value / maxHealth.value;


        // ------------------------------------------------------------
    }
}
