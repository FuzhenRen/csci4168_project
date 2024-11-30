/*
    This script controlls the floating plane for player jump on and move on it.
*/
using System.Collections;
using UnityEngine;

public class FloatPlane : MonoBehaviour
{
    public float moveSpeed = 2f;       
    public float moveDistance = 2f;    
    public float waitTime = 2f;        

    private Vector3 startPosition;     
    private int moveDirection = 1;     
    private bool isWaiting = false;    

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isWaiting) return;

        float movement = moveSpeed * Time.deltaTime * moveDirection;
        
        transform.Translate(movement, 0, 0);

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            StartCoroutine(WaitAtEnd());
        }
    }

    private IEnumerator WaitAtEnd()
    {
        isWaiting = true;
        moveDirection *= -1;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}
