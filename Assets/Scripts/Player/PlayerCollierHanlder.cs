using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollierHanlder : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with " + other.gameObject.name);
    }
   
}
