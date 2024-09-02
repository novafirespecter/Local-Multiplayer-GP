using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    public float open = 100f;
    public float range = 0.5f;
    public bool TouchingWall = false;
    public float UpwardSpeed = 3.3f;
    // public Vector2 climbLadder;
    public Camera LadderCam;

    public void OnClimbLadder(InputAction.CallbackContext context)
    {
        LadderClimb();
        // climbLadder = context.ReadValue<Vector2>();  
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void LadderClimb()
    {
        if(TouchingWall == true)
        {
            StartCoroutine(StartClimb());
        }

        GetComponent<Rigidbody>().isKinematic = false;
        TouchingWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(LadderCam.transform.position, LadderCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                TouchingWall = true;
            }
        }
    }

    IEnumerator StartClimb()
    {
        transform.position += Vector3.up * Time.deltaTime * UpwardSpeed;
        GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.85f);
        TouchingWall = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
