using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GravityBody))]
public class ThirdPersonController : MonoBehaviour {
	
	// public vars
	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
	public float jumpForce = 220;
	public LayerMask groundedMask;
	public CharacterController controller;
	public float turnSmoothTime = 0.1f;
	public float turnSmoothVelocity;
	public Transform cameraTransform;
	
	// System vars
	bool grounded;
	float verticalLookRotation;
	Rigidbody rigidbody;
	Vector3 moveDir;
	
	
	void Awake() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
		cameraTransform = Camera.main.transform;
	}
	
	void Update() {
		
		// Look rotation:
		//transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		//verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		//verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
		//cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
		
		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		
		Vector3 direction = new Vector3(inputX, 0f, inputY).normalized;

		if(direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
		}

		// Jump
		if (Input.GetButtonDown("Jump")) {
			if (grounded) {
				rigidbody.AddForce(transform.up * jumpForce);
			}
		}
		
		// Grounded check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
		}
		else {
			grounded = false;
		}	
	}
}