using UnityEngine;

public class LossArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.instance.CreateBall();
    }
}
