/*
namespace HolesAreBad.Casting
{
    private class SpriteAnimations
    {
        public struct Sprite 
        {
            public Sprite() 
            {
                Texture2D texture; 
                Vector2 frameSize; 
                int maxFrame; 
                int framesWide; 
                Vector2 origin; 
                int frame;
            }
        }

        public SpriteAnimations(Actor actor)
        {
            image = actor.GetImage(); 
            width = actor.GetWidth(); 
            height = actor.GetHeight(); 
            x = actor.GetX(); 
            y = actor.GetY();
            Sprite sprite = { 0 };
            sprite.texture = LoadTexture(image);
            sprite.frameSize = Vector2(width, height);
            sprite.maxFrame = y; 
            sprite.framesWide = x; 
            sprite.origin = (64, 128);

        }

        void drawSprite(float x, float y, float scale, Color c)
        {
            float ox, oy; 
            ox = (sprite->frame % sprite->framesWide) * sprite->frameSize.x; 
            oy = (int)(sprite->frame / sprite->framesWide) * sprite->framesWide.y;
            DrawTexturePro(sprite->texture, (Rectangle){ox, oy, sprite->frameSize.x, sprite->frameSized.y}, 
                            (Rectangle){x, y, sprite->frameSize.x * scale, sprite->frameSize.y * scale},
                            (Vector2){sprite->origin.x * scale, sprite->origin.y * scale}); 
        }
    }

}
*/