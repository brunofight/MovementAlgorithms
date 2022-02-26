using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
              
        RaycastHit hit;        

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }

        
    }
}
