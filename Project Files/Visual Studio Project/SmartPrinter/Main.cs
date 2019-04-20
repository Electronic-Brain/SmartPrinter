/* This project may not be reproduced or selling anywhere without prior written permission of Electronic Brain.
 * Project Developed by : Srejon Khan, Game Programmer, Electronic Brain and Ashikur Rahman, Game Programmer,Electronic Brain
 * Email : support@electronicbrain.net 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDLL
{
    public class SmartPrinter
    {
        #region variables
        private Font printFont;
        private string _texts;
        private Bitmap header;
        private string headerPath;
        #endregion

        /// <summary>
        /// Call this function for Print a document with Header image. 
        /// Header Image Resolution should be according to A4 page size. Download PSD templete from Github. 
        /// A4 Page screen resolution : 595 pixels x 842 pixels 
        /// </summary>
        /// <param name="texts">String that you want to Print in doc. Use Environment.NewLine to break a line. Check Example Class for more info. </param>
        /// <param name="headerDir">Header image dir with file name and extension.</param>
        public void PrintDocument(string texts, string headerDir)
        {
            headerPath = headerDir; // Storing Path
            _texts = texts; //Storing Header File Path
            printFont = new Font("Arial", 12, FontStyle.Bold); //Font Name, Size and Font Style.
            PrintDocument pd = new PrintDocument(); // Creating Object
            pd.PrintPage += new PrintPageEventHandler(this.spPrint);
            pd.Print();
        }

        /// <summary>
        /// Page Settings and Intialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void spPrint(object sender, PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left; //Left Margin of Page
            float topMargin = e.MarginBounds.Top; // Top Margin of Page

            Image image = Image.FromFile(headerPath); // Streaming image from File. File must be local.
            e.Graphics.DrawImage(image, (e.PageBounds.Width - image.Width) / 2, e.PageBounds.Y, image.Width, image.Height); //Drawing Header.
            e.Graphics.DrawString(_texts, printFont, Brushes.Black, new Point(25, 150));// Drawing Texts
        }
    }
}
