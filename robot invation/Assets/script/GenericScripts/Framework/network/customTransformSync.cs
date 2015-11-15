using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class customTransformSync : NetworkBehaviour {
    [SerializeField]
    float rotationInterpolation= 0.3f;
    [SerializeField]
    float potitionInterpolation= 0.08f;
    Vector3 lastPosition;
    float lastRotation;
    Transform myTransform;
    [SyncVar]
    Vector3 sycPotition;
    [SyncVar]
    float sycRotationY;
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            CmdSendMyPosition(myTransform.position);
            CmdSendMyRotation(myTransform.eulerAngles.y);
           
        }
        else
        {
            myTransform.position = Vector3.Lerp(myTransform.position, sycPotition, Time.deltaTime * 15);
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(0, sycRotationY, 0), Time.deltaTime * 15);
        }
    }
    [Command]
    void CmdSendMyPosition(Vector3 potision)
    {
        sycPotition = potision;
    }
    [Command]
    void CmdSendMyRotation(float RotaionY)
    {
        sycRotationY = RotaionY;
    }

}
