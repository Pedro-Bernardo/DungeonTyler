using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject brush;
    [SerializeField] Texture grass;

    Texture2D texture;

    

    LineRenderer currentLineRenderer;
    Vector2 lastPos;
    bool drawing;
    // Start is called before the first frame update

    public void Draw(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            // CreateBrush();   
            drawing = true;
        }
        else if(Input.GetKey(KeyCode.Mouse0)){
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Debug.Log(grass.material.mainTexture);

            // Color originalColour = renderer.material.color;
            // renderer.material.color = new Color(originalColour.r, originalColour.g, originalColour.b, 0);
            // if(mousePos != lastPos){
            //     AddAPoint(mousePos);
            //     lastPos = mousePos;
            // }
        }
        else{
            if(drawing){
                drawing = !drawing;

                
            }
        }
    }

    void CreateBrush(){
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos){
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void Start()
    {
        drawing = false;
        // texture = new Texture2D(512, 512);
        // grass.material.mainTexture = texture;
        // texture.Apply();

        Texture2D texture = new Texture2D(128, 128);
        // Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 128, 128), Vector2.zero);
        // grass.GetComponent<MeshRenderer>().sprite = sprite;
     
        // for (int y = 0; y < texture.height; y++)
        // {
        //     for (int x = 0; x < texture.width; x++) //Goes through each pixel
        //     {
        //         Color pixelColour;
        //        if (Random.Range(0, 2) == 1) //50/50 chance it will be black or white
        //         {
        //             pixelColour = new Color(0, 0, 0, 1);
        //         }
        //         else
        //         {
        //             pixelColour = new Color(1, 1, 1, 1);
        //         }
        //         texture.SetPixel(x, y, pixelColour);
        //     }
        // }
        // texture.Apply();

        //    grass.GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
}
