using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpStrength = 10f;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        //Allows release of mouse from scene
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    void Movement()
    {
        //defines jump, vertical, and horizontal speed of movement
        float _translation = Input.GetAxisRaw("Vertical") * speed;
        float _straffe = Input.GetAxisRaw("Horizontal") * speed;
        float _jump = Input.GetAxisRaw("Jump") * jumpStrength;

        //moves character as a function of acceleration
        _translation *= Time.deltaTime;
        _straffe *= Time.deltaTime;
        _jump *= Time.deltaTime;

        transform.Translate(_straffe, _jump, _translation);
    }
    
}
