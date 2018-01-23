using UnityEngine;
using UnityEngine.UI;

public class ImageSequenceTextureArray : MonoBehaviour
{
    //An array of Objects that stores the results of the Resources.LoadAll() method  
    private Object[] objects;
    //Each returned object is converted to a Sprite and stored in this array  
    private Sprite[] mSprites;
    //With this Material object, a reference to the game object Material can be stored  
    private Image mImage;

    void Awake()
    {
        //Get a reference to the Image of the game object this script is attached to  
        mImage = this.GetComponent<Image>();
    }

    void Start()
    {
        //Load all textures found on the Sequence folder, that is placed inside the resources folder  
        this.objects = Resources.LoadAll("Sequence", typeof(Sprite));

        //Initialize the array of sprites with the same size as the objects array  
        this.mSprites = new Sprite[objects.Length];

        //Cast each Object to Sprite and store the result inside the Sprites array  
        for (int i = 0; i < objects.Length; i++)
        {
            this.mSprites[i] = (Sprite)this.objects[i];
        }
    }

    void Update()
    {
        //Set the image's sprite to the current value of the FramePosition variable  
        mImage.sprite = mSprites[FramePosition.mFramePosition];
    }
}