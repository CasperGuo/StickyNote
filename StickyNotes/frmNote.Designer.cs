namespace StickyNotes
{
  partial class frmNote
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.topPanel = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.noteText = new System.Windows.Forms.RichTextBox();
      this.topPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // topPanel
      // 
      this.topPanel.Controls.Add(this.btnClose);
      this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topPanel.Location = new System.Drawing.Point(0, 0);
      this.topPanel.Name = "topPanel";
      this.topPanel.Size = new System.Drawing.Size(434, 24);
      this.topPanel.TabIndex = 1;
      this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmNote_MouseDown);
      // 
      // btnClose
      // 
      this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnClose.ForeColor = System.Drawing.Color.Black;
      this.btnClose.Location = new System.Drawing.Point(411, 0);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(23, 24);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "X";
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // noteText
      // 
      this.noteText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.noteText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.noteText.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.noteText.ForeColor = System.Drawing.Color.Black;
      this.noteText.Location = new System.Drawing.Point(9, 35);
      this.noteText.Margin = new System.Windows.Forms.Padding(0);
      this.noteText.Name = "noteText";
      this.noteText.Size = new System.Drawing.Size(339, 231);
      this.noteText.TabIndex = 2;
      this.noteText.Text = "";
      this.noteText.TextChanged += new System.EventHandler(this.noteText_TextChanged);
      // 
      // frmNote
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ClientSize = new System.Drawing.Size(434, 321);
      this.ControlBox = false;
      this.Controls.Add(this.noteText);
      this.Controls.Add(this.topPanel);
      this.DoubleBuffered = true;
      this.ForeColor = System.Drawing.Color.Black;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmNote";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.frmNote_Load);
      this.Shown += new System.EventHandler(this.frmNote_Shown);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmNote_MouseDown);
      this.Move += new System.EventHandler(this.frmNote_Move);
      this.Resize += new System.EventHandler(this.frmNote_Resize);
      this.topPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.RichTextBox noteText;
  }
}

