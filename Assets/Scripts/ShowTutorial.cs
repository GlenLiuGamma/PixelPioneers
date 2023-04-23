using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTutorial : MonoBehaviour
{
    [SerializeField] string tutorialText;
    public GameObject pauseTutorilUI;
    public Text TutorialTextComponent;
    // Start is called before the first frame update
    void Start()
    {
        pauseTutorilUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pauseTutorilUI.SetActive(true);
            TutorialTextComponent.text = tutorialText;
            Time.timeScale = 0f;
        }
    }
    public void ClickContinue()
    {
        pauseTutorilUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
