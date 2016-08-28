using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    public class HealthPowerUp : PowerUp
    {
        public int HealthAmount { get; set; }
        private readonly Animation _animation;

        public HealthPowerUp(Texture2D healthTexture, Animation animation, int seed)
            : base(healthTexture, seed)
        {
            HealthAmount = 3;
            Name = "Health";
            _animation = animation;
        }

        public override void OnPickup(Player effectedPlayer)
        {
            base.OnPickup(effectedPlayer);
            effectedPlayer.Health += HealthAmount;
        }

        public override void Draw(GameTime time, SpriteBatch batch)
        {
            base.Draw(time, batch);

            if (_animation == null)
            {
                return;
            }

            var animationScale = new Vector2(.18f);
            var pos = new Vector2(position.X, position.Y - 22);
            batch.Draw(_animation.Frame, pos, null, null, null, default(float), animationScale);
        }

        public override void Update(GameTime time)
        {
            base.Update(time);

            if (_animation == null)
            {
                return;
            }

            _animation.NextFrame(time);
        }
    }
}
