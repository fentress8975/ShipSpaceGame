using UnityEngine;

public class MovementHandler : MonoBehaviour
{

    public void Initialization(ShipSystem ship)
    {
        
    }

    public void Movement(Vector2 axis)
    {

        Acceleration(axis.x);
        Rotate(axis.y);
        
    }


    private void Acceleration(float x)
    {
        transform.position += transform.position + Vector3.forward * x * Time.deltaTime;
    }

    private void Rotate(float x)
    {
        transform.rotation = Quaternion.AngleAxis(x, Vector3.up);
    }


}


