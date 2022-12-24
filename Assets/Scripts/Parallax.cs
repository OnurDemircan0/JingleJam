using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]  Transform _cam;

    [SerializeField]  float _moveSpeed;

    private void Update() 
    {
        transform.Translate(-1* _moveSpeed *Time.deltaTime,0f,0f);

        if (_cam.position.x >= transform.position.x + 18f)
        {
            transform.position = new Vector2(_cam.position.x+18f,transform.position.y);
        }
    }
}
