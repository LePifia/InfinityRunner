using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallaxMovement : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infinityPlanex;
    [SerializeField] bool infinityPlaneY;

    private Vector3 PastCameraTransform;
    private Vector3 Movement;

    private float textureUnitySizex;
    private float textureUnitysizey;

    // Start is called before the first frame update
    void Start()
    {
        PastCameraTransform = cam.transform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        textureUnitySizex = texture.width / sprite.pixelsPerUnit;
        textureUnitysizey = texture.height / sprite.pixelsPerUnit;
    }

    
    private void LateUpdate()
    {
        Movement = cam.transform.position - PastCameraTransform;

        transform.position += new Vector3(Movement.x * parallaxEffectMultiplier.x, Movement.y * parallaxEffectMultiplier.y);
        PastCameraTransform = cam.transform.position;

        //if (infinityPlanex)
        //{
          //  if (Mathf.Abs(cam.transform.position.x - transform.position.x) >= textureUnitySizex)
            //{
              //  float offsetPositionX = (cam.transform.position.x - transform.position.x) % textureUnitySizex;
                //transform.position = new Vector3(cam.transform.position.x + offsetPositionX, transform.position.y);
            //}
        //}

        //if (infinityPlaneY)
        //{
          //  if (Mathf.Abs(cam.transform.position.y - transform.position.y) >= textureUnitysizey)
            //{
              //  float offsetPositionY = (cam.transform.position.y - transform.position.y) % textureUnitysizey;
                //transform.position = new Vector3(transform.position.x, cam.transform.position.y + offsetPositionY);
            //}
        //}

    }
}
