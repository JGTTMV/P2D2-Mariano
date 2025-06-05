using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2DEngine.GameObjects;
using P2DEngine.GameObjects.Collisions;
using System.Windows.Forms;
using P2DEngine.Managers;
using System.Windows;

namespace P2DEngine.Games
{
    public class Mariano : myGame
    {
        private myPlayer player; // Nuestro personaje Mario
        private mySprite marianoSprite;
        private float moveSpeed = 200f; // Velocidad de movimiento
        private bool isFacingRight = true; // Dirección del personaje
        private bool isWalking = false;
        private bool isJumping = false;

        public Mariano(int width, int height, int FPS, myCamera c) : base(width, height, FPS, c)
        {
            /*
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
            */

            // 2. Crear el objeto del jugador
            player = new myPlayer(100, 450, 50, 80, marianoSprite);

            Instantiate(player);
        }

        protected override void ProcessInput()
        {
            /*
            // Reiniciar estado de caminar
            isWalking = false;

            // Movimiento horizontal
            if (myInputManager.IsKeyPressed(Keys.Right))
            {
                player.x += moveSpeed * deltaTime;
                isFacingRight = true;
                isWalking = true;
            }
            else if (myInputManager.IsKeyPressed(Keys.Left))
            {
                player.x -= moveSpeed * deltaTime;
                isFacingRight = false;
                isWalking = true;
            }

            // Salto (simplificado)
            if (myInputManager.IsKeyPressed(Keys.Space) && !isJumping)
            {
                isJumping = true;
            }*/
        }

        protected override void Update()
        {
            /*
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
            */
            // Actualizar posición del jugador
            player.Update(deltaTime);
        }

        protected override void RenderGame(Graphics g)
        {
            // Limpiar pantalla
            g.Clear(Color.SkyBlue);

            // Dibujar al jugador
            //player.Draw(g, new Vector(player.x, player.y), new Vector(player.sizeX, player.sizeY));
        }
    }
}
