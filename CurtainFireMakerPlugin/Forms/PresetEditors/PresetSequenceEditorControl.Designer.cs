﻿namespace CurtainFireMakerPlugin.Forms
{
    partial class PresetSequenceEditorControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxSequence = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ペーストToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.エクスプローラーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSelectedScript = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.saveFileDialogScript = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.エクスプローラーToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.atomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSequence
            // 
            this.listBoxSequence.AllowDrop = true;
            this.listBoxSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSequence.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxSequence.FormattingEnabled = true;
            this.listBoxSequence.ItemHeight = 12;
            this.listBoxSequence.Location = new System.Drawing.Point(6, 32);
            this.listBoxSequence.Name = "listBoxSequence";
            this.listBoxSequence.Size = new System.Drawing.Size(142, 292);
            this.listBoxSequence.TabIndex = 17;
            this.listBoxSequence.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChangedSequence);
            this.listBoxSequence.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropSequence);
            this.listBoxSequence.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterSequence);
            this.listBoxSequence.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBoxMouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.ToolStripMenuItemRemove,
            this.toolStripSeparator2,
            this.ToolStripMenuItemCopy,
            this.ペーストToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemOpen});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 126);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.OpeningContextMenu);
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.追加ToolStripMenuItem.Text = "追加";
            this.追加ToolStripMenuItem.Click += new System.EventHandler(this.ClickAdd);
            // 
            // ToolStripMenuItemRemove
            // 
            this.ToolStripMenuItemRemove.Name = "ToolStripMenuItemRemove";
            this.ToolStripMenuItemRemove.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemRemove.Text = "削除";
            this.ToolStripMenuItemRemove.Click += new System.EventHandler(this.ClickRemove);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // ToolStripMenuItemCopy
            // 
            this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemCopy.Text = "コピー";
            this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ClickCopy);
            // 
            // ペーストToolStripMenuItem
            // 
            this.ペーストToolStripMenuItem.Name = "ペーストToolStripMenuItem";
            this.ペーストToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ペーストToolStripMenuItem.Text = "ペースト";
            this.ペーストToolStripMenuItem.Click += new System.EventHandler(this.ClickPaste);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.エクスプローラーToolStripMenuItem,
            this.atomToolStripMenuItem});
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemOpen.Text = "プログラムから開く";
            // 
            // エクスプローラーToolStripMenuItem
            // 
            this.エクスプローラーToolStripMenuItem.Name = "エクスプローラーToolStripMenuItem";
            this.エクスプローラーToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.エクスプローラーToolStripMenuItem.Text = "エクスプローラー";
            this.エクスプローラーToolStripMenuItem.Click += new System.EventHandler(this.OpenWithExplorer);
            // 
            // atomToolStripMenuItem
            // 
            this.atomToolStripMenuItem.Name = "atomToolStripMenuItem";
            this.atomToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.atomToolStripMenuItem.Text = "Atom";
            this.atomToolStripMenuItem.Click += new System.EventHandler(this.OpenWithAtom);
            // 
            // textBoxSelectedScript
            // 
            this.textBoxSelectedScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectedScript.Location = new System.Drawing.Point(154, 47);
            this.textBoxSelectedScript.Multiline = true;
            this.textBoxSelectedScript.Name = "textBoxSelectedScript";
            this.textBoxSelectedScript.ReadOnly = true;
            this.textBoxSelectedScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSelectedScript.Size = new System.Drawing.Size(485, 277);
            this.textBoxSelectedScript.TabIndex = 19;
            this.textBoxSelectedScript.WordWrap = false;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.BackColor = System.Drawing.SystemColors.Control;
            this.labelPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelPath.Location = new System.Drawing.Point(154, 32);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(28, 12);
            this.labelPath.TabIndex = 18;
            this.labelPath.Text = "Path";
            // 
            // saveFileDialogScript
            // 
            this.saveFileDialogScript.Filter = "Python Script|*.py";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CurtainFireMakerPlugin.Properties.Resources.plus;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "スクリプト追加";
            this.toolStripButton1.Click += new System.EventHandler(this.ClickAdd);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::CurtainFireMakerPlugin.Properties.Resources.minus;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "スクリプト削除";
            this.toolStripButton2.Click += new System.EventHandler(this.ClickRemove);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CurtainFireMakerPlugin.Properties.Resources.up;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "上へ移動";
            this.toolStripButton3.Click += new System.EventHandler(this.ClickUp);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::CurtainFireMakerPlugin.Properties.Resources.down;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "下へ移動";
            this.toolStripButton4.Click += new System.EventHandler(this.ClickDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::CurtainFireMakerPlugin.Properties.Resources.Copy_16x;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "コピー";
            this.toolStripButton5.Click += new System.EventHandler(this.ClickCopy);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::CurtainFireMakerPlugin.Properties.Resources.Paste_16x;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "ペースト";
            this.toolStripButton6.Click += new System.EventHandler(this.ClickPaste);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.エクスプローラーToolStripMenuItem1,
            this.atomToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = global::CurtainFireMakerPlugin.Properties.Resources.OpenFile_16x;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "プログラムからファイルを開く";
            // 
            // エクスプローラーToolStripMenuItem1
            // 
            this.エクスプローラーToolStripMenuItem1.Name = "エクスプローラーToolStripMenuItem1";
            this.エクスプローラーToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.エクスプローラーToolStripMenuItem1.Text = "エクスプローラー";
            this.エクスプローラーToolStripMenuItem1.Click += new System.EventHandler(this.OpenWithExplorer);
            // 
            // atomToolStripMenuItem1
            // 
            this.atomToolStripMenuItem1.Name = "atomToolStripMenuItem1";
            this.atomToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.atomToolStripMenuItem1.Text = "Atom";
            this.atomToolStripMenuItem1.Click += new System.EventHandler(this.OpenWithAtom);
            // 
            // PresetSequenceEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.listBoxSequence);
            this.Controls.Add(this.textBoxSelectedScript);
            this.Name = "PresetSequenceEditorControl";
            this.Size = new System.Drawing.Size(642, 328);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxSequence;
        private System.Windows.Forms.TextBox textBoxSelectedScript;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem エクスプローラーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogScript;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem エクスプローラーToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem atomToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ペーストToolStripMenuItem;
    }
}
