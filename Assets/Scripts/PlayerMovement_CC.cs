using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
[RequireComponent(typeof(CharacterController))] //Es obligatorio que tenga el componente, sino lo tiene lo pone automaticamente.

public class PlayerMovement_CC : MonoBehaviour
{
    public float speed, rotationSpeed, gravityScale, jumpForce;

    private CharacterController characterController;

    private float yVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            yVelocity = 0; //cuando es 0 no acumula velocidad
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        Jump(jumpPressed);
        Movemenet(x,z);
        //Rotate(mouseX);

    }
    void Jump(bool jumpPressed) // Se pone la variable bool entre parentesis por que sino no detecta la variable al estar fuera del metodo
    {
        //salto
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity += jumpForce;
        }
    }
    
    void Movemenet(float x, float z)
    {
        //Movimiento
        Vector3 movementVector = transform.forward * speed * z + transform.right * speed * x;
        yVelocity -= gravityScale; // La y velocity es negativa ( gravedad )
        movementVector.y = yVelocity; // Estbablecemos la Gravedad ( la y )

        movementVector *= Time.deltaTime; // mV = mV * dt (Para que se mueva igual en todos los monitores) ESTO SE PONE PRIMERO
        characterController.Move(movementVector); // componente que tiene el Character controller para que se muevan los objetos
    }

    void Rotate(float mouseX)
    {
        //Rotation
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation); // Se aplica la rotacion, tiene numero imaginarios
    }

}
