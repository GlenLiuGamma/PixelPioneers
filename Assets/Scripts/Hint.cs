using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose){
            if(!dialoguePanel.activeInHierarchy){
                dialoguePanel.SetActive(true);
            }
        }
    }

    public void zeroText(){
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
  private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Jump")){
            playerIsClose = true;
            dialogueText.text = "Don’t touch the water!";
        }else if(other.CompareTag("LongRiver")){
            playerIsClose = true;
            dialogueText.text = "Can’t jump over! Switch to Dash Player~";
        }else if(other.CompareTag("Time")){
            playerIsClose = true;
            dialogueText.text = "Keep track of time Switch back to Default Player";
        }else if(other.CompareTag("DashBox")){
            playerIsClose = true;
            dialogueText.text = "Dash through the boxes!";
        }else if(other.CompareTag("Spike")){
            playerIsClose = true;
            dialogueText.text = "Spikes hurt all characters!";
        }else if(other.CompareTag("Antigravity")){
            playerIsClose = true;
            dialogueText.text = "Switch to Antigravity Player, and press space to change gravity";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Jump") || other.CompareTag("LongRiver") || other.CompareTag("Time") || other.CompareTag("DashBox") || other.CompareTag("Spike") || other.CompareTag("Antigravity")){
            playerIsClose = false;
            zeroText();
        }
    }
}
