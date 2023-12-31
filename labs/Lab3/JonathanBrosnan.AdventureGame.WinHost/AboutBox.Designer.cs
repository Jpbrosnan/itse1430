﻿/*
 * ITSE 1430
 * Adventure Game
 * Name: Jonathan Brosnan
 * Lab 3 Final
 * 10/31/2023
 */

namespace JonathanBrosnan.AdventureGame.WinHost;

partial class AboutBox
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
        tableLayoutPanel=new TableLayoutPanel();
        logoPictureBox=new PictureBox();
        labelProductName=new Label();
        labelVersion=new Label();
        labelCompanyName=new Label();
        okButton=new Button();
        tableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel
        // 
        tableLayoutPanel.ColumnCount=2;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
        tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
        tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
        tableLayoutPanel.Controls.Add(labelVersion, 1, 2);
        tableLayoutPanel.Controls.Add(labelCompanyName, 1, 1);
        tableLayoutPanel.Controls.Add(okButton, 1, 5);
        tableLayoutPanel.Dock=DockStyle.Fill;
        tableLayoutPanel.Font=new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        tableLayoutPanel.Location=new Point(10, 10);
        tableLayoutPanel.Margin=new Padding(4, 3, 4, 3);
        tableLayoutPanel.Name="tableLayoutPanel";
        tableLayoutPanel.RowCount=6;
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 38.11075F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.7491856F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.8469048F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel.Size=new Size(487, 307);
        tableLayoutPanel.TabIndex=0;
        // 
        // logoPictureBox
        // 
        logoPictureBox.Dock=DockStyle.Fill;
        logoPictureBox.Image=(Image)resources.GetObject("logoPictureBox.Image");
        logoPictureBox.Location=new Point(4, 3);
        logoPictureBox.Margin=new Padding(4, 3, 4, 3);
        logoPictureBox.Name="logoPictureBox";
        tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
        logoPictureBox.Size=new Size(152, 301);
        logoPictureBox.SizeMode=PictureBoxSizeMode.StretchImage;
        logoPictureBox.TabIndex=12;
        logoPictureBox.TabStop=false;
        // 
        // labelProductName
        // 
        labelProductName.Dock=DockStyle.Fill;
        labelProductName.Location=new Point(167, 0);
        labelProductName.Margin=new Padding(7, 0, 4, 0);
        labelProductName.MaximumSize=new Size(0, 20);
        labelProductName.Name="labelProductName";
        labelProductName.Size=new Size(316, 20);
        labelProductName.TabIndex=19;
        labelProductName.Text="Product: 'Jonathan Brosnan Adventure Game'";
        labelProductName.TextAlign=ContentAlignment.BottomCenter;
        // 
        // labelVersion
        // 
        labelVersion.Dock=DockStyle.Fill;
        labelVersion.Location=new Point(167, 60);
        labelVersion.Margin=new Padding(7, 0, 4, 0);
        labelVersion.MaximumSize=new Size(0, 20);
        labelVersion.Name="labelVersion";
        labelVersion.Size=new Size(316, 20);
        labelVersion.TabIndex=0;
        labelVersion.Text="Version: '1.0.0'";
        labelVersion.TextAlign=ContentAlignment.MiddleCenter;
        // 
        // labelCompanyName
        // 
        labelCompanyName.Dock=DockStyle.Fill;
        labelCompanyName.Location=new Point(167, 30);
        labelCompanyName.Margin=new Padding(7, 0, 4, 0);
        labelCompanyName.MaximumSize=new Size(0, 20);
        labelCompanyName.Name="labelCompanyName";
        labelCompanyName.Size=new Size(316, 20);
        labelCompanyName.TabIndex=22;
        labelCompanyName.Text="Company: Jonathan Brosnan";
        labelCompanyName.TextAlign=ContentAlignment.MiddleCenter;
        // 
        // okButton
        // 
        okButton.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
        okButton.DialogResult=DialogResult.Cancel;
        okButton.Location=new Point(395, 277);
        okButton.Margin=new Padding(4, 3, 4, 3);
        okButton.Name="okButton";
        okButton.Size=new Size(88, 27);
        okButton.TabIndex=24;
        okButton.Text="&OK";
        // 
        // AboutBox
        // 
        AcceptButton=okButton;
        AutoScaleDimensions=new SizeF(7F, 15F);
        AutoScaleMode=AutoScaleMode.Font;
        ClientSize=new Size(507, 327);
        Controls.Add(tableLayoutPanel);
        FormBorderStyle=FormBorderStyle.FixedDialog;
        Margin=new Padding(4, 3, 4, 3);
        MaximizeBox=false;
        MinimizeBox=false;
        Name="AboutBox";
        Padding=new Padding(10);
        ShowIcon=false;
        ShowInTaskbar=false;
        StartPosition=FormStartPosition.CenterParent;
        Text="AboutBox";
        tableLayoutPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel;
    private PictureBox logoPictureBox;
    private Label labelProductName;
    private Label labelVersion;
    private Label labelCompanyName;
    private Button okButton;
}
