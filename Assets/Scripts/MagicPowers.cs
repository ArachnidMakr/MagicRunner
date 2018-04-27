using UnityEngine;

public class MagicPowers : MonoBehaviour {

    [SerializeField]
    private float mana = 100f;
    [SerializeField]
    private float drain = 10f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform shieldPoint;
    [SerializeField]
    private Rigidbody prefab;

	// Use this for initialization
	void Start ()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoor: No camera referenced.");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shield();
        }

    }

    private void Shield()
    {
        Rigidbody _rigidPrefab;
        _rigidPrefab = Instantiate(prefab, shieldPoint.position, shieldPoint.rotation);
    }
}
