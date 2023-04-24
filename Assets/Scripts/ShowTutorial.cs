using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShowTutorial : MonoBehaviour
{
    [SerializeField] string tutorialText;
    public GameObject pauseTutorilUI;
    public Text TutorialTextComponent;
    private TutorialAction inputActions;
    private void Awake()
    {
        inputActions = new TutorialAction();
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseTutorilUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnEnable()

    {
        if (inputActions != null)
        {
            inputActions.Continue.PlayerAction.performed += OnEnter;
            inputActions.Enable();
        }
        else
        {
            Debug.LogError("InputActions is null. Please check the initialization.");
        }
    }

    private void OnDisable()
    {
        inputActions.Continue.PlayerAction.performed -= OnEnter;
        inputActions.Disable();
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
    private void OnEnter(InputAction.CallbackContext context)
    {
        ClickContinue();
    }
}
