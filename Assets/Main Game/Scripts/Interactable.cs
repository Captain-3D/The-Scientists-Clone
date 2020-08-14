using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

//[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;
	public Transform player;		// Reference to the player transform

	bool hasInteracted = false;	// Have we already interacted with the object?

	void Update ()
	{
		float distance = Vector3.Distance(player.position, interactionTransform.position);
		// If we haven't already interacted and the player is close enough
		if (!hasInteracted && distance <= radius)
		{
			// Interact with the object
			hasInteracted = true;
			Interact();
		}
	}

	// This method is meant to be overwritten
	public virtual void Interact () {}

	void OnDrawGizmosSelected ()
	{
		if(interactionTransform == null)
		{
			interactionTransform = transform;
		}

		if(player == null)
		{
			GameObject temp = GameObject.Find("Player");
			player = temp.GetComponent<Transform>();
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}