using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class multi_player_controleur : NetworkBehaviour
{
    Transform myTransform;
    Rigidbody myRigidbody;
    [SerializeField]
    float speed = 4;
    GameObject myCamera;

    // Use this for initializati
    void Start()
    {
        myTransform = GetComponent<Transform>();
        if (isLocalPlayer)
        {
            myCamera = myTransform.FindChild("camera").gameObject;
            myCamera.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            myTransform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed));
        }
    }
}
