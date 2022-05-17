using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position += Vector3.up * Time.deltaTime;
    }


}
