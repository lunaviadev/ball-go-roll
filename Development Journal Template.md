# [PLATFORMER BASED GAME]

[Fundamentals in Game Development]

[Joshua Bellas]

[2326296]

## Research

## Various features I ended up looking into for this particular project

- [Unity physics based transform](https://docs.unity3d.com/ScriptReference/Transform.html)
- [Unity mathf clamp](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Mathf.Clamp.html)
- [Unity Vector 3](https://docs.unity3d.com/ScriptReference/Vector3.html)
- [Unity Euler Angles](https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html)


```markdown
Early on in the project's development I knew that I would want to draw inspiration from the 'Super Monkey Ball' franchise that focuses on puzzle platformer styles of gameplay by forcing you to rotate a stage to move a ball. I felt like this was a unique take on the platformer genre and thus wanted to take inspiration and implement this core system into my project, hence the research into object transformation.
```

## Implementation

```markdown
When it came to the implementation of my ideas my general thought process and aims for the project was to create a unique take on the platformer genre as previously mentioned. To do this I decided to take an unconventional method to controls to create a fresh user experience that is not commonly explored.
```
<br>

```csharp
 private Rigidbody rb;

 [SerializeField] private float speed;
 [SerializeField]private Vector3 currentValue;

 private Transform playerTransform;

 private float moveHorizontal;
 private float moveVertical;

 private void Start()
 {
    rb = gameObject.GetComponent<Rigidbody>();
    playerTransform = gameObject.transform;
 }
```
*Figure 1. The initialisation of the level's movement script*

```csharp
private void FixedUpdate()
{
    moveHorizontal = Input.GetAxis("Horizontal") * speed;
    moveVertical = Input.GetAxis("Vertical") * speed;

    Vector3 moveForward = new Vector3(moveVertical * Time.deltaTime, 0, moveHorizontal * Time.deltaTime);
    rb.MovePosition(rb.position + moveForward);


    CheckValue();  
    Quaternion deltaRotation = Quaternion.Euler(moveVertical, 0f , moveHorizontal);  // Rotation around the Y-axis
    rb.MoveRotation(rb.rotation * deltaRotation);
 
}

private void CheckValue()
{
    if ((playerTransform.eulerAngles.x < 325 && playerTransform.eulerAngles.x > 40) && moveVertical < 0)
    {
        moveVertical = 0;
    }
    if ((playerTransform.eulerAngles.x > 35f && playerTransform.eulerAngles.x < 39f) && moveVertical > 0)
    {
        moveVertical = 0;
    }

    if((playerTransform.eulerAngles.z < 325 && playerTransform.eulerAngles.z > 40) && moveHorizontal < 0)
    {
        moveHorizontal = 0;
    }
    else if((playerTransform.eulerAngles.z > 35f && playerTransform.eulerAngles.z < 39f) && moveHorizontal > 0)
    {
        moveHorizontal = 0;
    }
}
```
*Figure 2. Fixed update and general level movement handling*

```markdown
As seen in figure 1, I started off by serialising fields so that I could adjust the speed at which the level would rotate in order to adequately test what speeds felt the best to control during gameplay, I also initalise a rigidbody, as the level uses physics based movement, attaching and referencing said rigidbody is essential to apply transformations to the level. Then using euler angles I was able to limit the angles that the level was able to rotate at, this was done in order to prevent the player from completely flipping the stage in any given direction.
```

### Creative choices and its outcomes

- As mentioned previously, the choice to make the player rotate the stage instead of moving the ball in the level is one of the larger creative decisions I had made when deciding on the direction of the project.
- Though different and creative, it posed many challenges when initially trying to get the stage's rotation mechanics to work as intended.



<br>

![alt text]({886D58D5-AE16-4AD8-926C-C2565E8436DA}.png)
*Figure 3. The aforementioned stage and it's children objects that allow the rotation functions to work*

### Technical issues

- For a large majority of the development, the physics were not functioning as ideally as they should've been with the physics feeling floaty and generally unappealing to control due to the ball not sticking on the ground.
- When initially attempting to use a non-physics based movement system for the stage, a large amount of clipping issues cropped up due to the fact that the stage was not dynamically moving in real time and thus the ball was unable to properly be affected by the stage's rotation.

### Fixing technical issues

```csharp
public class ClampVelocity : MonoBehaviour
{
    [Range(-1000000f, 0f)] public float downwardForce = -500000f;
    private Rigidbody _rb;

    private void Start() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        _rb.AddForce(0f, downwardForce, 0f);
    }

}
```
*Figure 4. Fixing the issues with the ball not sticking to the ground and staying on the stage*

- Refer to *Figure 1* for my fix for getting the stage's clipping issues by switching it to physics based movement.

### Finishing off a few additional features

```markdown
To finish off and make the game feel like a complete package I implemented a few smaller features required by the task outline and implemented them into the project.
```

## Outcome

Here are a variety of links that lead to the game's gameplay being demonstrated, alongside a link to view the github repository online and download the current build of the game for yourself through Itch.io

- [Gameplay in action](https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley)
- [Github repository link](https://github.com/githubtraining/hellogitworld)
- [Game demo on Itch.io](https://samperson.itch.io/desktop-goose)


## Critical Reflection

### What did or did not work well and why?

- the game concept was good but needs more refinement.
- the physics based movement works well in practise but hard to control if you do not get used to it, better tutorials could ahve fixed this.

- What did not work well? What parts of the assignment that you felt did not fit the brief or ended up being lacklustre.
- What did you think went very well? Were there any specific aspects you thought were very good?

### What would you do differently next time?

- more research into physics based movement.
- add audio for polish
- make more levels.

- Are there any new approaches, methodologies or different software that you wish to incorporate if you have another chance?
- Is there another aspect you believe should have been the focus?

## Bibliography



## Declared Assets

- Please use the [harvard referencing convention](https://mylibrary.uca.ac.uk/referencing).

Infinity Blade: Adversaries in Epic Content - UE Marketplace (s.d.) At: https://www.unrealengine.com/marketplace/en-US/product/infinity-blade-enemies (Accessed  09/09/2024).

---

```Markdown
# General Tips

- Use plenty of images and videos to demonstrate your point. You can embed YouTube tutorials, your own recordings, etc.
- Always reference! Even documentation, tutorials and anything you used for your assignment. Use an inline reference for the sentence and a bibliography reference at the end.
- Word count is not important, you can also chose to use bullet points. As long as it is clear and readable, the format your decide to use can be flexible.
- You are free to use AI but please ensure you have made a note in the declared assets, for example if you have a script called Test.cs , you should note that AI was used to in the creation of this script. You can use a bullet point list for each asset used like:

The following assets were created or modified with the use of GPT 4o:
- Test.cs
- AnotherScript.cs
- Development Journal.html

```
