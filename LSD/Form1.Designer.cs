namespace LSD
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button btnSelectPlay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.btnSelectPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(760, 400);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            // 
            // btnSelectPlay
            // 
            this.btnSelectPlay.Location = new System.Drawing.Point(12, 430);
            this.btnSelectPlay.Name = "btnSelectPlay";
            this.btnSelectPlay.Size = new System.Drawing.Size(150, 30);
            this.btnSelectPlay.TabIndex = 1;
            this.btnSelectPlay.Text = "Seleccionar y Reproducir";
            this.btnSelectPlay.UseVisualStyleBackColor = true;
            this.btnSelectPlay.Click += new System.EventHandler(this.btnSelectPlay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.btnSelectPlay);
            this.Controls.Add(this.pictureBoxGraph);
            this.Name = "MainForm";
            this.Text = "Rhythm Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

