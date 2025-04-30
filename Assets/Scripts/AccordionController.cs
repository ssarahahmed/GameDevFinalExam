using UnityEngine;

public class AccordionController : MonoBehaviour
{
    public CrabHealthController CrabHealth;
    public AccordionHealthController AccordionHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CrabHealth != null && AccordionHealth != null && !AccordionHealth.IsGameOver)
            {
                CrabHealth.ReduceHealth();
            }
        }

       
    }

   
}
