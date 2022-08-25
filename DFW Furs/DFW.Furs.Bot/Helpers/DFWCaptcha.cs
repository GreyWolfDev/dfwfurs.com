using DFW.Furs.Bot.Interfaces;
using DFW.Furs.Bot.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;

namespace DFW.Furs.Bot
{
    public class DFWCaptcha : ICaptcha
    {
        public Captcha GenerateCaptcha()
        {
            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            var captcha = "";
            var rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 9; i++)
            {
                captcha += chars[rand.Next(chars.Length)];
            }

            var filepath = Path.Combine(Constants.BasePath, Constants.CaptchaFolder, "Captcha" + rand.Next() + ".jpg");
            using (var mem = new FileStream(filepath, FileMode.Create))
            using (var bmp = new Bitmap(520, 420))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add question 
                gfx.DrawString(captcha, new Font("Georgia", 60), new SolidBrush(Color.FromArgb(80, 80, 80)), 8, 170);

                //add noise 
                int i, r, x, y;
                var pen = new Pen(Color.Yellow)
                {
                    Width = 6
                };
                for (i = 1; i < 30; i++)
                {
                    pen.Color = Color.FromArgb(
                    160,
                    (rand.Next(0, 255)),
                    (rand.Next(0, 255)),
                    (rand.Next(0, 255)));

                    r = rand.Next(0, (520 / 3));
                    x = rand.Next(0, 520);
                    y = rand.Next(100, 200);

                    gfx.DrawEllipse(pen, x - r, y, r, r);
                }

                //render as Jpeg
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return new Models.Captcha(captcha.GetHashCode(), filepath);
        }

    }
}
