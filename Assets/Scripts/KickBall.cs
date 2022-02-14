using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    [SerializeField]
    private GameObject soccerballInstance;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    [Range(30f, 80f)]
    private float angle = 40f;

    [SerializeField]
    [Range(10f, 50f)]
    private float barrelSpeed = 20f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                ShootBallAtPoint(hitInfo.point);       
            }
        }
        if (Input.GetKey(KeyCode.W))
            angle = Mathf.Clamp(angle - barrelSpeed * Time.deltaTime, 10f, 80f);
        if (Input.GetKey(KeyCode.S))
            angle = Mathf.Clamp(angle + barrelSpeed * Time.deltaTime, 10f, 80f);
        transform.eulerAngles = new Vector3(0f,0f,90f-angle);
    }

    private void ShootBallAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        GameObject soccerBall = GameObject.Instantiate(soccerballInstance, spawnPoint.position, Quaternion.identity);

        soccerBall.GetComponent<Rigidbody>().velocity = velocity;
        //Destroy object after 8 seconds to avoid too many balls in the scene
        GameObject.Destroy(soccerBall, 8.0f);
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - spawnPoint.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}

// Credits: https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
//          http://answers.unity3d.com/comments/236712/view.html