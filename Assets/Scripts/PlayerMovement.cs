using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject reindeer1;
    public GameObject reindeer2;
    public GameObject reindeer3;
    GameObject frontReindeer;

    Vector3 dir1;
    Vector3 dir2;
    Vector3 dir3;

    public float rotSpeed = 40;
    float angle = 0f;

    private void Start()
    {
        frontReindeer = reindeer3;
    }

    // Update is called once per frame
    void Update()
    {
        float maxY1 = Mathf.Abs(reindeer1.transform.position.y - transform.position.y);
        dir1 = (new Vector3(transform.position.x, reindeer1.transform.position.y, 0f) - transform.position).normalized;
        transform.position = transform.position + (dir1 / 250f * maxY1);
        transform.position = new Vector3(reindeer1.transform.position.x - 1f, transform.position.y, 0f);

        float maxY2 = Mathf.Abs(reindeer2.transform.position.y - reindeer1.transform.position.y);
        dir2 = (new Vector3(reindeer1.transform.position.x, reindeer2.transform.position.y, 0f) - reindeer1.transform.position).normalized;
        reindeer1.transform.position = reindeer1.transform.position + (dir2 / 250f * maxY2);
        reindeer1.transform.position = new Vector3(reindeer2.transform.position.x - 0.8f, reindeer1.transform.position.y, 0f);
        

        float maxY3 = Mathf.Abs(reindeer3.transform.position.y - reindeer2.transform.position.y);
        dir3 = (new Vector3(reindeer2.transform.position.x, reindeer3.transform.position.y, 0f) - reindeer2.transform.position).normalized;
        reindeer2.transform.position = reindeer2.transform.position + (dir3 / 250f * maxY3);
        reindeer2.transform.position = new Vector3(reindeer3.transform.position.x - 0.8f, reindeer2.transform.position.y, 0f);
        


        frontReindeer.transform.position += frontReindeer.transform.TransformDirection(Vector3.right).normalized / 500f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            angle += rotSpeed * Time.deltaTime;
            frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            angle -= rotSpeed * Time.deltaTime;
            frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            if(angle > 0.1)
            {
                angle -= rotSpeed * Time.deltaTime;
                frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else if(angle < -0.1)
            {
                angle += rotSpeed * Time.deltaTime;
                frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                angle = 0;
                frontReindeer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            
        }

        transform.right = reindeer1.transform.position - transform.position;
        reindeer1.transform.right = reindeer2.transform.position - reindeer1.transform.position;
        reindeer2.transform.right = reindeer3.transform.position - reindeer2.transform.position;
        
        angle = Mathf.Clamp(angle, -60f, 60f);

    }
}
