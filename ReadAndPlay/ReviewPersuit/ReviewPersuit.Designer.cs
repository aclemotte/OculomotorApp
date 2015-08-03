namespace ReviewPersuit
{
    partial class ReviewPersuit
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartHorizontalGaze = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelZoomGuide = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartHorizontalGaze)).BeginInit();
            this.SuspendLayout();
            // 
            // chartHorizontalGaze
            // 
            this.chartHorizontalGaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "Pixels";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chartHorizontalGaze.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHorizontalGaze.Legends.Add(legend1);
            this.chartHorizontalGaze.Location = new System.Drawing.Point(46, 40);
            this.chartHorizontalGaze.Name = "chartHorizontalGaze";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Reference";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Right Gaze";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Left Gaze";
            this.chartHorizontalGaze.Series.Add(series1);
            this.chartHorizontalGaze.Series.Add(series2);
            this.chartHorizontalGaze.Series.Add(series3);
            this.chartHorizontalGaze.Size = new System.Drawing.Size(734, 543);
            this.chartHorizontalGaze.TabIndex = 0;
            this.chartHorizontalGaze.Text = "chartPersuitData";
            // 
            // labelZoomGuide
            // 
            this.labelZoomGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelZoomGuide.AutoSize = true;
            this.labelZoomGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZoomGuide.Location = new System.Drawing.Point(42, 600);
            this.labelZoomGuide.Name = "labelZoomGuide";
            this.labelZoomGuide.Size = new System.Drawing.Size(426, 24);
            this.labelZoomGuide.TabIndex = 2;
            this.labelZoomGuide.Text = "You can select an horizontal area to make a zoom";
            // 
            // ReviewPersuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 633);
            this.Controls.Add(this.labelZoomGuide);
            this.Controls.Add(this.chartHorizontalGaze);
            this.Name = "ReviewPersuit";
            this.Text = "Review Persuit Data";
            ((System.ComponentModel.ISupportInitialize)(this.chartHorizontalGaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHorizontalGaze;
        private System.Windows.Forms.Label labelZoomGuide;

    }
}

