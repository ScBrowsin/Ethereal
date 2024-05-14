using UnityEngine;

public class MainSoulfireMoveScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f; //This is a serialized field that allows you to set the movement speed of the GameObject
                                                       //in the Unity Inspector. The [SerializeField] attribute makes the private field visible
                                                       //in the Unity Inspector.
    private Rigidbody2D soulFireRigidbody2D;
    private Vector2 movementDirection;

    // Start is called before the first frame update
    // This Start below is for any code that will run as soon as the script is enabled, and it runs, precisely, once.
    // REMEMBER TO PUT A SEMICOLON AT THE END OF CODE, AND TO ALWAYS SAVE BEFORE GOING BACK TO UNITY.

    void Start() //In this start method, it gets a reference to the Rigidbody2D component attached to the GameObject
                 //and assigns it to the 'soulFireRigidbody2D' field.
    {
        soulFireRigidbody2D = GetComponent<Rigidbody2D>();
        soulFireRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation; //This piece of code fixes the issue of the sprite rotating when hitting collision.
                                                                                 //Running at the start of the script, the physics for the Rigidbody2D it was a part of
                                                                                 //was reset with every single time I opened the script, so that even when I hit the checked
                                                                                 //box to lock rotation, it would uncheck itself; the problem is clearly in the script,
                                                                                 //which is resolved with this line of code.
    }

    // Update is called once per frame
    // This update below, in contrast to start, runs constantly whilst the script is enabled, and it will fire off every line of code, every single frame,
    // running over... and over... and over.

    void Update() //In this update method, it sets the movementDirection vector based on the player using the 'Input.GetAxis' method. This typically
                  //captures input from the arrow keys or the WASD keys to control movement direction.
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    void FixedUpdate()
    {
        soulFireRigidbody2D.velocity = movementDirection * movementSpeed;
    }
}
