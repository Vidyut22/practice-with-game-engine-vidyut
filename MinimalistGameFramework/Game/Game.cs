using System;
using System.Collections.Generic;

class Game
{
    public static readonly string Title = "Deliver The Present";
    public static readonly Vector2 Resolution = new Vector2(1024, 1024);
    Texture RSanta = Engine.LoadTexture("RSanta.png");
    Texture LSanta = Engine.LoadTexture("LSanta.png");
    Texture Border = Engine.LoadTexture("Border.png");
    Texture Tree1 = Engine.LoadTexture("Tree1.gif");
    Texture Tree2 = Engine.LoadTexture("Tree2.png");
    Texture Wall = Engine.LoadTexture("Wall.png");
    Texture Present1 = Engine.LoadTexture("Present1.png");
    Texture Present2 = Engine.LoadTexture("Present2.png");
    Texture Present3 = Engine.LoadTexture("Present3.png");
    Texture Present4 = Engine.LoadTexture("Present4.png");
    Texture Present5 = Engine.LoadTexture("Present5.png");
    Texture[] allPresents = new Texture[5] {Engine.LoadTexture("Present1.png"), Engine.LoadTexture("Present2.png"), Engine.LoadTexture("Present3.png"), Engine.LoadTexture("Present4.png"), Engine.LoadTexture("Present5.png") };
    int x = 30;
    int y = 500;
    int[] pos = new int[2];
    Boolean right;
    Boolean delivered = false;
    int count=40;
    int framesPassed = 0;
    public Game()
    {
       
        
    }
    public void Update()
    {
    
        Engine.DrawTexture(Wall, new Vector2(0, 0));
        Engine.DrawTexture(Border, new Vector2(0, 0));
        
        if (delivered)
        {
            Engine.DrawString("Congrats You Delivered The Present!!!", new Vector2(19, 800), Color.PaleVioletRed, Engine.LoadFont("Segoe UI.TTF", pointSize: 50));

            int currPresent = (framesPassed / 15) % 5;
            Engine.DrawTexture(allPresents[currPresent], new Vector2(680,600));
        }
        
        if(framesPassed % 40<20)
        {
            Engine.DrawTexture(Tree1, new Vector2(650, 220));
        }
        else
        {
            Engine.DrawTexture(Tree2, new Vector2(650, 220));
        }
        
        
        if (right)
        {
            Engine.DrawTexture(RSanta, new Vector2(x, y));
        }
        else
        {
            Engine.DrawTexture(LSanta, new Vector2(x, y));
        }

        if (Engine.GetKeyHeld(Key.D))
        {
            Engine.DrawTexture(RSanta, new Vector2(x, y));
            x += 5;
            right = true;
        }
        if (Engine.GetKeyHeld(Key.A))
        {
            Engine.DrawTexture(LSanta, new Vector2(x, y));
            x -= 5;
            right = false;
        }
        if (Engine.GetKeyHeld(Key.S))
        {
            if(right)
            {
                Engine.DrawTexture(RSanta, new Vector2(x, y));
            }
            else
            {
                Engine.DrawTexture(LSanta, new Vector2(x, y));
            }
            
            y += 5;
        }
        if (Engine.GetKeyHeld(Key.W))
        {
            if (right)
            {
                Engine.DrawTexture(RSanta, new Vector2(x, y));
            }
            else
            {
                Engine.DrawTexture(LSanta, new Vector2(x, y));
            }
            y -= 5;
        }
        if(!(delivered))
        {
            if (Math.Abs(600 - y) <= 70)
            {
                if (Math.Abs(800 - x) <= 170)
                {
                    Engine.DrawString("Press SPACE to Deliver Present", new Vector2(19, 800), Color.Red, Engine.LoadFont("Segoe UI.TTF", pointSize: 70));
                    if (Engine.GetKeyHeld(Key.Space))
                    {
                        Engine.DrawTexture(Present1, new Vector2(680, 600));
                        delivered = true;
                    }
                }
            }
            
            
        }
        framesPassed += 1;
    }
}
