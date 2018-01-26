namespace P4_Client
{
    partial class Form1
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
            this.ChatLog_textbox = new System.Windows.Forms.TextBox();
            this.Send_button = new System.Windows.Forms.Button();
            this.SendChat_box = new System.Windows.Forms.TextBox();
            this.Client_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatLog_textbox
            // 
            this.ChatLog_textbox.Location = new System.Drawing.Point(11, 11);
            this.ChatLog_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.ChatLog_textbox.Multiline = true;
            this.ChatLog_textbox.Name = "ChatLog_textbox";
            this.ChatLog_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatLog_textbox.Size = new System.Drawing.Size(329, 237);
            this.ChatLog_textbox.TabIndex = 0;
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(267, 251);
            this.Send_button.Margin = new System.Windows.Forms.Padding(2);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(73, 54);
            this.Send_button.TabIndex = 1;
            this.Send_button.Text = "Send";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // SendChat_box
            // 
            this.SendChat_box.Location = new System.Drawing.Point(85, 251);
            this.SendChat_box.Margin = new System.Windows.Forms.Padding(2);
            this.SendChat_box.Multiline = true;
            this.SendChat_box.Name = "SendChat_box";
            this.SendChat_box.Size = new System.Drawing.Size(178, 55);
            this.SendChat_box.TabIndex = 2;
            // 
            // Client_Start
            // 
            this.Client_Start.Location = new System.Drawing.Point(11, 252);
            this.Client_Start.Margin = new System.Windows.Forms.Padding(2);
            this.Client_Start.Name = "Client_Start";
            this.Client_Start.Size = new System.Drawing.Size(70, 54);
            this.Client_Start.TabIndex = 3;
            this.Client_Start.Text = "Start Connection";
            this.Client_Start.UseVisualStyleBackColor = true;
            this.Client_Start.Click += new System.EventHandler(this.Client_Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 320);
            this.Controls.Add(this.Client_Start);
            this.Controls.Add(this.SendChat_box);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.ChatLog_textbox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Chat (Client)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatLog_textbox;
        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.TextBox SendChat_box;
        private System.Windows.Forms.Button Client_Start;
    }
}

