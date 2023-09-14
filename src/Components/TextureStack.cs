using System.Collections;
using System.Collections.Generic;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public class TextureStack : IComponent, ICollection<Texture2D>
{
    public bool IsReadOnly => false;
    public IEntity Entity { get; set; }
    public List<Texture2D> Textures { get; set; }
    public Color RenderTint { get; set; } = Color.White;
    public SpriteEffects Effect { get; set; } = SpriteEffects.None;
    public int Count => Textures.Count;
    public Texture2D this[int index]
    {
        get => Textures[index];
        set => Textures[index] = value;
    }

    public TextureStack()
    {
        Textures = new List<Texture2D>();
        TextureStackSystem.AddComponent(this);
    }

    public TextureStack(IEnumerable<Texture2D> textures)
    {
        Textures = new List<Texture2D>(textures);
        TextureStackSystem.AddComponent(this);
    }

    public TextureStack(params Texture2D[] textures)
    {
        Textures = new List<Texture2D>(textures);
        TextureStackSystem.AddComponent(this);
    }

    public void Add(Texture2D item)
    {
        Textures.Add(item);
    }

    public void Clear()
    {
        Textures.Clear();
    }

    public bool Contains(Texture2D item)
    {
        return Textures.Contains(item);
    }

    public bool Remove(Texture2D item)
    {
        return Textures.Remove(item);
    }

    public void CopyTo(Texture2D[] array, int arrayIndex)
    {
        Textures.CopyTo(array, arrayIndex);
    }

    public IEnumerator GetEnumerator()
    {
        return Textures.GetEnumerator();
    }

    IEnumerator<Texture2D> IEnumerable<Texture2D>.GetEnumerator()
    {
        return Textures.GetEnumerator();
    }

    public void Destroy()
    {
        Textures.Clear();
        TextureStackSystem.RemoveComponent(this);
    }
}