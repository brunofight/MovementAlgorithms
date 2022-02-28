using UnityEngine;

public class Player : Kinematic
{
    
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButton(1)) 
        {
            RaycastHit hit;        

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
            {
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }

        transform.position -= Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * 50;
        transform.position -= Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * 50;

        

        
    }
}
