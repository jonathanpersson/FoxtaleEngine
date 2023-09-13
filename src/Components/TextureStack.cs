using System.Collections.Generic;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public class TextureStack : IComponent
{
    public IEntity Entity { get; set; }
    public List<Texture2D> Textures { get; set; }
    public Color RenderTint { get; set; } = Color.White;
    public SpriteEffects Effect { get; set; } = SpriteEffects.None;

    public TextureStack()
    {
        Textures = new List<Texture2D>();
    }

    public TextureStack(IEnumerable<Texture2D> textures)
    {
        Textures = new List<Texture2D>(textures);
    }

    public TextureStack(params Texture2D[] textures)
    {
        Textures = new List<Texture2D>(textures);
    }

    public void Destroy()
    {
        Textures.Clear();
        TextureStackSystem.RemoveComponent(this);
    }
}