using UnityEngine;
using UnityEngine.UI;

public class AccordionHealthController : MonoBehaviour
{
    public Slider AccordionHealth;
    public float maxHealth = 100f;
    public float drainRate = 0.2f;
    private float currentHealth;
    private float timer;
    public Animator animator;
    public GameObject GameOverText;

    private bool isGameOver = false;

    public bool IsGameOver => isGameOver;

    public CrabHealthController CrabHealth;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        timer = 0f;
        AccordionHealth.maxValue = maxHealth;
        AccordionHealth.value = currentHealth;
        if (GameOverText != null)
            GameOverText.SetActive(false);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver || (CrabHealth != null && CrabHealth.IsGameWon))
            return;
        timer += Time.deltaTime;
        currentHealth -= drainRate * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        AccordionHealth.value = currentHealth;

        if (currentHealth <= 0f)
        {
            DisplayGameOverText();
        }

    }

    public void ReduceHealth()
    {
        if (isGameOver) return;
        currentHealth -= 10f;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        AccordionHealth.value = currentHealth;

        if (currentHealth <= 0f)
        {

            DisplayGameOverText();
        }
    }
    

    void DisplayGameOverText()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (GameOverText != null && AccordionHealth.value <= 0)
        {
            GameOverText.SetActive(true);

        }
        if (animator != null)
        {
            animator.enabled = false;
        }
    }
}

