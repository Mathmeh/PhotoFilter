namespace PhotoFilter
{
    partial class Filter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter));
            this.start_photo = new System.Windows.Forms.PictureBox();
            this.choose_photo_dialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choosePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choosePhilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filerAllImageInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.end_photo = new System.Windows.Forms.PictureBox();
            this.saveButton = new PhotoFilter.CustonButtton();
            this.FilterButton = new PhotoFilter.CustonButtton();
            this.repeatFilterButon = new PhotoFilter.CustonButtton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.start_photo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.end_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // start_photo
            // 
            this.start_photo.Location = new System.Drawing.Point(12, 32);
            this.start_photo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_photo.Name = "start_photo";
            this.start_photo.Size = new System.Drawing.Size(334, 402);
            this.start_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.start_photo.TabIndex = 0;
            this.start_photo.TabStop = false;
            // 
            // choose_photo_dialog
            // 
            this.choose_photo_dialog.Filter = "Images|*.bmp;*png;*jpg";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choosePhotoToolStripMenuItem,
            this.choosePhilterToolStripMenuItem,
            this.filerAllImageInFolderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choosePhotoToolStripMenuItem
            // 
            this.choosePhotoToolStripMenuItem.Name = "choosePhotoToolStripMenuItem";
            this.choosePhotoToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.choosePhotoToolStripMenuItem.Text = "choose photo";
            this.choosePhotoToolStripMenuItem.Click += new System.EventHandler(this.choosePhotoToolStripMenuItem_Click);
            // 
            // choosePhilterToolStripMenuItem
            // 
            this.choosePhilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussianBlurToolStripMenuItem,
            this.sharpenedToolStripMenuItem,
            this.boxBlurToolStripMenuItem,
            this.extensionToolStripMenuItem,
            this.motionBlurToolStripMenuItem});
            this.choosePhilterToolStripMenuItem.Name = "choosePhilterToolStripMenuItem";
            this.choosePhilterToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.choosePhilterToolStripMenuItem.Text = "choose filter";
            this.choosePhilterToolStripMenuItem.Visible = false;
            // 
            // gaussianBlurToolStripMenuItem
            // 
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.gaussianBlurToolStripMenuItem.Text = "Gaussian blur";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // sharpenedToolStripMenuItem
            // 
            this.sharpenedToolStripMenuItem.Name = "sharpenedToolStripMenuItem";
            this.sharpenedToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.sharpenedToolStripMenuItem.Text = "Sharpened";
            this.sharpenedToolStripMenuItem.Click += new System.EventHandler(this.sharpenedToolStripMenuItem_Click);
            // 
            // boxBlurToolStripMenuItem
            // 
            this.boxBlurToolStripMenuItem.Name = "boxBlurToolStripMenuItem";
            this.boxBlurToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.boxBlurToolStripMenuItem.Text = "BoxBlur";
            this.boxBlurToolStripMenuItem.Click += new System.EventHandler(this.boxBlurToolStripMenuItem_Click);
            // 
            // extensionToolStripMenuItem
            // 
            this.extensionToolStripMenuItem.Name = "extensionToolStripMenuItem";
            this.extensionToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.extensionToolStripMenuItem.Text = "Extension";
            this.extensionToolStripMenuItem.Click += new System.EventHandler(this.extensionToolStripMenuItem_Click_1);
            // 
            // motionBlurToolStripMenuItem
            // 
            this.motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            this.motionBlurToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.motionBlurToolStripMenuItem.Text = "MotionBlur";
            this.motionBlurToolStripMenuItem.Click += new System.EventHandler(this.motionBlurToolStripMenuItem_Click);
            // 
            // filerAllImageInFolderToolStripMenuItem
            // 
            this.filerAllImageInFolderToolStripMenuItem.Name = "filerAllImageInFolderToolStripMenuItem";
            this.filerAllImageInFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.filerAllImageInFolderToolStripMenuItem.Text = "filter all image in folder";
            this.filerAllImageInFolderToolStripMenuItem.Visible = false;
            this.filerAllImageInFolderToolStripMenuItem.Click += new System.EventHandler(this.filerAllImageInFolderToolStripMenuItem_Click);
            // 
            // end_photo
            // 
            this.end_photo.Location = new System.Drawing.Point(454, 32);
            this.end_photo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.end_photo.Name = "end_photo";
            this.end_photo.Size = new System.Drawing.Size(334, 402);
            this.end_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.end_photo.TabIndex = 3;
            this.end_photo.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.BorderColor = System.Drawing.Color.Snow;
            this.saveButton.ButtonColor = System.Drawing.Color.Red;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(454, 472);
            this.saveButton.Name = "saveButton";
            this.saveButton.OnHoverBorderColor = System.Drawing.SystemColors.InfoText;
            this.saveButton.OnHoverButtonColor = System.Drawing.SystemColors.ActiveBorder;
            this.saveButton.OnHoverTextColor = System.Drawing.SystemColors.HighlightText;
            this.saveButton.Size = new System.Drawing.Size(334, 65);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.TextColor = System.Drawing.Color.White;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.BorderColor = System.Drawing.Color.Snow;
            this.FilterButton.ButtonColor = System.Drawing.Color.Red;
            this.FilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FilterButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FilterButton.Location = new System.Drawing.Point(12, 472);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.FilterButton.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.FilterButton.OnHoverTextColor = System.Drawing.Color.Gray;
            this.FilterButton.Size = new System.Drawing.Size(334, 65);
            this.FilterButton.TabIndex = 6;
            this.FilterButton.Text = "Filter";
            this.FilterButton.TextColor = System.Drawing.Color.White;
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Visible = false;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // repeatFilterButon
            // 
            this.repeatFilterButon.BackColor = System.Drawing.Color.Red;
            this.repeatFilterButon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("repeatFilterButon.BackgroundImage")));
            this.repeatFilterButon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.repeatFilterButon.BorderColor = System.Drawing.Color.Empty;
            this.repeatFilterButon.ButtonColor = System.Drawing.Color.Empty;
            this.repeatFilterButon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.repeatFilterButon.Location = new System.Drawing.Point(352, 485);
            this.repeatFilterButon.Name = "repeatFilterButon";
            this.repeatFilterButon.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.repeatFilterButon.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.repeatFilterButon.OnHoverTextColor = System.Drawing.Color.Gray;
            this.repeatFilterButon.Size = new System.Drawing.Size(55, 43);
            this.repeatFilterButon.TabIndex = 7;
            this.repeatFilterButon.TextColor = System.Drawing.Color.White;
            this.repeatFilterButon.UseVisualStyleBackColor = false;
            this.repeatFilterButon.Visible = false;
            this.repeatFilterButon.Click += new System.EventHandler(this.repeatFilterButon_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choost folder which will be filtered";
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.Description = "Choose folder to save";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.ForeColor = System.Drawing.Color.Gold;
            this.sizeLabel.Location = new System.Drawing.Point(44, 442);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 20);
            this.sizeLabel.TabIndex = 10;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.ForeColor = System.Drawing.Color.Gold;
            this.weightLabel.Location = new System.Drawing.Point(273, 442);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(0, 20);
            this.weightLabel.TabIndex = 11;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.repeatFilterButon);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.end_photo);
            this.Controls.Add(this.start_photo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Filter";
            this.Text = "Filter";
            ((System.ComponentModel.ISupportInitialize)(this.start_photo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.end_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem sharpenedToolStripMenuItem;

        private System.Windows.Forms.PictureBox end_photo;

        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem choosePhilterToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem choosePhotoToolStripMenuItem;

        private System.Windows.Forms.PictureBox start_photo;

        private System.Windows.Forms.OpenFileDialog choose_photo_dialog;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem boxBlurToolStripMenuItem;
        private CustonButtton saveButton;
        private CustonButtton FilterButton;
        private System.Windows.Forms.ToolStripMenuItem extensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motionBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findEdgesToolStripMenuItem;
        private CustonButtton repeatFilterButon;
        private System.Windows.Forms.ToolStripMenuItem filerAllImageInFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label weightLabel;
    }
}