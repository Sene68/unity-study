using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.5f;

    private float lastShotTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow)) 
        //     transform.position -= moveTo;

        // if (Input.GetKey(KeyCode.RightArrow))
        //     transform.position += moveTo;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePosition.x, -2.35f, 2.35f);
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot() 
    {
        if (Time.time - lastShotTime > shootInterval) {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);

            lastShotTime = Time.time;
        }

        
    }
}
