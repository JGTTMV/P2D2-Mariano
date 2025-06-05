using P2DEngine.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace P2DEngine.GameObjects
{
    public class myPlayer : myPhysicsBlock
    {
        private mySprite marianoSprite;
        private float speed = 200f; //Velocidad de movimiento
        private float invulnerableTime = 1.0f; //1 segundo de invulnerabilidad inicial
        private float moveSpeed = 200f; // Velocidad de movimiento
        private bool isFacingRight = true; // Dirección del personaje
        private bool isWalking = false;
        private bool isJumping = false;

        public myPlayer(float x, float y, float sizeX, float sizeY, mySprite sprite)
            : base(x, y, sizeX, sizeY, Color.Transparent)
        {
            // 1. Crear el sprite con las animaciones
            marianoSprite = new mySprite(0.1f); // Cada frame dura 0.1 segundos

            // Cargar animación de caminar hacia la derecha
            marianoSprite.AddFrame(myImageManager.Get("Mariano_R_Walk_1"));
            marianoSprite.AddFrame(myImageManager.Get("Mariano_R_Walk_2"));
            marianoSprite.AddFrame(myImageManager.Get("Mariano_R_Walk_3"));

            // Cargar animación de caminar hacia la izquierda
            marianoSprite.AddFrame(myImageManager.Get("Mariano_L_Walk_1"));
            marianoSprite.AddFrame(myImageManager.Get("Mariano_L_Walk_2"));
            marianoSprite.AddFrame(myImageManager.Get("Mariano_L_Walk_3"));

            // Cargar frames de idle (reposo)
            marianoSprite.AddFrame(myImageManager.Get("Mariano_R_Idle"), 3); // 3 frames iguales para que dure más
            marianoSprite.AddFrame(myImageManager.Get("Mariano_L_Idle"), 3);

            // Cargar frames de salto
            marianoSprite.AddFrame(myImageManager.Get("Mariano_R_Jump"));
            marianoSprite.AddFrame(myImageManager.Get("Mariano_L_Jump"));

            affectedByGravity = true;
        }

        public override void Draw(Graphics g, Vector position, Vector size)
        {
            //Dibuja el sprite correspondiente a la direccion actual
            if (marianoSprite.GetCurrentFrame() != null)
            {
                g.DrawImage(marianoSprite.GetCurrentFrame(), (float)position.X, (float)position.Y, (float)size.X, (float)size.Y);
            }
            else
            {
                Draw(g, position, size); //Fallback si no hay sprite
            }
        }

        public override void UpdateGameObject(float deltaTime)
        {
            if (invulnerableTime > 0) //Genera frames de invulnerabilidad
                invulnerableTime -= deltaTime;

            // Actualizar la animación según el estado del personaje
            if (isJumping)
            {
                // Usar frame de salto según dirección
                marianoSprite.SetAnimationRange(isFacingRight ? 6 : 7, 1);
            }
            else if (isWalking)
            {
                // Usar animación de caminar según dirección
                marianoSprite.SetAnimationRange(isFacingRight ? 0 : 3, 3);
            }
            else
            {
                // Usar animación de idle según dirección
                marianoSprite.SetAnimationRange(isFacingRight ? 6 : 7, 1);
            }

            // Actualizar posición del jugador
            //base.Update(deltaTime);
        }

        public void UpdateDirection(float deltaTime)
        {
            // Reiniciar estado de caminar
            isWalking = false;

            // Movimiento horizontal
            if (myInputManager.IsKeyPressed(Keys.Right))
            {
                x += moveSpeed * deltaTime;
                isFacingRight = true;
                isWalking = true;
            }
            else if (myInputManager.IsKeyPressed(Keys.Left))
            {
                x -= moveSpeed * deltaTime;
                isFacingRight = false;
                isWalking = true;
            }

            // Salto (simplificado)
            if (myInputManager.IsKeyPressed(Keys.Space) && !isJumping)
            {
                isJumping = true;
            }
        }

        //Metodo para mantener al jugador dentro de los limites de la pantalla
        public void KeepInBounds(float screenWidth, float screenHeight)
        {
            if (x < 0) x = 0;
            if (x + sizeX > screenWidth) x = screenWidth - sizeX;
            if (y < 0) y = 0;
            if (y + sizeY > screenHeight) y = screenHeight - sizeY;
        }
    }
}