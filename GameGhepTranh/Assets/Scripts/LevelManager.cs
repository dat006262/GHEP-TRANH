using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Sprite sprInput;
    public List<Sprite> sprOutput;
    public int rows = 3;
    public int columns = 3;
    public GameObject sprCut;

    private void Start()
    {
        GetBitMap(sprInput);
    }
    public void GetBitMap(Sprite input)
    {
        int partWidth = input.texture.width / columns;
        int partHeight = input.texture.height / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Tạo một Texture2D mới cho từng phần ảnh
                Texture2D newTexture = new Texture2D(partWidth, partHeight);
                Color[] pixels = input.texture.GetPixels(j * partWidth, i * partHeight, partWidth, partHeight);
                newTexture.SetPixels(pixels);
                newTexture.Apply();

                Sprite create = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);

                GameObject x = Instantiate(sprCut, this.gameObject.transform);
                x.GetComponent<SpriteRenderer>().sprite = create;
                x.transform.position = new Vector2(j, i);

                x.name = $"i{i}_j{j}";
            }
        }
    }
}
