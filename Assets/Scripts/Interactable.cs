
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteractered = false;

    public virtual void Interact ()
    {
        // this is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }


    void Update()
    {
        if (isFocus && !hasInteractered)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            //Debug.Log("distance: " + distance + " radius: " +radius);

            if (distance  <= (radius + 1.0))
            {
                //Debug.Log("INTERACT");
                Interact();
                hasInteractered = true;
            }
        }
    }


    public void OnFocus (Transform playerTransform)
    {
        //Debug.Log("hello");
        isFocus = true;
        player = playerTransform;
        hasInteractered = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteractered = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
