using System.Collections.Generic;
using System.Linq;
using Foxtale.Entities;
using Foxtale.Systems;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public class AnimationSet : IComponent
{
    private struct AnimationData
    {
        public int Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int StartY { get; set; }
        public int Frames { get; set; }
        public float Framerate { get; set; }
    }
    
    private List<Texture2D> _preAtlasTextures;
    private Dictionary<int, AnimationData> _atlasData;
    public int ActiveAnimation { get; private set; }
    public Texture2D TextureAtlas { get; private set; }
    public IEntity Entity { get; set; }
    public AnimatedSprite Sprite { get; set; }

    public AnimationSet(AnimatedSprite sprite)
    {
        _preAtlasTextures = new List<Texture2D>();
        _atlasData = new Dictionary<int, AnimationData>();
        Sprite = sprite;
        AnimationSetSystem.AddComponent(this);
    }

    public void Initialize()
    {
        Atlas();
    }

    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        AnimationSetSystem.RemoveComponent(this);
    }

    /// <summary>
    /// Add an animation to the animation set
    /// </summary>
    /// <param name="index">Index of animation in set</param>
    /// <param name="texture">Animation spritesheet</param>
    /// <param name="spriteWidth">Width of sprite</param>
    /// <param name="framerate">Framerate of animation, if 0 -> use Sprite.Framerate</param>
    public void AddAnimation(int index, Texture2D texture, int spriteWidth, float framerate = 0)
    {
        int startY = _preAtlasTextures.Select(tex => tex.Height).Prepend(0).Sum();
        _atlasData.Add(index, new AnimationData()
        {
            Index = _preAtlasTextures.Count,
            Width = spriteWidth,
            Height = texture.Height,
            StartY = startY,
            Framerate = framerate != 0 ? framerate : Sprite.Framerate,
            Frames = texture.Width / spriteWidth
        });
        _preAtlasTextures.Add(texture);
    }

    /// <summary>
    /// Create a new texture atlas for the animation set
    /// </summary>
    public void Atlas()
    {
        if (_preAtlasTextures.Count < 1) return;
        int atlasWidth = _preAtlasTextures.Select(texture => texture.Width).Max();
        int atlasHeight = _preAtlasTextures.Select(texture => texture.Height).Sum();
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D result = new(UserInterfaceSystem.Graphics.GraphicsDevice,
            atlasWidth, atlasHeight);
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(result);
        UserInterfaceSystem.Graphics.GraphicsDevice.Clear(Color.Transparent);
        float y = 0;
        
        sb.Begin();
        foreach (AnimationData anim in _atlasData.Values)
        {
            sb.Draw(_preAtlasTextures[anim.Index], new Vector2(0, y), Color.White);
            y += anim.Height;
        }
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);
        TextureAtlas = result;
        Sprite.Texture = TextureAtlas;
    }

    /// <summary>
    /// Set active animation index, automatically updates sprite
    /// </summary>
    /// <param name="index">Index of animation</param>
    public void SetActive(int index)
    {
        if (!_atlasData.TryGetValue(index, out AnimationData anim)) return;
        Rectangle source = new Rectangle(0, anim.StartY, anim.Width, anim.Height);
        Sprite.SourceRectangle = source;
        Sprite.Framerate = anim.Framerate;
        Sprite.Frames = anim.Frames;
        Sprite.Frame = 0;
    }
}