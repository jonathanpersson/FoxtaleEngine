using Foxtale.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public interface IComponent
{
    public IEntity Entity { get; set; }
    public void Initialize();
    public void Update(GameTime gameTime);
    public void Destroy();
}