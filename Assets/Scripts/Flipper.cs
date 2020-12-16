using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Flipper : MonoBehaviour
{
    [SerializeField] public float StartPosition = 0;
    [SerializeField] public float EndPosition = 45;
    [SerializeField] public float Power = 10;
    [SerializeField] public float Damper = 1;

    private HingeJoint _hingeJoint;
    private JointSpring _jointSpring;
    private JointLimits _jointLimits;

    public enum Sides { LEFT, RIGHT }
    public Sides Side;

    public int Direction;

    public bool isPressed = false;

    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _hingeJoint.useSpring = true;
        _hingeJoint.useLimits = true;

        _jointSpring = new JointSpring();
        _jointSpring.spring = this.Power;
        _jointSpring.damper = this.Damper;

        _jointLimits = new JointLimits();
        _jointLimits.min = this.StartPosition;
        _jointLimits.max = this.EndPosition * this.Direction;

        _hingeJoint.limits = _jointLimits;
    }

    void Update()
    {
        if (this.Side == Sides.LEFT)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || isPressed)
            {
                OnPressedAction();
            }
            else
            {
                OnReleasedAction();
            }
        }

        if (this.Side == Sides.RIGHT)
        {
            if (Input.GetKey(KeyCode.RightArrow) || isPressed)
            {
                OnPressedAction();
            }
            else
            {
                OnReleasedAction();
            }
        }
    }

    public void OnPressedAction() 
    {

        _jointSpring.targetPosition = this.EndPosition * this.Direction;
        _hingeJoint.spring = _jointSpring;
        print("Flipper acionado");
    }

    public void OnReleasedAction() 
    {
        _jointSpring.targetPosition = this.StartPosition;
        _hingeJoint.spring = _jointSpring;
        print("flipper voltando ao estado inicial");
    }
}
