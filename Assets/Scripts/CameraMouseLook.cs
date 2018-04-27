using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour {

    [SerializeField]
    private float sensitivity = 5f;
    [SerializeField]
    private float smoothing = 2f;

    GameObject character;

    Vector2 mouseLook;
    Vector2 smoothV;

    // Use this for initialization
    void Start ()
    {
        character = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rotation();
    }

    void Rotation()
    {
        //identifies the movement of the mouse to sync to
        var _mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //takes the direction of the mouse and makes it makes it more ergonomic
        _mouseDirection = Vector2.Scale(_mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, _mouseDirection.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, _mouseDirection.y, 1f / smoothing);
        mouseLook += smoothV;

        //limit how high and low you can look
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //creates rotation value after user prefernce calculations
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //rotates character with value
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
