using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float carSpeed;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        MoveHorizontal();
    }

    public void MoveUp()
    {
        Vector3 MoveUp = Vector3.up * carSpeed * Time.deltaTime;

        transform.Translate(MoveUp);
    }
    public void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveHorizontal = Vector3.right*horizontalInput*horizontalSpeed*Time.deltaTime;

        transform.Translate(moveHorizontal);
    }
}
