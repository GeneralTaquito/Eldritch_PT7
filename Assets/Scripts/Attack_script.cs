using Unity.VisualScripting;
using UnityEngine;

public class Attack_script : MonoBehaviour
{
    private bool attackable = false;
    public AudioClip AC1;


    private GameObject Human;
    private void OnTriggerEnter(Collider other) //trigger enter and exits to track humans entering the attack range and setting the entered human as a variable to destroy later
    {
        if (other.CompareTag("Human"))
        {
            attackable = true;
            Human = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Human)
        {
            Human = null;
            attackable = false;
        }
        
    }

    private void Update() // destroying the human
    {
        if (attackable && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(AC1, Human.transform.position);
            Destroy(Human);
        }
    }

}
