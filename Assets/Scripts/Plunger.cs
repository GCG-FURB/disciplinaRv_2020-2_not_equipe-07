using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Plunger : MonoBehaviour
{
    float power;
    float maxPower = 30f;
    float powerCountPerTick = 2;

    public Animator plungerAnimator;

    Rigidbody ballRigidbody;
    ContactPoint contact;

    bool ballReady;

    public bool ispressed = false;

    // Update is called once per frame
    void Update()
    {
        if (ballReady)
        {
            if (Input.GetKey(KeyCode.DownArrow) || ispressed)
            {
                OnPressedAction();
            }

            if (Input.GetKeyUp(KeyCode.DownArrow) || !ispressed)
            {
                OnReleasedAction();
            }
        }
    }

    public void OnPressedAction()
    {
        
        if (power <= maxPower)
        {
            power += powerCountPerTick * Time.deltaTime;
        }
        plungerAnimator.SetBool("activate", true);
        Debug.Log(power);
    }

    public void OnReleasedAction()
    {
        
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(-1 * power * contact.normal, ForceMode.Impulse);
        }
        plungerAnimator.SetBool("activate", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballReady = true;
        power = 0f;
        contact = collision.contacts[0];
        ballRigidbody = contact.otherCollider.attachedRigidbody;
    }

    private void OnCollisionExit(Collision collision)
    {
        ballReady = false;
        ballRigidbody = null;
    }
}
