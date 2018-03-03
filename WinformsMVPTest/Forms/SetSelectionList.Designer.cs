namespace WinformsMVPTest.Forms
{
    partial class SetSelectionList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.setGrid = new System.Windows.Forms.DataGridView();
            this.AddSet = new System.Windows.Forms.Button();
            this.UpdateSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.setGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // setGrid
            // 
            this.setGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.setGrid.Location = new System.Drawing.Point(12, 33);
            this.setGrid.Name = "setGrid";
            this.setGrid.Size = new System.Drawing.Size(305, 288);
            this.setGrid.TabIndex = 0;
            this.setGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.setGrid_CellDoubleClick);
            this.setGrid.SelectionChanged += new System.EventHandler(this.setGrid_SelectionChanged);
            // 
            // AddSet
            // 
            this.AddSet.Location = new System.Drawing.Point(12, 336);
            this.AddSet.Name = "AddSet";
            this.AddSet.Size = new System.Drawing.Size(75, 23);
            this.AddSet.TabIndex = 1;
            this.AddSet.Text = "Add Set";
            this.AddSet.UseVisualStyleBackColor = true;
            this.AddSet.Click += new System.EventHandler(this.AddSet_Click);
            // 
            // UpdateSet
            // 
            this.UpdateSet.Location = new System.Drawing.Point(242, 336);
            this.UpdateSet.Name = "UpdateSet";
            this.UpdateSet.Size = new System.Drawing.Size(75, 23);
            this.UpdateSet.TabIndex = 2;
            this.UpdateSet.Text = "Update Set";
            this.UpdateSet.UseVisualStyleBackColor = true;
            this.UpdateSet.Click += new System.EventHandler(this.UpdateSet_Click);
            // 
            // SetSelectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 368);
            this.Controls.Add(this.UpdateSet);
            this.Controls.Add(this.AddSet);
            this.Controls.Add(this.setGrid);
            this.Name = "SetSelectionList";
            this.Text = "Set Selection ";
            this.Load += new System.EventHandler(this.SetSelectionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView setGrid;
        private System.Windows.Forms.Button AddSet;
        private System.Windows.Forms.Button UpdateSet;
    }
}

