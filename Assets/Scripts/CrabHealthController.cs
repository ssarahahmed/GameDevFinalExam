using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrabHealthController : MonoBehaviour
{
    public Slider CrabHealth;
    public float maxHealth = 100f;
    public float drainRate = 0.2f;
    private float currentHealth;
    private float timer;
    public GameObject WinText;
    public Animator animator;
    private bool isGameOver = false;
    public bool IsGameWon => isGameOver;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        timer = 0f;
        CrabHealth.maxValue = maxHealth;
        CrabHealth.value = currentHealth;
        if (CrabHealth.value != null)
        {
            WinText.SetActive(false);
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ReduceHealth()
    {
        if (isGameOver) return;

        currentHealth -= 10f;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
        }

        CrabHealth.value = currentHealth;

        DisplayWinText();
    }

    void DisplayWinText()
    {
        if (CrabHealth.value > 0) return;

        if (isGameOver) return;
        isGameOver = true;

        if (WinText != null)
        {
            WinText.SetActive(true);

        }
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
}
 