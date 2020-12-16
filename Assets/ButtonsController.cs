using UnityEngine;
using Vuforia;

public class ButtonsController : MonoBehaviour
{
    public GameObject leftFlipperVB, rightFlipperVB, plungerVB;

    public GameObject leftFlipperGameObject, rightFlipperGameObject, plungerGameObject;

    private Flipper leftFlipper, rightFlipper;

    private Plunger plunger;
    
    void Start()
    {
        leftFlipper = leftFlipperGameObject.GetComponent<Flipper>();
        rightFlipper = rightFlipperGameObject.GetComponent<Flipper>();
        plunger = plungerGameObject.GetComponent<Plunger>();
        
        
        leftFlipperVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnLeftFlipperButtonPressed);
        leftFlipperVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnLeftFlipperButtonReleased);

        rightFlipperVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnRightFlipperButtonPressed);
        rightFlipperVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnRightFlipperButtonReleased);

        plungerVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnPungerButtonPressed);
        plungerVB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnPungerButtonReleased);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRightFlipperButtonPressed(VirtualButtonBehaviour vb) 
    {
        print("Botao flipperi direito pressionado");
        // rightFlipper.OnPressedAction();
        rightFlipper.isPressed = true;
    }

    public void OnRightFlipperButtonReleased(VirtualButtonBehaviour vb) 
    {
        print("Botao flipperi direito largado");   
        // rightFlipper.OnReleasedAction();
        rightFlipper.isPressed = false;
    }

    public void OnLeftFlipperButtonPressed(VirtualButtonBehaviour vb) 
    {
       print("Botao flipperi esquerdo pressionado");
    //    leftFlipper.OnPressedAction();
        leftFlipper.isPressed = true;
    }

    public void OnLeftFlipperButtonReleased(VirtualButtonBehaviour vb) 
    {   
        print("Botao flipperi esquerdo largado");
        // leftFlipper.OnReleasedAction();
        leftFlipper.isPressed = false;
    }
    
    public void OnPungerButtonPressed(VirtualButtonBehaviour vb) 
    {
        print("Bota plunger pressionado");
        plunger.ispressed = true;
    }

    public void OnPungerButtonReleased(VirtualButtonBehaviour vb) 
    {   
        print("Botao plunger largado");
        plunger.ispressed = false;
    }

}
