using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject pressSpace;
    public GameObject pressX;
    public GameObject pressRight;
    public GameObject pressC;

    public Text dialogueText;
    public bool playerIsClose;
    public bool showX;
    public bool showRight;
    public bool showC;

    public bool closeWater;
    public bool closeSpike;

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose){
            if(!dialoguePanel.activeInHierarchy){
                dialoguePanel.SetActive(true);

            }
        }
        if(PlayerController.isBasicPlayer && closeWater){
            pressSpace.SetActive(true);
        }else{
            pressSpace.SetActive(false);

        }
        if(closeSpike){
            pressSpace.SetActive(true);
        }else{
            pressSpace.SetActive(false);

        }
        if(PlayerController.isBasicPlayer && showX){
            pressX.SetActive(true);
        }else{
            pressX.SetActive(false);

        }
        if(showRight){
            pressRight.SetActive(true);
        }else{
            pressRight.SetActive(false);
        }
        if(showC && PlayerController.isBasicPlayer){
            pressC.SetActive(true);
        }else{
            pressC.SetActive(false);

        }
        if(closeWater){
            pressSpace.SetActive(true);
        }else{
            pressSpace.SetActive(false);

        }

    }

    public void zeroText(){
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }
  private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Jump")){
            closeWater = true;
            playerIsClose = true;
        }else if(other.CompareTag("DashBox")){
            playerIsClose = true;
            showRight = true;
        }else if(other.CompareTag("Spike")){
            playerIsClose = true;
            closeSpike = true;
        }else if(other.CompareTag("Antigravity")){
            playerIsClose = true;
            closeWater = true;
        }else if(other.CompareTag("dashhint")){
            playerIsClose = true;
            showX = true;
        }else if(other.CompareTag("antihint")){
            playerIsClose = true;
            showC = true;
        }else if(other.CompareTag("antihint2")){
            closeWater = true;
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Jump") || other.CompareTag("Time") || other.CompareTag("DashBox") || other.CompareTag("Spike") || other.CompareTag("Antigravity") || other.CompareTag("dashhint") || other.CompareTag("antihint") || other.CompareTag("antihint2")){
            playerIsClose = false;
            closeWater = false;
            showX = false;
            showRight = false;
            showC = false;
            
            zeroText();
        }
    }
}
