using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Turret;
    public GameObject bulletSpawnPoint;

    public float rotSpeed = 150.0f;
    public float turretRotSpeed = 10.0f;
    public float maxForwardSpeed = 300.0f;
    public float maxBackwardSpeed = -300.0f;
    public float shootRate = 0.5f;

    private float curSpeed, targetSpeed;


    protected float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       UpdateWeapon();
       UpdateControl();
        
    }

    void UpdateWeapon()
    {
        elapsedTime += Time.deltaTime;
        if(Input.GetMouseButtonDown(0))
        {
            if (elapsedTime >= shootRate)
            {
                // reset time
                elapsedTime = 0.0f;
                // Instantiate the bullet
                Instantiate(Bullet, 
                    bulletSpawnPoint.transform.position, 
                    bulletSpawnPoint.transform.rotation);
            }
        }
    }

    void UpdateControl()
    {
        // AIMING WITH THE MOUSE
        // Generate a plane that intersects the Transform's
        // position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up,
            transform.position + new Vector3(0, 0, 0));

        // Generate a ray from the cursor position
        Ray RayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane
        float HitDist = 0.0f;

        // If the ray is parallel to the plane, RayCast will return false
        if (playerPlane.Raycast(RayCast, out HitDist))
        {
            // Get the point along the ray that hits the calculated distance
            Vector3 RayHitPoint = RayCast.GetPoint(HitDist);

            Quaternion targetRotation = Quaternion.LookRotation(RayHitPoint - transform.position);

            Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, 
                targetRotation, Time.deltaTime * turretRotSpeed);
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            targetSpeed = maxForwardSpeed;
            
        }
        else if (Input.GetKey(KeyCode.X))
        {
            targetSpeed = maxBackwardSpeed;
            Debug.Log("fwd");
        }
        else
        {
            targetSpeed = 0.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0.0f);
        }

        // determine current speed
        curSpeed = Mathf.Lerp(curSpeed, targetSpeed, 7.0f * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }
}
