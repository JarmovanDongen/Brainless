using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int shootingStrength;
    public Vector3 shootingPosition;
    public GameObject leafBlower;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting();   
        }
    }

    void shooting()
    {
        Quaternion leafBlowerRotation =leafBlower.transform.rotation * Quaternion.Euler(90,0,0);
        shootingPosition = leafBlower.transform.position + (leafBlowerRotation * new Vector3(0, 0, 3));
        RaycastHit hit;
        Vector3 direction = leafBlowerRotation * new Vector3(0,0,1);
        
        Debug.DrawRay(shootingPosition, direction, Color.red, 5000);
        bool hasCollided = Physics.Raycast(shootingPosition, direction, out hit, 100, LayerMask.NameToLayer("LeafBlower"));
        
        if (hasCollided)
        {
            GameObject zombie = hit.collider.gameObject;
          
            Vector3 shootingDirection = zombie.transform.position - shootingPosition ;
            Debug.Log(zombie.transform.position);
            Debug.DrawRay(shootingPosition, shootingDirection, Color.red, 5);
            Vector3 shootingForce = shootingDirection.normalized * shootingStrength;
            zombie.GetComponent<Rigidbody>().AddForce(shootingForce, ForceMode.Impulse);
        }

    }
}
