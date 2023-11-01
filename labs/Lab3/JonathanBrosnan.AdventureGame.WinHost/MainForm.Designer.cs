/*
 * ITSE 1430
 * Adventure Game
 * Name: Jonathan Brosnan
 * Lab 3 Final
 * 10/31/2023
 */

namespace JonathanBrosnan.AdventureGame.WinHost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            _mainMenu=new MenuStrip();
            fileToolStripMenuItem=new ToolStripMenuItem();
            exitToolStripMenuItem=new ToolStripMenuItem();
            characterToolStripMenuItem=new ToolStripMenuItem();
            addToolStripMenuItem=new ToolStripMenuItem();
            editToolStripMenuItem=new ToolStripMenuItem();
            deleteToolStripMenuItem=new ToolStripMenuItem();
            helpToolStripMenuItem=new ToolStripMenuItem();
            aboutToolStripMenuItem=new ToolStripMenuItem();
            _lstCharacters=new ListBox();
            _mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // _mainMenu
            // 
            _mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, characterToolStripMenuItem, helpToolStripMenuItem });
            _mainMenu.Location=new Point(0, 0);
            _mainMenu.Name="_mainMenu";
            _mainMenu.Size=new Size(800, 24);
            _mainMenu.TabIndex=0;
            _mainMenu.Text="menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name="fileToolStripMenuItem";
            fileToolStripMenuItem.Size=new Size(37, 20);
            fileToolStripMenuItem.Text="&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name="exitToolStripMenuItem";
            exitToolStripMenuItem.Size=new Size(93, 22);
            exitToolStripMenuItem.Text="Exit";
            exitToolStripMenuItem.Click+=OnFileExit;
            // 
            // characterToolStripMenuItem
            // 
            characterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem });
            characterToolStripMenuItem.Name="characterToolStripMenuItem";
            characterToolStripMenuItem.Size=new Size(70, 20);
            characterToolStripMenuItem.Text="&Character";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name="addToolStripMenuItem";
            addToolStripMenuItem.ShortcutKeys=Keys.Control|Keys.N;
            addToolStripMenuItem.Size=new Size(141, 22);
            addToolStripMenuItem.Text="New";
            addToolStripMenuItem.Click+=OnNewCharacter;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name="editToolStripMenuItem";
            editToolStripMenuItem.ShortcutKeys=Keys.Control|Keys.O;
            editToolStripMenuItem.Size=new Size(141, 22);
            editToolStripMenuItem.Text="Edit";
            editToolStripMenuItem.Click+=OnEditCharacter;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name="deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys=Keys.Delete;
            deleteToolStripMenuItem.Size=new Size(141, 22);
            deleteToolStripMenuItem.Text="Delete";
            deleteToolStripMenuItem.Click+=OnDeleteCharacter;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name="helpToolStripMenuItem";
            helpToolStripMenuItem.Size=new Size(44, 20);
            helpToolStripMenuItem.Text="&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name="aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys=Keys.F1;
            aboutToolStripMenuItem.Size=new Size(126, 22);
            aboutToolStripMenuItem.Text="&About";
            aboutToolStripMenuItem.Click+=OnHelpAbout;
            // 
            // _lstCharacters
            // 
            _lstCharacters.BorderStyle=BorderStyle.FixedSingle;
            _lstCharacters.Dock=DockStyle.Fill;
            _lstCharacters.Font=new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            _lstCharacters.FormattingEnabled=true;
            _lstCharacters.HorizontalExtent=1;
            _lstCharacters.HorizontalScrollbar=true;
            _lstCharacters.IntegralHeight=false;
            _lstCharacters.ItemHeight=17;
            _lstCharacters.Location=new Point(0, 24);
            _lstCharacters.Name="_lstCharacters";
            _lstCharacters.Size=new Size(800, 576);
            _lstCharacters.TabIndex=1;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            AutoSize=true;
            ClientSize=new Size(800, 600);
            Controls.Add(_lstCharacters);
            Controls.Add(_mainMenu);
            MainMenuStrip=_mainMenu;
            MinimumSize=new Size(300, 200);
            Name="MainForm";
            SizeGripStyle=SizeGripStyle.Show;
            Text="Jonathan Brosnan Adventure Game";
            _mainMenu.ResumeLayout(false);
            _mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip _mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem characterToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;

        private ListBox _lstCharacters;
    }
}