using UnityEngine;

public class MovementHandler : MonoBehaviour
{

    public void Initialization()
    {

    }



    private void Acceleration()
    {
        transform.position += transform.position + Vector3.forward * Time.deltaTime;
    }

    private void Deceleration()
    {
        transform.position += transform.position + Vector3.back * Time.deltaTime;
    }

    private void RotateLeft()
    {
        transform.rotation = Quaternion.AngleAxis(1f, Vector3.up);
    }

    private void RotateRight()
    {
        transform.rotation = Quaternion.AngleAxis(-1f, Vector3.up);
    }

}


