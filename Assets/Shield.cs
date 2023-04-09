using UnityEngine;

public class Shield : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    GameObject shield;

    public static bool shieldDestroied = false;
    void Start() {
        shield = GameObject.Find("Shield");
        shield.SetActive(false);
    }
  // Update is called once per frame
//   void Update()
//     {
//         if(spriteRenderer != null){
//             spriteRenderer.enabled = !spriteRenderer.enabled;
//         }
//     }
}
