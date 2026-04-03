using UnityEngine;

public class GiraMachado : MonoBehaviour
{
    public float velRot = 100f;

    void Update()
    {
        transform.Rotate(Vector3.forward * velRot * Time.deltaTime);
    }
}
